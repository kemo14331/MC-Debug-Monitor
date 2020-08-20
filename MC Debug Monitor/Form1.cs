using CoreRCON;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Debug_Monitor
{
    public partial class MainForm : Form
    {
        public RCON rcon;
        public bool isConnectedServer = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void setServerStatus(string status)
        {
            switch (status)
            {
                case "online":
                    this.serverStatusLabel.Image = Properties.Resources.online;
                    this.serverStatusLabel.Text = "online";
                    break;
                case "offline":
                    this.serverStatusLabel.Image = Properties.Resources.offline;
                    this.serverStatusLabel.Text = "offline";
                    break;
                case "reloading":
                    this.serverStatusLabel.Image = Properties.Resources.reloading;
                    this.serverStatusLabel.Text = "reloading";
                    break;
            }
        }

        public async Task tryConnectServer()
        {
            try
            {
                statusLabel.Text = "サーバーに接続中...";
                await Task.Run(async () =>
                {
                    var adr = IPAddress.Parse(Properties.Settings1.Default.rconIP);
                    rcon = new RCON(adr, (ushort)Properties.Settings1.Default.rconPort, Properties.Settings1.Default.rconPass);
                    await rcon.ConnectAsync();
                });
                rcon.OnDisconnected += (() =>
                {
                    Invoke((Action)(() =>
                    {
                        onDisconnectServer();
                    }));
                });
                statusLabel.Text = "サーバーに接続しました";
                onConnectServer();
            }
            catch
            {
                statusLabel.Text = "サーバーとの接続に失敗";
                MessageBox.Show("サーバーとの接続に失敗しました。\nRconの設定を確認してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void onDisconnectServer()
        {
            if (rcon != null) { try { rcon.Dispose(); } catch { } }
            setServerStatus("offline");
            isConnectedServer = false;
            statusLabel.Text = "サーバーとの接続が切断されました";
        }

        public void onConnectServer()
        {
            setServerStatus("online");
            isConnectedServer = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            onDisconnectServer();
        }
    }
}
