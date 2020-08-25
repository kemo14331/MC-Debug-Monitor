namespace MC_Debug_Monitor.Controls
{
    partial class dataViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hotkeySettingGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.enableHotkey = new System.Windows.Forms.CheckBox();
            this.Alt = new System.Windows.Forms.CheckBox();
            this.Shift = new System.Windows.Forms.CheckBox();
            this.Ctrl = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataView.SuspendLayout();
            this.hotkeySettingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.Controls.Add(this.button2);
            this.dataView.Controls.Add(this.button1);
            this.dataView.Controls.Add(this.label5);
            this.dataView.Controls.Add(this.richTextBox1);
            this.dataView.Controls.Add(this.hotkeySettingGroup);
            this.dataView.Controls.Add(this.textBox1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "data getコマンドを貼り付けてください";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 23);
            this.textBox1.TabIndex = 5;
            // 
            // hotkeySettingGroup
            // 
            this.hotkeySettingGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hotkeySettingGroup.Controls.Add(this.label4);
            this.hotkeySettingGroup.Controls.Add(this.maskedTextBox1);
            this.hotkeySettingGroup.Controls.Add(this.enableHotkey);
            this.hotkeySettingGroup.Controls.Add(this.Alt);
            this.hotkeySettingGroup.Controls.Add(this.Shift);
            this.hotkeySettingGroup.Controls.Add(this.Ctrl);
            this.hotkeySettingGroup.Location = new System.Drawing.Point(290, 22);
            this.hotkeySettingGroup.Name = "hotkeySettingGroup";
            this.hotkeySettingGroup.Size = new System.Drawing.Size(254, 76);
            this.hotkeySettingGroup.TabIndex = 6;
            this.hotkeySettingGroup.TabStop = false;
            this.hotkeySettingGroup.Text = "ホットキーの設定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Key:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(182, 45);
            this.maskedTextBox1.Mask = ">L";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(22, 23);
            this.maskedTextBox1.TabIndex = 4;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enableHotkey
            // 
            this.enableHotkey.AutoSize = true;
            this.enableHotkey.Location = new System.Drawing.Point(6, 22);
            this.enableHotkey.Name = "enableHotkey";
            this.enableHotkey.Size = new System.Drawing.Size(121, 19);
            this.enableHotkey.TabIndex = 3;
            this.enableHotkey.Text = "ホットキーを使用する";
            this.enableHotkey.UseVisualStyleBackColor = true;
            // 
            // Alt
            // 
            this.Alt.AutoSize = true;
            this.Alt.Location = new System.Drawing.Point(100, 47);
            this.Alt.Name = "Alt";
            this.Alt.Size = new System.Drawing.Size(41, 19);
            this.Alt.TabIndex = 2;
            this.Alt.Text = "Alt";
            this.Alt.UseVisualStyleBackColor = true;
            // 
            // Shift
            // 
            this.Shift.AutoSize = true;
            this.Shift.Location = new System.Drawing.Point(51, 47);
            this.Shift.Name = "Shift";
            this.Shift.Size = new System.Drawing.Size(50, 19);
            this.Shift.TabIndex = 1;
            this.Shift.Text = "Shift";
            this.Shift.UseVisualStyleBackColor = true;
            // 
            // Ctrl
            // 
            this.Ctrl.AutoSize = true;
            this.Ctrl.Location = new System.Drawing.Point(6, 47);
            this.Ctrl.Name = "Ctrl";
            this.Ctrl.Size = new System.Drawing.Size(44, 19);
            this.Ctrl.TabIndex = 0;
            this.Ctrl.Text = "Ctrl";
            this.Ctrl.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 125);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(537, 199);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "実行";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "コピー";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataView);
            this.Name = "dataViewer";
            this.Size = new System.Drawing.Size(550, 330);
            this.dataView.ResumeLayout(false);
            this.dataView.PerformLayout();
            this.hotkeySettingGroup.ResumeLayout(false);
            this.hotkeySettingGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox dataView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox hotkeySettingGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.CheckBox enableHotkey;
        private System.Windows.Forms.CheckBox Alt;
        private System.Windows.Forms.CheckBox Shift;
        private System.Windows.Forms.CheckBox Ctrl;
    }
}
