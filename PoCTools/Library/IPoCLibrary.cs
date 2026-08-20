using System.Collections.Generic;

namespace Yugi_Poc_GameShop.PoCTools.Library
{
    public interface IPoCLibrary
    {
        void LoadLibrary(string path, string language);
        List<Card> Cards { get; }
    }
}
