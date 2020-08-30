using MC_Debug_Monitor.utils;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MC_Debug_Monitor.Program;

namespace MC_Debug_Monitor.Controls
{
    public partial class RconConsole : RemovableControl
    {
        public RconConsole()
        {
            InitializeComponent();
        }

        private void RconConsole_Load(object sender, EventArgs e)
        {
            sendButton.Enabled = mainform.isConnectedServer;
            ConsoleView.AppendText("> ");
        }

        public override void onConnectServer()
        {
            sendButton.Enabled = true;
            base.onConnectServer();
        }

        public override void onDisconnectServer()
        {
            sendButton.Enabled = false;
            base.onDisconnectServer();
        }

        private void fontbutton_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();

            fd.Font = ConsoleView.Font;
            fd.Color = ConsoleView.ForeColor;
            fd.MaxSize = 25;
            fd.MinSize = 5;
            fd.ShowColor = true;
            fd.FontMustExist = true;
            fd.AllowVerticalFonts = true;

            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                ConsoleView.Font = fd.Font;
                ConsoleView.ForeColor = fd.Color;
            }
        }

        async private void sendCommand()
        {
            string cmd = (string)commandBox.Text.Clone();
            Invoke((Action)(() =>
            {
                ConsoleView.AppendText(commandBox.Text + "\n");
                commandBox.Text = "";
            }));
            await Task.Run((Action)(async () =>
            {
                string result = await mainform.sendCommand(cmd);
                Invoke((Action)(() =>
                {
                    if (result.Contains("[HERE]"))
                    {
                        ConsoleView.AppendText(" " + result + "\n", Color.Red);
                    }
                    else
                    {
                        ConsoleView.AppendText(" " + result + "\n");
                    }
                    ConsoleView.AppendText("> ");
                    ConsoleView.SelectionStart = ConsoleView.Text.Length;
                    ConsoleView.Focus();
                    ConsoleView.ScrollToCaret();
                    commandBox.Focus();
                }));
            }));
        }

        private void commandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && sendButton.Enabled && commandBox.Text.Length > 0)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                sendCommand();
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (commandBox.Text.Length > 0)
            {
                sendCommand();
            }
        }

        private void RconConsole_KeyDown(object sender, KeyEventArgs e)
        {
            commandBox.Focus();
            e.SuppressKeyPress = true;
        }
    }
}
