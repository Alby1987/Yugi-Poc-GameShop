using System;
using System.Collections.Generic;

namespace Yugi_Poc_GameShop.PoCTools.Library
{
    public class MissingBinaryException : Exception
    {
        public List<string> MissingBinaries { get; private set; }
        public MissingBinaryException(List<string> missingBinaries, string message = "") : base(message)
        {
            MissingBinaries = missingBinaries;
        }

    }
    public class LibraryIsNotLoadedException : Exception
    {
        public LibraryIsNotLoadedException(string message = "Library is not loaded.") : base(message)
        {

        }
    }
}
