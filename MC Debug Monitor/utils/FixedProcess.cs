using System;
using System.Diagnostics;

namespace MC_Debug_Monitor.utils
{
    static class FixedProcess
    {

        // Process.StartでUrl開くとエラーが出るのでシェル直接叩く
        public static void openUrl(String targetUrl)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "powerShell.exe";
            //PowerShellのWindowを立ち上げずに実行。
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.CreateNoWindow = true;
            // 引数optionsをShellのコマンドとして渡す。
            cmd.StartInfo.Arguments = "start " + targetUrl;
            cmd.Start();
        }
    }
}
