using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Yugi_Poc_GameShop.Model;
using Yugi_Poc_GameShop.PoCTools;
using Yugi_Poc_GameShop.PoCTools.Decoder;
using Yugi_Poc_GameShop.PoCTools.Library;

namespace Yugi_Poc_GameShop
{
    public class Context
    {
        private byte[] _saveData;
        private readonly PoCLibrary _library;
        private readonly PoCDecoder _decoder;
        private readonly Dictionary<int, byte> _playersCards = new Dictionary<int, byte>();
        private readonly Random _random = new Random();
        private readonly string _libraryPath;
        private readonly string _imagePath;
        private readonly string _savePath;
        private readonly List<int> _toRemove = new List<int>();
        private readonly List<int> _toAdd = new List<int>();
        private readonly Save _internalSave;

        internal CardFilter InstalledGames { get; private set; }

        internal Context(string libraryPath, string savePath, CardFilter installedGames)
        {
            _library = new PoCLibrary();
            _decoder = new PoCDecoder();
            _libraryPath = libraryPath;
            _imagePath = Path.Combine(_libraryPath, "card");
            _savePath = savePath;
            InstalledGames = installedGames;
            _internalSave = LoadSettings();
            UpdateTokens();
        }

        private Save LoadSettings()
        {
            var internalSavePath = Path.Combine(_savePath, "GameShop.xml");
            if (!File.Exists(internalSavePath))
            {
                return new Save();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Save));
            using (StreamReader reader = new StreamReader(internalSavePath))
            {
                return (Save)serializer.Deserialize(reader);
            }
        }

        internal void SaveSettings()
        {
            var internalSavePath = Path.Combine(_savePath, "GameShop.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Save));
            using (StreamWriter writer = new StreamWriter(internalSavePath))
            {
                serializer.Serialize(writer, _internalSave);
            }
        }

        internal void LoadLibrary()
        {
            _library.LoadLibrary(_libraryPath, _internalSave.Language);
        }

        internal void LoadGameSave()
        {
            if (!File.Exists(Path.Combine(_savePath, "system.original.bak")))
            {
                File.Copy(Path.Combine(_savePath, "system.dat"), Path.Combine(_savePath, "system.original.bak"));
            }

            using (var reader = new BinaryReader(new FileStream(Path.Combine(_savePath, "system.dat"), FileMode.Open, FileAccess.Read)))
            {
                var saveData = reader.ReadBytes((int)reader.BaseStream.Length);

                byte[] output = new byte[saveData.Length];
                _decoder.DecodeBuffer(saveData, 0x1190, output);
                _saveData = output;

                for (int i = 0x14; i < 0x8CA; i += 2)
                {
                    ushort word = BitConverter.ToUInt16(_saveData, i);
                    byte amount = (byte)(word & 0xFF);
                    _playersCards[(i - 0x14) / 2] = amount;
                }
            }
        }

        internal void SaveGameSave()
        {
            for (int i = 0; i < _playersCards.Count; i++)
            {
                int index = i * 2 + 0x14;
                _saveData[index] = Convert.ToByte(_playersCards[i]);
            }
            byte[] output = new byte[_saveData.Length];
            try
            {
                _decoder.EncodeBuffer(_saveData, 0x1190, output);
            }
            catch
            {
                Console.WriteLine("Error");
                return;
            }
            try
            {
                int maxBackups = 5;

                for (int i = maxBackups; i > 1; i--)
                {
                    string targetPath = Path.Combine(_savePath, "system.dat." + i);
                    string sourcePath = Path.Combine(_savePath, "system.dat." + (i - 1));

                    if (File.Exists(sourcePath))
                    {
                        if (File.Exists(targetPath))
                            File.Delete(targetPath);

                        File.Move(sourcePath, targetPath);
                    }
                }

                string originalPath = Path.Combine(_savePath, "system.dat");
                string firstBackupPath = Path.Combine(_savePath, "system.dat.1");

                if (File.Exists(originalPath))
                {
                    File.Copy(originalPath, firstBackupPath, true);
                }

                using (var writer = new BinaryWriter(File.Create(Path.Combine(_savePath, "system.dat"))))
                {
                    writer.Write(output);
                }
            }
            catch
            {
                MessageBox.Show("Error saving file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal int GetRandomNewCard(CardFilter cardFilter)
        {
            var filter = new HashSet<int>(GetCardListIndex(cardFilter));

            var emptyKeys = _playersCards
                .Where(p => filter.Contains(p.Key) && p.Value == 0)
                .Select(p => p.Key)
                .ToList();

            if (emptyKeys.Count == 0)
            {
                return -1;
            }

            int randomIndex = _random.Next(emptyKeys.Count);
            return emptyKeys[randomIndex];
        }

        internal int GetRandomCard(CardFilter cardFilter)
        {
            if (_playersCards.Count == 0)
            {
                return -1;
            }

            var filter = GetCardListIndex(cardFilter);

            filter = filter.Where(x => _playersCards[x] != 255).ToList();

            if (filter.Count == 0)
            {
                return -1;
            }

            int randomIndex = _random.Next(filter.Count);
            return filter[randomIndex];
        }

        internal List<int> GetCardListIndex(CardFilter filter)
        {
            return _library.Cards
            .Select((card, index) => new { card, index })
            .Where(x => (x.card.VersionYugi || x.card.VersionKaiba || x.card.VersionJoey)
                && (x.card.VersionYugi && filter.Yugi
                || x.card.VersionKaiba && filter.Kaiba
                || x.card.VersionJoey && filter.Joey))
            .Select(x => x.index)
            .ToList();
        }

        internal bool IsKnown(int cardIndex)
        {
            return _playersCards[cardIndex] > 0;
        }

        internal Card GetCard(int index)
        {
            return _library.Cards[index];
        }

        internal Dictionary<int, byte> GetCardListCopy()
        {
            return new Dictionary<int, byte>(_playersCards);
        }

        internal string GetImagePath(string fileName)
        {
            return Path.Combine(_imagePath, fileName);
        }

        internal void Reset()
        {
            _toAdd.Clear();
            _toRemove.Clear();
        }

        internal void Apply()
        {
            foreach (var cardId in _toAdd)
            {
                AddOneEffective(cardId);
            }

            foreach (var cardId in _toRemove)
            {
                RemoveOneEffective(cardId);
            }

            Reset();
            SaveGameSave();
            UpdatePoints(false);
            SaveSettings();
        }

        internal void UpdateTokens()
        {
            var now = DateTime.UtcNow;
            var lastGen = _internalSave.LastSave;

            if (lastGen > now)
            {
                _internalSave.LastSave = now;
                SaveSettings();
                return;
            }

            if (_internalSave.Tokens >= 4)
            {
                _internalSave.Tokens = 4;
                _internalSave.LastSave = now;
                SaveSettings();
                return;
            }

            TimeSpan elapsed = now - lastGen;
            int tokensToAdd = (int)(elapsed.TotalHours / 12);

            if (tokensToAdd > 0)
            {
                _internalSave.Tokens += tokensToAdd;

                if (_internalSave.Tokens >= 4)
                {
                    _internalSave.Tokens = 4;
                    _internalSave.LastSave = now;
                }
                else
                {
                    _internalSave.LastSave = lastGen.AddHours(tokensToAdd * 12);
                }

                SaveSettings();
            }
        }

        internal int GetTokens()
        {
            return _internalSave.Tokens;
        }

        internal int GetPoints()
        {
            return _internalSave.Points;
        }

        internal string GetTokenCountdown()
        {
            if (_internalSave.Tokens >= 4)
            {
                return "MAX";
            }

            var now = DateTime.UtcNow;
            var nextTokenTime = _internalSave.LastSave.AddHours(12);
            var difference = nextTokenTime - now;

            if (difference <= TimeSpan.Zero)
            {
                return "00:00";
            }

            int hours = (int)difference.TotalHours;
            int minutes = difference.Minutes;
            int seconds = difference.Seconds;

            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }

        internal void ConsumeTokensOrPoints()
        {
            UpdateTokens();
            UpdatePoints(false);

            if (_internalSave.Tokens <= 0)
            {
                _internalSave.Points -= 10;
                return;
            }

            if (_internalSave.Tokens == 4)
            {
                _internalSave.LastSave = DateTime.UtcNow;
            }

            _internalSave.Tokens--;
            SaveSettings();
        }

        internal string[] GetLanguages()
        {
            var files = Directory.GetFiles(Path.Combine(_libraryPath, "bin#"));
            return files.Select(Path.GetFileNameWithoutExtension).Where(x => x.StartsWith("card_indx"))
                .Select(x => x.Substring(x.Length - 3)).ToArray();
        }

        internal string GetLanguage()
        {
            return _internalSave.Language;
        }

        internal void SetLanguage(string language)
        {
            _internalSave.Language = language;
            SaveSettings();
        }

        internal void AddOne(int index)
        {
            _toAdd.Add(index);
        }

        internal void RemoveOne(int index)
        {
            _toRemove.Add(index);
        }

        internal ChatterState GetChatterState()
        {
            return _internalSave.ChatterState;
        }

        internal void SetChatterState(ChatterState chatterState)
        {
            _internalSave.ChatterState = chatterState;
        }

        internal void UpdatePoints(bool atStart)
        {
            var newPoints = 0;
            var savedCards = _internalSave.SavedCards;

            if (savedCards.Length != _playersCards.Count)
            {
                savedCards = new byte[_playersCards.Count];
            }

            var newCardsFound = false;

            foreach (var cards in _playersCards)
            {
                var gameSavedCard = cards.Value;

                var internalSavedCard = savedCards[cards.Key];

                if (gameSavedCard > internalSavedCard)
                {
                    newCardsFound = true;
                    var gameSavedCardNormalized = (int)Math.Min(gameSavedCard, (byte)3);
                    var internalSavedCardNormalized = (int)Math.Min(internalSavedCard, (byte)3);

                    var cardPoints = gameSavedCardNormalized - internalSavedCardNormalized;

                    if (cardPoints > 0)
                    {
                        if (internalSavedCardNormalized == 0)
                        {
                            cardPoints--;
                        }

                        newPoints += cardPoints;
                    }
                }

                savedCards[cards.Key] = gameSavedCard;
            }

            if (newPoints > 0)
            {
                _internalSave.Points += newPoints;
                _internalSave.SavedCards = savedCards;
                _internalSave.LastCardWon = DateTime.UtcNow;
                SaveSettings();
            }
            else if (newCardsFound && atStart)
            {
                _internalSave.LastCardWon = DateTime.UtcNow;
                SaveSettings();
            }
        }

        internal bool GetWinningDuelsExpired()
        {
            return _internalSave.LastCardWon.AddDays(7) < DateTime.UtcNow;
        }

        private void AddOneEffective(int index)
        {
            if (_playersCards[index] == 255)
            {
                return;
            }

            _playersCards[index] += 1;
        }

        private void RemoveOneEffective(int index)
        {
            if (_playersCards[index] == 0)
            {
                return;
            }

            _playersCards[index] -= 1;
        }
    }
}
