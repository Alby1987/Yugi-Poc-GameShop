using System;

namespace Yugi_Poc_GameShop
{
    public class Save
    {
        public DateTime LastSave { get; set; }
        public int Tokens { get; set; }
        public string DataPath { get; set; }
        public string Language { get; set; } = "eng";
    }
}
