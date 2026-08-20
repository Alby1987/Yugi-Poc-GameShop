using System.Windows.Forms;

namespace Yugi_Poc_GameShop.View
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        internal void SetVersion(string version)
        {
            VersionLabel.Text = version;
        }
    }
}
