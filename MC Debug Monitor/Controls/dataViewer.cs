using MC_Debug_Monitor.utils;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MC_Debug_Monitor.Program;

namespace MC_Debug_Monitor.Controls
{
    public partial class DataViewer : RemovableControl
    {

        private string rawResult;

        public DataViewer()
        {
            InitializeComponent();
        }

        private void dataViewer_Load(object sender, EventArgs e)
        {
            runButton.Enabled = mainform.isConnectedServer;
            fontSetup();

        }

        private void fontSetup()
        {
            try
            {
                System.Drawing.Text.PrivateFontCollection pfc =
                    new System.Drawing.Text.PrivateFontCollection();
                pfc.AddFontFile(@".\fonts\Myrica.ttc");
                foreach (FontFamily ff in pfc.Families)
                {
                    Console.WriteLine(ff.Name);
                }
                Font f = new Font(pfc.Families[0], 12);
                resultBox.Font = f;
            }
            catch
            {
                mainform.setStatusText("フォントの読み込みに失敗しました");
                System.Media.SystemSounds.Beep.Play();
            }
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
            if (mainform.isConnectedServer)
            {
                runCommand(); mainform.moveTab(TabIndex);
            }

        }

        public override void onClosedTab()
        {
            if (hotkeyResister1.hotkey != null) hotkeyResister1.hotkey.Dispose();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length > 0)
            {
                Clipboard.SetText(resultBox.Text);
                mainform.setStatusText("コピーしました");
            }
        }

        async private void runCommand()
        {
            if (commandBox.Text.Length > 0)
            {
                await Task.Run((Action)(async () =>
                {
                    string result = await mainform.sendCommand(commandBox.Text);
                    result = MCCommand.getResultString(result);
                    rawResult = (string)result.Clone();
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

        private void fontbutton_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();

            //fd.Font = resultBox.Font;
            fd.Color = resultBox.ForeColor;
            fd.MaxSize = 25;
            fd.MinSize = 5;
            fd.FontMustExist = true;
            fd.AllowVerticalFonts = true;

            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                resultBox.Font = fd.Font;
                if (resultBox.Text.Length > 0)
                {
                    SNBTLib.FormatInRichTextBox(rawResult, resultBox);
                }
            }
        }

        private void commandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && runButton.Enabled)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                runCommand();
            }
        }
    }
}
