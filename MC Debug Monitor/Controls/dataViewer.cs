using MC_Debug_Monitor.utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MC_Debug_Monitor.Program;

namespace MC_Debug_Monitor.Controls
{
    public partial class DataViewer : RemovableControl
    {
        public DataViewer()
        {
            InitializeComponent();
        }

        private void dataViewer_Load(object sender, EventArgs e)
        {
            runButton.Enabled = mainform.isConnectedServer;
        }

        public override void onConnectServer()
        {
            runButton.Enabled = true;
            base.onConnectServer();
        }

        public override void onDisconnectServer()
        {
            runButton.Enabled = false;
            base.onDisconnectServer();
        }

        private void hotkeyResister1_onFaildHotKeyResister(object sender, EventArgs e)
        {
            mainform.setStatusText("ホットキーの登録に失敗しました(既に使われています)");
            System.Media.SystemSounds.Beep.Play();
        }

        private void hotkeyResister1_onHotKeyDisResister(object sender, EventArgs e)
        {
            mainform.setStatusText("ホットキーの登録を解除しました");
        }

        private void hotkeyResister1_onHotKeyResister(object sender, EventArgs e)
        {
            mainform.setStatusText("ホットキーを登録しました");
        }

        private void hotkeyResister1_HotKeyPush(object sender, EventArgs e)
        {
            if (mainform.isConnectedServer) runCommand();
        }

        public override void onClosedTab()
        {
            if (hotkeyResister1.hotkey != null) hotkeyResister1.hotkey.Dispose();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultBox.Text);
            mainform.setStatusText("コピーしました");
        }

        async private void runCommand()
        {
            if (commandBox.Text.Length > 0)
            {
                await Task.Run((Action)(async () =>
                {
                    string result = await mainform.sendCommand(commandBox.Text);
                    result = MCCommand.getResultString(result);
                    Invoke((Action)(() =>
                    {
                        SNBTLib.FormatInRichTextBox(result, resultBox);
                    }));
                }));
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runCommand();
        }
    }
}
