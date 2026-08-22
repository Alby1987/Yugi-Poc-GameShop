using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yugi_Poc_GameShop.PoCTools.Library
{
    public class PoCLibrary : IPoCLibrary
    {
        private readonly Dictionary<string, byte[]> binaries = new Dictionary<string, byte[]>();
        private readonly List<string> imgNames = new List<string>();
        private List<Card> cards;
        private string _language;

        public List<Card> Cards => cards;

        public void LoadLibrary(string path, string language)
        {
            _language = language;
            binaries.Clear();
            imgNames.Clear();
            cards?.Clear();

            //bin#
            string binPath = Path.Combine(path, "bin#");
            if (Directory.Exists(binPath))
            {
                foreach (string file in Directory.GetFiles(binPath))
                {
                    string fileName = Path.GetFileName(file);
                    byte[] bin = File.ReadAllBytes(file);

                    binaries.Add(fileName, bin);
                }
                List<string> missingBinaries = new List<string>();

                if (!binaries.ContainsKey("card_id.bin")) missingBinaries.Add("card_id.bin");
                if (!binaries.ContainsKey($"card_name{language}.bin")) missingBinaries.Add($"card_name{language}.bin");
                if (!binaries.ContainsKey($"card_desc{language}.bin")) missingBinaries.Add($"card_desc{language}.bin");
                if (!binaries.ContainsKey($"card_indx{language}.bin")) missingBinaries.Add($"card_indx{language}.bin");
                if (!binaries.ContainsKey("card_prop.bin")) missingBinaries.Add("card_prop.bin");
                if (!binaries.ContainsKey("card_pack.bin")) missingBinaries.Add("card_pack.bin");

                if (missingBinaries.Count > 0) throw new MissingBinaryException(missingBinaries);
            }
            else throw new DirectoryNotFoundException($"Can't find folder 'bin#' at {path}");

            //card/list_card.txt
            string cardPath = Path.Combine(path, "card");
            if (Directory.Exists(cardPath))
            {
                string listPath = Path.Combine(cardPath, "list_card.txt");
                if (File.Exists(listPath))
                {
                    string[] lines = File.ReadAllLines(listPath);
                    foreach (string line in lines)
                    {
                        if (!(line == null || line == string.Empty) && !line.StartsWith("//"))
                        {
                            imgNames.Add(line.Trim());
                        }
                    }
                }
            }

            LoadCards();
        }

        private void LoadCards()
        {
            cards = new List<Card>();

            using (var idReader = new BinaryReader(new MemoryStream(binaries["card_id.bin"])))
            using (var nameReader = new BinaryReader(new MemoryStream(binaries[$"card_name{_language}.bin"])))
            using (var descReader = new BinaryReader(new MemoryStream(binaries[$"card_desc{_language}.bin"])))
            using (var idxReader = new BinaryReader(new MemoryStream(binaries[$"card_indx{_language}.bin"])))
            using (var propReader = new BinaryReader(new MemoryStream(binaries["card_prop.bin"])))
            using (var packReader = new BinaryReader(new MemoryStream(binaries["card_pack.bin"])))
            {
                idxReader.ReadBytes(4); // Skip the idx of the first description

                int i = 0;
                while (!idReader.BaseStream.Position.Equals(idReader.BaseStream.Length))
                {
                    ushort id = idReader.ReadUInt16();
                    string name = Encoding.GetEncoding(1252).GetString(nameReader.ReadBytes(64)).TrimEnd('\0');
                    uint nextIdx = idxReader.BaseStream.Position.Equals(idxReader.BaseStream.Length) ? (uint)descReader.BaseStream.Length - 1 : idxReader.ReadUInt32();
                    string desc = nextIdx > descReader.BaseStream.Position ? Encoding.GetEncoding(1252).GetString(descReader.ReadBytes((int)(nextIdx - descReader.BaseStream.Position))).TrimEnd('\0') : "";
                    uint prop = propReader.ReadUInt32();
                    ushort ver = packReader.ReadUInt16();

                    Card card = new Card
                    {
                        ID = id,
                        Name = name,
                        Description = desc,
                        PropertyBinary = prop,
                        ImageName = imgNames[i],
                        VersionBinary = ver
                    };
                    cards.Add(card);

                    i++;
                }
            }
        }
    }
}
