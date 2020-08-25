namespace MC_Debug_Monitor.Controls
{
    partial class HotkeyResister
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
            this.hotkeySettingGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.enableHotkey = new System.Windows.Forms.CheckBox();
            this.Alt = new System.Windows.Forms.CheckBox();
            this.Shift = new System.Windows.Forms.CheckBox();
            this.Ctrl = new System.Windows.Forms.CheckBox();
            this.hotkeySettingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotkeySettingGroup
            // 
            this.hotkeySettingGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotkeySettingGroup.Controls.Add(this.label4);
            this.hotkeySettingGroup.Controls.Add(this.maskedTextBox1);
            this.hotkeySettingGroup.Controls.Add(this.enableHotkey);
            this.hotkeySettingGroup.Controls.Add(this.Alt);
            this.hotkeySettingGroup.Controls.Add(this.Shift);
            this.hotkeySettingGroup.Controls.Add(this.Ctrl);
            this.hotkeySettingGroup.Location = new System.Drawing.Point(0, 0);
            this.hotkeySettingGroup.Name = "hotkeySettingGroup";
            this.hotkeySettingGroup.Size = new System.Drawing.Size(239, 76);
            this.hotkeySettingGroup.TabIndex = 7;
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
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
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
            this.enableHotkey.CheckedChanged += new System.EventHandler(this.enableHotkey_CheckedChanged);
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
            this.Ctrl.CheckedChanged += new System.EventHandler(this.Ctrl_CheckedChanged);
            // 
            // HotkeyResister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hotkeySettingGroup);
            this.Name = "HotkeyResister";
            this.Size = new System.Drawing.Size(239, 76);
            this.Load += new System.EventHandler(this.HotkeyResister_Load);
            this.hotkeySettingGroup.ResumeLayout(false);
            this.hotkeySettingGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox hotkeySettingGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.CheckBox enableHotkey;
        private System.Windows.Forms.CheckBox Alt;
        private System.Windows.Forms.CheckBox Shift;
        private System.Windows.Forms.CheckBox Ctrl;
    }
}
