namespace Yugi_Poc_GameShop.Model
{
    public class PathsFile
    {
        public string CommonDir { get; set; }
        public string InstallDirJ { get; set; }
        public string InstallDirK { get; set; }
        public string InstallDirY { get; set; }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(CommonDir) || (string.IsNullOrEmpty(InstallDirJ) && string.IsNullOrEmpty(InstallDirK) && string.IsNullOrEmpty(InstallDirY));
        }
    }
}
