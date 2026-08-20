using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yugi_Poc_GameShop.Model;

namespace Yugi_Poc_GameShop
{
    internal static class StartChecks
    {
        internal static Paths CheckData()
        {
            var registryKey = @"SOFTWARE\KONAMI\Yu-Gi-Oh! Power Of Chaos\system";
            var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    var commonDir = (string)key.GetValue("CommonDir");
                    if (commonDir == null || !File.Exists(Path.Combine(commonDir, "system.dat")))
                    {
                        MessageBox.Show("Can not read Common Dir where data is saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }

                    var installDirJ = (string)key.GetValue("InstallDirJ");
                    var installDirK = (string)key.GetValue("InstallDirK");
                    var installDirY = (string)key.GetValue("InstallDir");

                    var installedJ = installDirJ != null && Directory.Exists(installDirJ);
                    var installedK = installDirK != null && Directory.Exists(installDirK);
                    var installedY = installDirY != null && Directory.Exists(installDirY);

                    if (!installedJ && !installedK && !installedY) {
                        MessageBox.Show("No game installed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    var installedGames = new CardFilter(installedY, installedK, installedJ);

                    var idFile = Path.Combine(dataPath, @"bin#/card_id.bin");
                    if (File.Exists(idFile))
                    {
                        return new Paths
                        {
                            CommonDir = commonDir,
                            LibraryDir = dataPath,
                            InstalledGames = installedGames
                        };
                    }
                    var path = installedJ ? installDirJ : installedK ? installDirK : installDirY;
                    var filePath = Path.Combine(path, "data.dat");
                    var files = GetFileInfos(filePath).Where(x => x.FileName.StartsWith("bin#") || x.FileName.StartsWith("card")).ToList();
                    UnpackFiles(files, filePath, dataPath);

                    return new Paths
                    {
                        CommonDir = commonDir,
                        LibraryDir = dataPath,
                        InstalledGames = installedGames
                    };
                }

                MessageBox.Show("No game installed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
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
    }
}
