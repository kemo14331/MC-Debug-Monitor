using System;
using System.Diagnostics;

namespace MC_Debug_Monitor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.addTabMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestTab = new System.Windows.Forms.ToolStripMenuItem();
            this.addDataTab = new System.Windows.Forms.ToolStripMenuItem();
            this.editTabMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTab = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpGithubStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpTwitterStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.versionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.serverStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.serverPage = new System.Windows.Forms.TabPage();
            this.serverMonitor = new MC_Debug_Monitor.Controls.serverManager();
            this.scoreboardMonitorPage = new System.Windows.Forms.TabPage();
            this.scoreboardMonitor = new MC_Debug_Monitor.Controls.ScoreboardMonitor();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addRconConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.serverPage.SuspendLayout();
            this.scoreboardMonitorPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTabMenu,
            this.editTabMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(558, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // addTabMenu
            // 
            this.addTabMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTestTab,
            this.addDataTab,
            this.toolStripSeparator1,
            this.addRconConsole});
            this.addTabMenu.ForeColor = System.Drawing.Color.Black;
            this.addTabMenu.Name = "addTabMenu";
            this.addTabMenu.Size = new System.Drawing.Size(85, 20);
            this.addTabMenu.Text = "タブの追加(&F)";
            // 
            // addTestTab
            // 
            this.addTestTab.Name = "addTestTab";
            this.addTestTab.Size = new System.Drawing.Size(178, 22);
            this.addTestTab.Text = "テストを追加";
            this.addTestTab.Click += new System.EventHandler(this.addTestTabClicked);
            // 
            // addDataTab
            // 
            this.addDataTab.Name = "addDataTab";
            this.addDataTab.Size = new System.Drawing.Size(178, 22);
            this.addDataTab.Text = "データを追加";
            this.addDataTab.Click += new System.EventHandler(this.addDataTabClicked);
            // 
            // editTabMenu
            // 
            this.editTabMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTab});
            this.editTabMenu.ForeColor = System.Drawing.Color.Black;
            this.editTabMenu.Name = "editTabMenu";
            this.editTabMenu.Size = new System.Drawing.Size(85, 20);
            this.editTabMenu.Text = "タブの編集(&E)";
            // 
            // closeTab
            // 
            this.closeTab.Name = "closeTab";
            this.closeTab.Size = new System.Drawing.Size(131, 22);
            this.closeTab.Text = "タブを閉じる";
            this.closeTab.Click += new System.EventHandler(this.closeTabClicked);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jumpGithubStrip,
            this.jumpTwitterStrip,
            this.versionInfo});
            this.helpMenu.ForeColor = System.Drawing.Color.Black;
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(65, 20);
            this.helpMenu.Text = "ヘルプ(&H)";
            // 
            // jumpGithubStrip
            // 
            this.jumpGithubStrip.Name = "jumpGithubStrip";
            this.jumpGithubStrip.Size = new System.Drawing.Size(191, 22);
            this.jumpGithubStrip.Text = "バグ報告・要望(Github)";
            this.jumpGithubStrip.Click += new System.EventHandler(this.openGitHub);
            // 
            // jumpTwitterStrip
            // 
            this.jumpTwitterStrip.Name = "jumpTwitterStrip";
            this.jumpTwitterStrip.Size = new System.Drawing.Size(191, 22);
            this.jumpTwitterStrip.Text = "Kemo\'s Twitter";
            this.jumpTwitterStrip.Click += new System.EventHandler(this.openTwitter);
            // 
            // versionInfo
            // 
            this.versionInfo.Name = "versionInfo";
            this.versionInfo.Size = new System.Drawing.Size(191, 22);
            this.versionInfo.Text = "バージョン情報";
            this.versionInfo.Click += new System.EventHandler(this.versionInfoClicked);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverStatusLabel,
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 385);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(558, 24);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = false;
            this.serverStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.serverStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverStatusLabel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(80, 19);
            this.serverStatusLabel.Text = "server";
            this.serverStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(70, 19);
            this.statusLabel.Text = "Initializing...";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.serverPage);
            this.mainTabControl.Controls.Add(this.scoreboardMonitorPage);
            this.mainTabControl.Location = new System.Drawing.Point(0, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(558, 358);
            this.mainTabControl.TabIndex = 2;
            // 
            // serverPage
            // 
            this.serverPage.Controls.Add(this.serverMonitor);
            this.serverPage.Location = new System.Drawing.Point(4, 24);
            this.serverPage.Name = "serverPage";
            this.serverPage.Padding = new System.Windows.Forms.Padding(3);
            this.serverPage.Size = new System.Drawing.Size(550, 330);
            this.serverPage.TabIndex = 0;
            this.serverPage.Text = "サーバー";
            this.serverPage.UseVisualStyleBackColor = true;
            // 
            // serverMonitor
            // 
            this.serverMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverMonitor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.serverMonitor.Location = new System.Drawing.Point(0, 0);
            this.serverMonitor.Name = "serverMonitor";
            this.serverMonitor.Size = new System.Drawing.Size(550, 330);
            this.serverMonitor.TabIndex = 0;
            // 
            // scoreboardMonitorPage
            // 
            this.scoreboardMonitorPage.Controls.Add(this.scoreboardMonitor);
            this.scoreboardMonitorPage.Location = new System.Drawing.Point(4, 24);
            this.scoreboardMonitorPage.Name = "scoreboardMonitorPage";
            this.scoreboardMonitorPage.Padding = new System.Windows.Forms.Padding(3);
            this.scoreboardMonitorPage.Size = new System.Drawing.Size(550, 330);
            this.scoreboardMonitorPage.TabIndex = 1;
            this.scoreboardMonitorPage.Text = "スコアボード";
            this.scoreboardMonitorPage.UseVisualStyleBackColor = true;
            // 
            // scoreboardMonitor
            // 
            this.scoreboardMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreboardMonitor.BackColor = System.Drawing.Color.Transparent;
            this.scoreboardMonitor.Location = new System.Drawing.Point(0, 0);
            this.scoreboardMonitor.Name = "scoreboardMonitor";
            this.scoreboardMonitor.Size = new System.Drawing.Size(550, 330);
            this.scoreboardMonitor.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // addRconConsole
            // 
            this.addRconConsole.Name = "addRconConsole";
            this.addRconConsole.Size = new System.Drawing.Size(178, 22);
            this.addRconConsole.Text = "Rconコンソールを追加";
            this.addRconConsole.Click += new EventHandler(this.addRconConsoleClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 409);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MC Debug Monitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.serverPage.ResumeLayout(false);
            this.scoreboardMonitorPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem addTabMenu;
        private System.Windows.Forms.ToolStripMenuItem editTabMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel serverStatusLabel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage scoreboardMonitorPage;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem closeTab;
        private System.Windows.Forms.TabPage serverPage;
        private Controls.serverManager serverMonitor;
        private Controls.ScoreboardMonitor scoreboardMonitor;
        private System.Windows.Forms.ToolStripMenuItem addTestTab;
        private System.Windows.Forms.ToolStripMenuItem versionInfo;
        private System.Windows.Forms.ToolStripMenuItem jumpGithubStrip;
        private System.Windows.Forms.ToolStripMenuItem jumpTwitterStrip;
        private System.Windows.Forms.ToolStripMenuItem addDataTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addRconConsole;
    }
}

