﻿using CoreRCON;
using MC_Debug_Monitor.Controls;
using MC_Debug_Monitor.utils;
using System;
using System.Drawing;
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
            addTabPage("スコアボード", new ScoreboardMonitor());
            mainTabControl.SelectedIndex = 0;
            setStatusText("サーバーへ接続してください");
        }

        private void openTwitter(object sender, EventArgs e)
        {
            FixedProcess.openUrl("https://twitter.com/newkemo431");
        }

        private void openGitHub(object sender, EventArgs e)
        {
            FixedProcess.openUrl("https://github.com/kemo14331/MC-Debug-Monitor");
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void addTestTabClicked(object sender, EventArgs e)
        {
            addTabPage("テスト", new TestMonitor());
        }

        public void addDataTabClicked(object sender, EventArgs e)
        {
            addTabPage("データ", new DataViewer());
        }

        public void addRconConsoleClicked(object sender, EventArgs e)
        {
            addTabPage("コンソール", new RconConsole());
        }

        public void addTabPage(string title, RemovableControl control)
        {
            TabPage tabpage = new TabPage(title);
            tabpage.Size = new System.Drawing.Size(550, 330);
            tabpage.BackColor = Color.Snow;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            | AnchorStyles.Left
            | AnchorStyles.Right;
            control.Size = new System.Drawing.Size(550, 330);
            control.BackColor = Color.Transparent;
            control.TabIndex = mainTabControl.TabPages.Count;
            tabpage.Controls.Add(control);
            mainTabControl.TabPages.Add(tabpage);
            mainTabControl.SelectedIndex = (mainTabControl.TabCount - 1);
        }

        public void moveTab(int index)
        {
            mainTabControl.SelectedIndex = index;
        }

        public void closeTabClicked(object sender, EventArgs e)
        {
            int index = mainTabControl.SelectedIndex;
            if (index >= 2)
            {
                mainTabControl.SelectedIndex = index - 1;
                RemovableControl rmc = (RemovableControl)mainTabControl.TabPages[index].Controls[0];
                rmc.onClosedTab();
                mainTabControl.TabPages.RemoveAt(index);
                int i = 0;
                foreach (TabPage tp in mainTabControl.TabPages)
                {
                    tp.Controls[0].TabIndex = i;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("このタブは削除できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void versionInfoClicked(object sender, EventArgs e)
        {
            VersionInfoForm f = new VersionInfoForm();
            f.Show();
        }
    }
}
