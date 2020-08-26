namespace MC_Debug_Monitor.Controls
{
    partial class DataViewer
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
            this.dataView = new System.Windows.Forms.GroupBox();
            this.hotkeyResister1 = new MC_Debug_Monitor.Controls.HotkeyResister();
            this.copyButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataView.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataView.Controls.Add(this.hotkeyResister1);
            this.dataView.Controls.Add(this.copyButton);
            this.dataView.Controls.Add(this.runButton);
            this.dataView.Controls.Add(this.label5);
            this.dataView.Controls.Add(this.resultBox);
            this.dataView.Controls.Add(this.commandBox);
            this.dataView.Controls.Add(this.label3);
            this.dataView.Controls.Add(this.label2);
            this.dataView.Controls.Add(this.label1);
            this.dataView.Location = new System.Drawing.Point(0, 0);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(550, 330);
            this.dataView.TabIndex = 0;
            this.dataView.TabStop = false;
            this.dataView.Text = "データ";
            // 
            // hotkeyResister1
            // 
            this.hotkeyResister1.Location = new System.Drawing.Point(305, 18);
            this.hotkeyResister1.Name = "hotkeyResister1";
            this.hotkeyResister1.Size = new System.Drawing.Size(239, 76);
            this.hotkeyResister1.TabIndex = 11;
            this.hotkeyResister1.HotKeyPush += new System.EventHandler(this.hotkeyResister1_HotKeyPush);
            this.hotkeyResister1.onHotKeyResister += new System.EventHandler(this.hotkeyResister1_onHotKeyResister);
            this.hotkeyResister1.onFaildHotKeyResister += new System.EventHandler(this.hotkeyResister1_onFaildHotKeyResister);
            this.hotkeyResister1.onHotKeyDisResister += new System.EventHandler(this.hotkeyResister1_onHotKeyDisResister);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(469, 100);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 10;
            this.copyButton.Text = "コピー";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(209, 75);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 9;
            this.runButton.Text = "実行";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Result";
            // 
            // resultBox
            // 
            this.resultBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.resultBox.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.resultBox.Location = new System.Drawing.Point(7, 125);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(537, 199);
            this.resultBox.TabIndex = 7;
            this.resultBox.Text = "";
            this.resultBox.WordWrap = false;
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(7, 42);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(277, 23);
            this.commandBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "data getコマンドを貼り付けてください";
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataView);
            this.Name = "DataViewer";
            this.Size = new System.Drawing.Size(550, 330);
            this.Load += new System.EventHandler(this.dataViewer_Load);
            this.dataView.ResumeLayout(false);
            this.dataView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox dataView;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox resultBox;
        private HotkeyResister hotkeyResister1;
    }
}
