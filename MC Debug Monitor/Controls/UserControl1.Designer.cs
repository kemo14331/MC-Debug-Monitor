namespace MC_Debug_Monitor.Controls
{
    partial class serverManager
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.rconSetting = new System.Windows.Forms.GroupBox();
            this.getIPButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.rconPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rconPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rconIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverControl = new System.Windows.Forms.GroupBox();
            this.rconSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rconPort)).BeginInit();
            this.SuspendLayout();
            // 
            // rconSetting
            // 
            this.rconSetting.Controls.Add(this.getIPButton);
            this.rconSetting.Controls.Add(this.importButton);
            this.rconSetting.Controls.Add(this.rconPass);
            this.rconSetting.Controls.Add(this.label3);
            this.rconSetting.Controls.Add(this.rconPort);
            this.rconSetting.Controls.Add(this.label2);
            this.rconSetting.Controls.Add(this.rconIP);
            this.rconSetting.Controls.Add(this.label1);
            this.rconSetting.Location = new System.Drawing.Point(0, 0);
            this.rconSetting.Name = "rconSetting";
            this.rconSetting.Size = new System.Drawing.Size(219, 162);
            this.rconSetting.TabIndex = 0;
            this.rconSetting.TabStop = false;
            this.rconSetting.Text = "Rconの設定";
            // 
            // getIPButton
            // 
            this.getIPButton.Location = new System.Drawing.Point(181, 25);
            this.getIPButton.Name = "getIPButton";
            this.getIPButton.Size = new System.Drawing.Size(25, 25);
            this.getIPButton.TabIndex = 1;
            this.getIPButton.Image = MC_Debug_Monitor.Properties.Resources.earth;
            this.getIPButton.UseVisualStyleBackColor = true;
            this.getIPButton.Click += new System.EventHandler(this.getIPButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(138, 126);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "インポート";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // rconPass
            // 
            this.rconPass.Location = new System.Drawing.Point(76, 97);
            this.rconPass.Name = "rconPass";
            this.rconPass.Size = new System.Drawing.Size(130, 23);
            this.rconPass.TabIndex = 4;
            this.rconPass.Leave += new System.EventHandler(this.rconPassLeaved);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "パスワード";
            // 
            // rconPort
            // 
            this.rconPort.Location = new System.Drawing.Point(138, 62);
            this.rconPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.rconPort.Name = "rconPort";
            this.rconPort.Size = new System.Drawing.Size(68, 23);
            this.rconPort.TabIndex = 3;
            this.rconPort.Leave += new System.EventHandler(this.rconPortLeaved);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "ポート";
            // 
            // rconIP
            // 
            this.rconIP.Location = new System.Drawing.Point(76, 25);
            this.rconIP.Name = "rconIP";
            this.rconIP.Size = new System.Drawing.Size(99, 23);
            this.rconIP.TabIndex = 1;
            this.rconIP.Leave += new System.EventHandler(this.rconIPLeaved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IPアドレス";
            // 
            // serverControl
            // 
            this.serverControl.Location = new System.Drawing.Point(225, 1);
            this.serverControl.Name = "serverControl";
            this.serverControl.Size = new System.Drawing.Size(219, 84);
            this.serverControl.TabIndex = 1;
            this.serverControl.TabStop = false;
            this.serverControl.Text = "サーバー操作";
            // 
            // serverManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.serverControl);
            this.Controls.Add(this.rconSetting);
            this.Name = "serverManager";
            this.Size = new System.Drawing.Size(550, 330);
            this.Load += new System.EventHandler(this.scoreboardMonitor_Load);
            this.rconSetting.ResumeLayout(false);
            this.rconSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rconPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox rconSetting;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox rconPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown rconPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rconIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getIPButton;
        private System.Windows.Forms.GroupBox serverControl;
    }
}
