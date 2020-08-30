using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MC_Debug_Monitor
{
    static class Program
    {
        public static bool verChecked = false;
        public static MainForm mainform = new MainForm();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            foreach(string arg in args){
                if (arg.Equals("-vcd"))
                {
                    verChecked = true;
                }
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!verChecked && File.Exists("UpdateTool.exe"))
            {
                runUpdateTool();
                Environment.Exit(0);
            }
            Application.Run(mainform);
        }

        public static void runUpdateTool()
        {
            Process mdm = new Process();
            mdm.StartInfo.FileName = "UpdateTool.exe";
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            mdm.StartInfo.Arguments = string.Format("-v {0}", version);
            mdm.Start();
        }
    }
}
