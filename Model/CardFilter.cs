namespace Yugi_Poc_GameShop.Model
{
    internal class CardFilter
    {
        internal CardFilter(bool yugi, bool kaiba, bool joey)
        {
            Yugi = yugi;
            Kaiba = kaiba;
            Joey = joey;
        }

        private CardFilter()
        {
        }

        internal bool Yugi { get; private set; } = false;
        internal bool Kaiba { get; private set; } = false;
        internal bool Joey { get; private set; } = false;

        internal static CardFilter Only_Yugi => new CardFilter { Yugi = true };
        internal static CardFilter Only_Kaiba => new CardFilter { Kaiba = true };
        internal static CardFilter Only_Joey => new CardFilter { Joey = true };
        internal static CardFilter All => new CardFilter { Yugi = true, Kaiba = true, Joey = true };
        
        public override string ToString()
        {
            return (Yugi ? "Yugi the Destiny\n" : string.Empty) + (Kaiba ? "Kaiba the Revenge\n" : string.Empty) + (Joey ? "Joey the Passion" : string.Empty);
        }
    }
}
