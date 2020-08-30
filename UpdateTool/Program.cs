using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateTool
{
    static class Program
    {
        static string currentVersion;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int index = 0;
            foreach(string arg in args)
            {
                if (arg.Equals("-v"))
                {
                    if(index + 1 < args.Length) currentVersion = args[index + 1];
                    break;
                }
                index++;
            }
            if (currentVersion == null)
            {
                MessageBox.Show("バージョン情報の取得に失敗", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Task<int> task;
                task = UpdateManager.getLeatestVersion();
                task.Wait();
                var leatestVersion = task.Result;
                if(leatestVersion > UpdateManager.getNumberFromVersion(currentVersion))
                {
                    DialogResult result = MessageBox.Show("最新のバージョンが公開されています。\n更新しますか？", "更新",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2);
                    //アプデ処理
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            Application.Run(new updateForm());
                            MessageBox.Show("アップデート完了: " + UpdateManager.leatestVersion, "更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("アップデートに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (File.Exists("MC Debug Monitor.exe"))
                {
                    runMCDM();
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("\"MC Debug Monitor.exe\"が見つかりません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        static void runMCDM()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "MC Debug Monitor.exe";
            cmd.StartInfo.Arguments = "-vcd";
            cmd.Start();
        }
    }
}
