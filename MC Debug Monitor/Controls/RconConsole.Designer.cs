namespace MC_Debug_Monitor.Controls
{
    partial class RconConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RconConsole));
            this.consoleBox = new System.Windows.Forms.GroupBox();
            this.fontbutton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.ConsoleView = new System.Windows.Forms.RichTextBox();
            this.consoleBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleBox
            // 
            this.consoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleBox.Controls.Add(this.fontbutton);
            this.consoleBox.Controls.Add(this.sendButton);
            this.consoleBox.Controls.Add(this.commandBox);
            this.consoleBox.Controls.Add(this.ConsoleView);
            this.consoleBox.Location = new System.Drawing.Point(0, 0);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(550, 330);
            this.consoleBox.TabIndex = 0;
            this.consoleBox.TabStop = false;
            this.consoleBox.Text = "Rconコンソール";
            // 
            // fontbutton
            // 
            this.fontbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontbutton.Image = ((System.Drawing.Image)(resources.GetObject("fontbutton.Image")));
            this.fontbutton.Location = new System.Drawing.Point(524, 22);
            this.fontbutton.Name = "fontbutton";
            this.fontbutton.Size = new System.Drawing.Size(20, 20);
            this.fontbutton.TabIndex = 13;
            this.fontbutton.UseVisualStyleBackColor = true;
            this.fontbutton.Click += new System.EventHandler(this.fontbutton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(488, 301);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(56, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "送信";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // commandBox
            // 
            this.commandBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.commandBox.ForeColor = System.Drawing.Color.White;
            this.commandBox.Location = new System.Drawing.Point(7, 301);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(475, 23);
            this.commandBox.TabIndex = 1;
            this.commandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandBox_KeyDown);
            // 
            // ConsoleView
            // 
            this.ConsoleView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ConsoleView.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleView.ForeColor = System.Drawing.Color.Lime;
            this.ConsoleView.Location = new System.Drawing.Point(7, 23);
            this.ConsoleView.Name = "ConsoleView";
            this.ConsoleView.ReadOnly = true;
            this.ConsoleView.Size = new System.Drawing.Size(537, 272);
            this.ConsoleView.TabIndex = 0;
            this.ConsoleView.Text = "";
            // 
            // RconConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.consoleBox);
            this.Name = "RconConsole";
            this.Size = new System.Drawing.Size(550, 330);
            this.Load += new System.EventHandler(this.RconConsole_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RconConsole_KeyDown);
            this.consoleBox.ResumeLayout(false);
            this.consoleBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox consoleBox;
        private System.Windows.Forms.RichTextBox ConsoleView;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Button fontbutton;
    }
}
