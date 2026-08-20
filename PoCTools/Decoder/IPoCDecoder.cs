namespace Yugi_Poc_GameShop.PoCTools.Decoder
{
    public interface IPoCDecoder
    {
        void DecodeBuffer(byte[] inputBuffer, int length, byte[] outputBuffer);
        void EncodeBuffer(byte[] inputBuffer, int length, byte[] outputBuffer);
    }
}
