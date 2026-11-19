using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Yugi_Poc_GameShop.Model;
using Yugi_Poc_GameShop.View;

namespace Yugi_Poc_GameShop
{
    internal static class Program
    {
        private static SplashScreenForm _splash;
        private static readonly object LogLock = new object();

        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread splashThread = new Thread(ShowSplash)
            {
                IsBackground = true
            };

            splashThread.Start();

            try
            {
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
            catch (Exception ex)
            {
                WriteCrashLog(ex, "Main.try-catch", true);
                CloseSplash();
                MessageBox.Show(
                    "Startup error. A log has been saved in the main folder",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static void ShowSplash()
        {
            try
            {
                _splash = new SplashScreenForm();
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                _splash.SetVersion(version != null ? version.ToString() : string.Empty);
                Application.Run(_splash);
            }
            catch (Exception ex)
            {
                WriteCrashLog(ex, "ShowSplash", false);
            }
        }

        private static void CloseSplash()
        {
            try
            {
                if (_splash != null && !_splash.IsDisposed && _splash.IsHandleCreated)
                {
                    _splash.Invoke(new MethodInvoker(delegate
                    {
                        if (_splash != null && !_splash.IsDisposed)
                        {
                            _splash.Close();
                            _splash.Dispose();
                        }
                    }));
                }
            }
            catch
            {
                
            }
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            WriteCrashLog(e.Exception, "Application.ThreadException", false);
            CloseSplash();
            MessageBox.Show(
                "General error. A log has been saved in the main folder.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            Application.Exit();
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            WriteCrashLog(ex, "AppDomain.UnhandledException", e.IsTerminating);
        }

        private static void WriteCrashLog(Exception ex, string source, bool isTerminating)
        {
            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash_log.txt");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("============================================================");
                sb.AppendLine("Timestamp     : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sb.AppendLine("Source        : " + source);
                sb.AppendLine("IsTerminating : " + isTerminating);
                sb.AppendLine("OS Version    : " + Environment.OSVersion);
                sb.AppendLine("CLR Version   : " + Environment.Version);

                if (ex != null)
                {
                    int level = 0;
                    Exception current = ex;
                    while (current != null)
                    {
                        sb.AppendLine("------------------------------------------------------------");
                        sb.AppendLine("Exception [" + level + "]: " + current.GetType().FullName);
                        sb.AppendLine("Message       : " + current.Message);
                        sb.AppendLine("Source        : " + current.Source);
                        sb.AppendLine("TargetSite    : " + (current.TargetSite != null ? current.TargetSite.ToString() : "N/A"));
                        sb.AppendLine("StackTrace:");
                        sb.AppendLine(current.StackTrace ?? "(nessuno stack trace disponibile)");

                        current = current.InnerException;
                        level++;
                    }
                }
                else
                {
                    sb.AppendLine("ExceptionObject is not a System.Exception.");
                }

                sb.AppendLine();

                lock (LogLock)
                {
                    File.AppendAllText(logPath, sb.ToString(), Encoding.UTF8);
                }
            }
            catch
            {

            }
        }
    }
}