using MC_Debug_Monitor.Properties;
using MC_Debug_Monitor.utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace MC_Debug_Monitor.Controls
{
    public partial class serverManager : UserControl
    {
        public serverManager()
        {
            InitializeComponent();
        }

        private void rconIPLeaved(object sender, EventArgs e)
        {
            if (rconIP.Text.Equals("localhost"))
            {
                rconIP.Text = "127.0.0.1";
                return;
            }
            try
            {
                IPAddress.Parse(rconIP.Text);
            }
            catch
            {
                rconIP.Text = Settings.Default.rconIP;
                System.Media.SystemSounds.Beep.Play();
            }
            saveAllSettings();
        }

        private void rconPortLeaved(object sender, EventArgs e)
        {
            saveAllSettings();
        }

        private void rconPassLeaved(object sender, EventArgs e)
        {
            saveAllSettings();
        }

        private void scoreboardMonitor_Load(object sender, EventArgs e)
        {
            rconIP.Text = Settings.Default.rconIP;
            rconPort.Value = Settings.Default.rconPort;
            rconPass.Text = Settings.Default.rconPass;
            onDisConnectServer();
        }

        private void saveAllSettings()
        {
            Settings.Default.rconIP = rconIP.Text;
            Settings.Default.rconPass = rconPass.Text;
            Settings.Default.rconPort = rconPort.Value;
            Settings.Default.Save();
        }

        private void getIPButton_Click(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();

            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                rconIP.Text = address.ToString();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Server properties file|server.properties";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();
                if (stream != null)
                {
                    Dictionary<string, string> properties = FileUtil.getServerProperties(stream);
                    try
                    {

                        if (properties["enable-rcon"].Equals("true"))
                        {
                            if (properties["server-ip"] != null) rconIP.Text = properties["server-ip"];
                            rconPort.Value = int.Parse(properties["rcon.port"]);
                            rconPass.Text = properties["rcon.password"];
                            System.Media.SystemSounds.Asterisk.Play();
                        }
                        else
                        {
                            MessageBox.Show("Rconが有効ではありません。\nserver.propertiesの内容を確認してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("設定の値が不正です。\nserver.propertiesの内容を確認してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            saveAllSettings();
        }

        private void serverControl_Enter(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Invoke((Action)(async () =>
            {
                connectButton.Enabled = false;
                rconSetting.Enabled = false;
                await Program.mainform.tryConnectServer();
                if (Program.mainform.isConnectedServer)
                {
                    Program.mainform.rcon.OnDisconnected += (Action)Invoke((Action)onDisConnectServer);
                    onConnectServer();
                }
                else
                {
                    onDisConnectServer();
                }
            }));
        }

        private void onConnectServer()
        {
            disconnectButton.Enabled = true;
            reloadButton.Enabled = true;
            rconSetting.Enabled = false;
            connectButton.Enabled = false;
        }

        private void onDisConnectServer()
        {
            disconnectButton.Enabled = false;
            reloadButton.Enabled = false;
            connectButton.Enabled = true;
            rconSetting.Enabled = true;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Program.mainform.onDisconnectServer();
            onDisConnectServer();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            Invoke((Action)(async () =>
            {
                reloadButton.Enabled = false;
                Program.mainform.setServerStatus("reloading");
                Program.mainform.setStatusText("サーバーをリロード中");
                if (Program.mainform.isConnectedServer)
                {
                    await Program.mainform.sendCommand("reload");
                }
                Program.mainform.setStatusText("リロード完了");
                reloadButton.Enabled = true;
                Program.mainform.setServerStatus("online");
            }));
        }
    }
}
