using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Yugi_Poc_GameShop.Model;

namespace Yugi_Poc_GameShop
{
    internal static class StartChecks
    {
        internal static Paths CheckData()
        {
            var overrideDataPath = false;
            var registryKey = @"SOFTWARE\KONAMI\Yu-Gi-Oh! Power Of Chaos\system";
            var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

            PathsFile pathsFile = new PathsFile();
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    var commonDir = (string)key.GetValue("CommonDir");
                    var installDirJ = (string)key.GetValue("InstallDirJ");
                    var installDirK = (string)key.GetValue("InstallDirK");
                    var installDirY = (string)key.GetValue("InstallDir");

                    pathsFile.CommonDir = commonDir;
                    pathsFile.InstallDirJ = installDirJ;
                    pathsFile.InstallDirK = installDirK;
                    pathsFile.InstallDirY = installDirY;
                }
            }

            var filePaths = LoadPaths();
            pathsFile.Merge(filePaths);

            if (pathsFile.MissingCommonDir())
            {
                MessageBox.Show("Please configure the common folder", "Missing informations", MessageBoxButtons.OK);
                pathsFile.CommonDir = SelectFolder(null, SelectFolderOption.Common);
                SavePaths(pathsFile);
            }

            if (!pathsFile.MissingOverrideDir())
            {
                dataPath = pathsFile.OverrideDataDir;
                overrideDataPath = true;
            }

            if (pathsFile.MissingAnyGame() && !overrideDataPath)
            {
                var trilogy = MessageBox.Show("Missing registry data about the games. Do you have the Trilogy MOD?", "Missing informations", MessageBoxButtons.YesNo);
                if (trilogy == DialogResult.Yes)
                {
                    MessageBox.Show("Please select the file card_id.bin inside the data/bin# folder inside the Trilogy MOD", "Missing informations", MessageBoxButtons.OK);
                    pathsFile.OverrideDataDir = Path.GetDirectoryName(SelectFolder(null, SelectFolderOption.DataFolder));
                    overrideDataPath = true;
                    dataPath = pathsFile.OverrideDataDir;
                    SavePaths(pathsFile);
                }
                else
                {
                    MessageBox.Show("Please select the data.dat file from the three games (in order, Joey, Kaiba, Yugi). If you don't have one of these games, please click the cancel button in the file chooser dialog", "Missing informations", MessageBoxButtons.OK);
                    pathsFile.InstallDirJ = SelectFolder("Joey the Passion", SelectFolderOption.GameData);
                    pathsFile.InstallDirK = SelectFolder("Kaiba the Revenge", SelectFolderOption.GameData);
                    pathsFile.InstallDirY = SelectFolder("Yugi the Destiny", SelectFolderOption.GameData);
                    SavePaths(pathsFile);
                }
            }

            if (pathsFile.CommonDir == null || !File.Exists(Path.Combine(pathsFile.CommonDir, "system.dat")))
            {
                MessageBox.Show("Game save not found. Have you run one of the games at least once?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pathsFile = new PathsFile();
                SavePaths(pathsFile);
                Environment.Exit(0);
            }

            var installedJ = pathsFile.InstallDirJ != null && Directory.Exists(pathsFile.InstallDirJ) && File.Exists(Path.Combine(pathsFile.InstallDirJ, "data.dat"));
            var installedK = pathsFile.InstallDirK != null && Directory.Exists(pathsFile.InstallDirK) && File.Exists(Path.Combine(pathsFile.InstallDirK, "data.dat"));
            var installedY = pathsFile.InstallDirY != null && Directory.Exists(pathsFile.InstallDirY) && File.Exists(Path.Combine(pathsFile.InstallDirY, "data.dat"));

            if (overrideDataPath)
            {
                installedJ = installedK = installedY = true;
            }

            if (!installedJ && !installedK && !installedY)
            {
                MessageBox.Show("Games paths set but no data found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            var installedGames = new CardFilter(installedY, installedK, installedJ);

            var idFile = Path.Combine(dataPath, @"bin#/card_id.bin");
            if (File.Exists(idFile))
            {
                return new Paths
                {
                    CommonDir = pathsFile.CommonDir,
                    LibraryDir = dataPath,
                    InstalledGames = installedGames
                };
            }
            else if (overrideDataPath)
            {
                MessageBox.Show("Wrong Trilogy Data path chosen. Restart the software", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pathsFile = new PathsFile();
                SavePaths(pathsFile);
                Environment.Exit(0);
            }

            var path = installedJ ? pathsFile.InstallDirJ : installedK ? pathsFile.InstallDirK : pathsFile.InstallDirY;
            var filePath = Path.Combine(path, "data.dat");
            var files = GetFileInfos(filePath).Where(x => x.FileName.StartsWith("bin#") || x.FileName.StartsWith("card")).ToList();
            UnpackFiles(files, filePath, dataPath);

            return new Paths
            {
                CommonDir = pathsFile.CommonDir,
                LibraryDir = dataPath,
                InstalledGames = installedGames
            };

        }

        static void UnpackFiles(List<FileData> files, string filePath, string outDirectory)
        {
            foreach (FileData file in files)
            {
                // Read file data
                var reader = new BinaryReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));
                reader.BaseStream.Position = file.FileOffset;
                byte[] bytes = reader.ReadBytes((int)file.FileSize);
                reader.Close();


                // LZSS decompression
                if (file.FileSize != file.CompressedFileSize)
                {
                    bytes = Decompress(bytes, file.FileSize);
                }

                // YPK1 decoding
                if (IsYPK1(bytes))
                {
                    // Not sure what uses it, but it's in the original code so I kept it
                    bytes = DecodeYPK1(bytes);
                }

                string outPath = Path.Combine(outDirectory, file.FileName);
                string outDir = Path.GetDirectoryName(outPath);
                if (!string.IsNullOrEmpty(outDir)) Directory.CreateDirectory(outDir);
                File.WriteAllBytes(outPath, bytes);
            }
        }
        static List<FileData> GetFileInfos(string path)
        {
            List<FileData> files = new List<FileData>();

            BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open));

            if (reader.BaseStream.Length < 12) { return files; }

            byte[] header = reader.ReadBytes(8);
            string strHeader = Encoding.ASCII.GetString(header);
            if (strHeader != "KCEJYUGI") { return files; }

            uint fileCount = reader.ReadUInt32();

            for (uint i = 0; i < fileCount; i++)
            {
                byte[] fileNameBytes = reader.ReadBytes(256);
                uint fileOffset = reader.ReadUInt32();
                uint fileSize = reader.ReadUInt32();
                uint cmpFileSize = reader.ReadUInt32();

                // Decrypt filename
                for (int j = 0; j < fileNameBytes.Length; j++)
                {
                    byte b = fileNameBytes[j];
                    fileNameBytes[j] = (byte)((b >> 4) | (b << 4));
                }

                files.Add(new FileData
                {
                    FileName = Encoding.ASCII.GetString(fileNameBytes).TrimEnd('\0'),
                    FileOffset = fileOffset,
                    FileSize = fileSize,
                    CompressedFileSize = cmpFileSize
                });
            }
            reader.Close();
            return files;
        }
        public static byte[] Decompress(byte[] input, uint outputSize)
        {
            // LZSS decompression algorithm
            byte[] output = new byte[outputSize];
            byte[] dictionary = new byte[4096];

            int inputPos = 0;
            int outputPos = 0;

            int dictPos = 0xFEE;
            int flags = 0;

            while (outputPos < outputSize)
            {
                flags >>= 1;

                if ((flags & 0x100) == 0)
                {
                    flags = 0xFF00 | input[inputPos++];
                }

                if ((flags & 1) != 0)
                {
                    // Literal
                    byte b = input[inputPos++];

                    output[outputPos++] = b;

                    dictionary[dictPos] = b;
                    dictPos = (dictPos + 1) & 0xFFF;
                }
                else
                {
                    // Back-reference
                    byte b1 = input[inputPos++];
                    byte b2 = input[inputPos++];

                    int offset = b1 | ((b2 & 0xF0) << 4);
                    int length = (b2 & 0x0F) + 3;

                    for (int i = 0; i < length; i++)
                    {
                        byte b = dictionary[offset];

                        output[outputPos++] = b;

                        dictionary[dictPos] = b;

                        dictPos = (dictPos + 1) & 0xFFF;
                        offset = (offset + 1) & 0xFFF;

                        if (outputPos >= outputSize)
                            break;
                    }
                }
            }

            return output;
        }
        static bool IsYPK1(byte[] data)
        {
            return data.Length >= 4 &&
                   data[0] == (byte)'Y' &&
                   data[1] == (byte)'P' &&
                   data[2] == (byte)'K' &&
                   data[3] == (byte)'1';
        }
        static byte[] DecodeYPK1(byte[] data)
        {
            byte[] result = new byte[data.Length - 4];

            for (int i = 4; i < data.Length; i++)
            {
                byte b = data[i];

                b = (byte)((b >> 4) | (b << 4)); // swap nibbles
                b ^= 0xCC;

                result[i - 4] = b;
            }

            return result;
        }
        public class FileData
        {
            public string FileName { get; set; } = "";
            public uint FileSize { get; set; } = 0x0;
            public uint CompressedFileSize { get; set; } = 0x0;
            public uint FileOffset { get; set; } = 0x0;
            public string FileOffsetHex => $"{FileOffset:X}";
        }

        private static PathsFile LoadPaths()
        {
            var internalSavePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Paths.xml");
            if (!File.Exists(internalSavePath))
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(PathsFile));
            using (StreamReader reader = new StreamReader(internalSavePath))
            {
                return (PathsFile)serializer.Deserialize(reader);
            }
        }

        private static void SavePaths(PathsFile pathsFile)
        {
            var internalSavePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Paths.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(PathsFile));
            using (StreamWriter writer = new StreamWriter(internalSavePath))
            {
                serializer.Serialize(writer, pathsFile);
            }
        }

        public static string SelectFolder(string game, SelectFolderOption selectFolderOption)
        {
            string title = null;
            string filter = null;
            string fileName = null;
            switch (selectFolderOption)
            {
                case SelectFolderOption.Common:
                    title = "Select system.dat for game saves";
                    filter = "System Data (system.dat)|system.dat";
                    fileName = "system.dat";
                    break;
                case SelectFolderOption.GameData:
                    title = $"Select data.dat for {game}";
                    filter = "Game Data (data.dat)|data.dat";
                    fileName = "data.dat";
                    break;
                case SelectFolderOption.DataFolder:
                    title = $"Select data folder";
                    filter = "Game Data (card_id.bin)|card_id.bin";
                    fileName = "card_id.bin";
                    break;
            }
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.ShowHelp = true;
                dialog.Title = title;
                dialog.Filter = filter;
                dialog.FileName = fileName;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.Multiselect = false;

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.FileName))
                {
                    return Path.GetDirectoryName(dialog.FileName);
                }
            }

            return null;
        }

        public enum SelectFolderOption
        {
            Common,
            GameData,
            DataFolder
        }
    }
}
