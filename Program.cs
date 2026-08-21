using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Yugi_Poc_GameShop.Model;
using Yugi_Poc_GameShop.View;

namespace Yugi_Poc_GameShop
{
    internal static class Program
    {
        private static SplashScreenForm splash;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread splashThread = new Thread(ShowSplash)
            {
                IsBackground = true
            };

            splashThread.Start();

            var paths = StartChecks.CheckData();
            
            var context = new Context(paths.LibraryDir, paths.CommonDir, paths.InstalledGames);
            var images = new Images(context);
            
            var ygoForm = new YgoGameShopForm(context, images);
            ygoForm.Shown += (s, e) =>
            {
                ygoForm.WindowState = FormWindowState.Normal;
                ygoForm.Activate();
                ygoForm.BringToFront();
                CloseSplash();
            };

            Application.Run(ygoForm);
        }

        private static void ShowSplash()
        {
            splash = new SplashScreenForm();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            splash.SetVersion(version.ToString());
            Application.Run(splash);
        }

        private static void CloseSplash()
        {
            splash?.Invoke(new MethodInvoker(delegate {
                    splash.Close();
                    splash.Dispose();
                }));
        }
    }
}
