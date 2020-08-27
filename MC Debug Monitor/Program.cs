using System;
using System.Windows.Forms;

namespace MC_Debug_Monitor
{
    static class Program
    {
        public static string version = "0.1.1-alpha";
        public static MainForm mainform = new MainForm();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainform);
        }
    }
}
