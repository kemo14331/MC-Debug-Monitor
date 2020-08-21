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
        //event
        public Action onRconConnect = new Action(() => { });
        public Action onRconDisconnect = new Action(() => { });

        public MainForm()
        {
            InitializeComponent();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void setStatusText(string msg)
        {
            statusLabel.Text = msg;
        }

        public void setServerStatus(string status)
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
                    var adr = IPAddress.Parse(Properties.Settings.Default.rconIP);
                    rcon = new RCON(adr, (ushort)Properties.Settings.Default.rconPort, Properties.Settings.Default.rconPass);
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

        public async Task<string> sendCommand(string command)
        {
            try
            {
                if (isConnectedServer)
                {
                    string result = await rcon.SendCommandAsync(command);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void onDisconnectServer()
        {
            if (rcon != null) { try { rcon.Dispose(); } catch { } }
            setServerStatus("offline");
            isConnectedServer = false;
            statusLabel.Text = "サーバーとの接続が切断されました";
            onRconDisconnect();
        }

        public void onConnectServer()
        {
            setServerStatus("online");
            isConnectedServer = true;
            onRconConnect();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            onDisconnectServer();
        }
    }
}
