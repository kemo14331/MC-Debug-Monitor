namespace MC_Debug_Monitor.Controls
{
    partial class ScoreboardMonitor
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
            this.scoreboardGroup = new System.Windows.Forms.GroupBox();
            this.controlGroup = new System.Windows.Forms.GroupBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.autoUpdateGroup = new System.Windows.Forms.GroupBox();
            this.autoUpdateIntervalBox = new System.Windows.Forms.NumericUpDown();
            this.useAutoUpdate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.plyComboBox = new System.Windows.Forms.ComboBox();
            this.objComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scoreboardView = new System.Windows.Forms.DataGridView();
            this.scoreboardGroup.SuspendLayout();
            this.controlGroup.SuspendLayout();
            this.autoUpdateGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoUpdateIntervalBox)).BeginInit();
            this.filterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoreboardView)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreboardGroup
            // 
            this.scoreboardGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreboardGroup.Controls.Add(this.controlGroup);
            this.scoreboardGroup.Controls.Add(this.autoUpdateGroup);
            this.scoreboardGroup.Controls.Add(this.filterGroupBox);
            this.scoreboardGroup.Controls.Add(this.scoreboardView);
            this.scoreboardGroup.Location = new System.Drawing.Point(0, 0);
            this.scoreboardGroup.Name = "scoreboardGroup";
            this.scoreboardGroup.Size = new System.Drawing.Size(550, 330);
            this.scoreboardGroup.TabIndex = 0;
            this.scoreboardGroup.TabStop = false;
            this.scoreboardGroup.Text = "スコアボード";
            // 
            // controlGroup
            // 
            this.controlGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.controlGroup.Controls.Add(this.updateButton);
            this.controlGroup.Controls.Add(this.exportButton);
            this.controlGroup.Location = new System.Drawing.Point(403, 234);
            this.controlGroup.Name = "controlGroup";
            this.controlGroup.Size = new System.Drawing.Size(141, 90);
            this.controlGroup.TabIndex = 3;
            this.controlGroup.TabStop = false;
            this.controlGroup.Text = "操作";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(6, 52);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(129, 23);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(6, 23);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(129, 23);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "エクスポート";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // autoUpdateGroup
            // 
            this.autoUpdateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoUpdateGroup.Controls.Add(this.autoUpdateIntervalBox);
            this.autoUpdateGroup.Controls.Add(this.useAutoUpdate);
            this.autoUpdateGroup.Controls.Add(this.label3);
            this.autoUpdateGroup.Location = new System.Drawing.Point(403, 151);
            this.autoUpdateGroup.Name = "autoUpdateGroup";
            this.autoUpdateGroup.Size = new System.Drawing.Size(141, 77);
            this.autoUpdateGroup.TabIndex = 2;
            this.autoUpdateGroup.TabStop = false;
            this.autoUpdateGroup.Text = "自動更新";
            // 
            // autoUpdateIntervalBox
            // 
            this.autoUpdateIntervalBox.Location = new System.Drawing.Point(66, 43);
            this.autoUpdateIntervalBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.autoUpdateIntervalBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.autoUpdateIntervalBox.Name = "autoUpdateIntervalBox";
            this.autoUpdateIntervalBox.Size = new System.Drawing.Size(69, 23);
            this.autoUpdateIntervalBox.TabIndex = 2;
            this.autoUpdateIntervalBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // useAutoUpdate
            // 
            this.useAutoUpdate.AutoSize = true;
            this.useAutoUpdate.Location = new System.Drawing.Point(6, 23);
            this.useAutoUpdate.Name = "useAutoUpdate";
            this.useAutoUpdate.Size = new System.Drawing.Size(69, 19);
            this.useAutoUpdate.TabIndex = 1;
            this.useAutoUpdate.Text = "使用する";
            this.useAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "間隔(ms)";
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGroupBox.Controls.Add(this.plyComboBox);
            this.filterGroupBox.Controls.Add(this.objComboBox);
            this.filterGroupBox.Controls.Add(this.label2);
            this.filterGroupBox.Controls.Add(this.label1);
            this.filterGroupBox.Location = new System.Drawing.Point(403, 23);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(141, 122);
            this.filterGroupBox.TabIndex = 1;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "フィルタ";
            // 
            // plyComboBox
            // 
            this.plyComboBox.FormattingEnabled = true;
            this.plyComboBox.Location = new System.Drawing.Point(14, 82);
            this.plyComboBox.Name = "plyComboBox";
            this.plyComboBox.Size = new System.Drawing.Size(121, 23);
            this.plyComboBox.TabIndex = 3;
            // 
            // objComboBox
            // 
            this.objComboBox.FormattingEnabled = true;
            this.objComboBox.Location = new System.Drawing.Point(14, 38);
            this.objComboBox.Name = "objComboBox";
            this.objComboBox.Size = new System.Drawing.Size(121, 23);
            this.objComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Objective";
            // 
            // scoreboardView
            // 
            this.scoreboardView.AllowUserToAddRows = false;
            this.scoreboardView.AllowUserToDeleteRows = false;
            this.scoreboardView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreboardView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scoreboardView.Location = new System.Drawing.Point(7, 23);
            this.scoreboardView.Name = "scoreboardView";
            this.scoreboardView.Size = new System.Drawing.Size(390, 301);
            this.scoreboardView.TabIndex = 0;
            this.scoreboardView.Text = "dataGridView1";
            // 
            // ScoreboardMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scoreboardGroup);
            this.Name = "ScoreboardMonitor";
            this.Size = new System.Drawing.Size(550, 330);
            this.scoreboardGroup.ResumeLayout(false);
            this.controlGroup.ResumeLayout(false);
            this.autoUpdateGroup.ResumeLayout(false);
            this.autoUpdateGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoUpdateIntervalBox)).EndInit();
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoreboardView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox scoreboardGroup;
        private System.Windows.Forms.GroupBox controlGroup;
        private System.Windows.Forms.GroupBox autoUpdateGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.ComboBox plyComboBox;
        private System.Windows.Forms.ComboBox objComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView scoreboardView;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.NumericUpDown autoUpdateIntervalBox;
        private System.Windows.Forms.CheckBox useAutoUpdate;
    }
}
