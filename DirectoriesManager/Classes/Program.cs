using System;
using System.Windows.Forms;

namespace DirectoriesManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected Error occurred, please contact support");
            Tools.LogError((Exception)e.ExceptionObject, nameof(Program) + " -> CurrentDomain_UnhandledException");
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected Error occurred, please contact support");
            Tools.LogError(e.Exception, nameof(Program) + " -> Application_ThreadException");
            Environment.Exit(1);
        }
    }
}
