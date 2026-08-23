using System;
using Yugi_Poc_GameShop.Model;

namespace Yugi_Poc_GameShop
{
    public class Save
    {
        public DateTime LastSave { get; set; }
        public int Tokens { get; set; }
        public string DataPath { get; set; }
        public string Language { get; set; } = "eng";
        public ChatterState ChatterState { get; set; } = new ChatterState();
    }
}
