namespace Yugi_Poc_GameShop.Model
{
    public class ChatterState
    {
        public int YugiCardsToWin { get; set; } = 25;
        public int KaibaCardsToWin { get; set; } = 25;
        public int JoeyCardsToWin { get; set; } = 25;
        public int YugiCards { get; set; } = 0;
        public int KaibaCards { get; set; } = 0;
        public int JoeyCards { get; set; } = 0;
        public int YugiTotalCards { get; set; } = 0;
        public int KaibaTotalCards { get; set; } = 0;
        public int JoeyTotalCards { get; set; } = 0;
        public ushort SpeechState { get; set; } = 0;
        public ushort MilestonesState { get; set; } = 0;
    }

    internal class PhrasesState
    {
        internal bool Completed { get; set; }
        internal bool[] YugiPhrases { get; set; }
        internal bool[] KaibaPhrases { get; set; }
        internal bool[] JoeyPhrases { get; set; }
    }
}
