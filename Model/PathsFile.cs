namespace Yugi_Poc_GameShop.Model
{
    public class PathsFile
    {
        public string CommonDir { get; set; }
        public string InstallDirJ { get; set; }
        public string InstallDirK { get; set; }
        public string InstallDirY { get; set; }
        public string OverrideDataDir { get; set; }

        public bool MissingCommonDir()
        {
            return string.IsNullOrEmpty(CommonDir);
        }

        public bool MissingAnyGame()
        {
            return string.IsNullOrEmpty(InstallDirJ) && string.IsNullOrEmpty(InstallDirK) && string.IsNullOrEmpty(InstallDirY);
        }

        public bool MissingOverrideDir()
        {
            return string.IsNullOrEmpty(OverrideDataDir);
        }

        public void Merge(PathsFile other)
        {
            if (other == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(CommonDir) && !string.IsNullOrEmpty(other.CommonDir))
            {
                CommonDir = other.CommonDir;
            }

            if (string.IsNullOrEmpty(InstallDirJ) && !string.IsNullOrEmpty(other.InstallDirJ))
            {
                InstallDirJ = other.InstallDirJ;
            }

            if (string.IsNullOrEmpty(InstallDirK) && !string.IsNullOrEmpty(other.InstallDirK))
            {
                InstallDirK = other.InstallDirK;
            }

            if (string.IsNullOrEmpty(InstallDirY) && !string.IsNullOrEmpty(other.InstallDirY))
            {
                InstallDirY = other.InstallDirY;
            }

            if (string.IsNullOrEmpty(OverrideDataDir) && !string.IsNullOrEmpty(other.OverrideDataDir))
            {
                OverrideDataDir = other.OverrideDataDir;
            }
        }
    }
}
