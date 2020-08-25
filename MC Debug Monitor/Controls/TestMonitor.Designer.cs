namespace MC_Debug_Monitor.Controls
{
    partial class TestMonitor
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
            this.components = new System.ComponentModel.Container();
            this.testMonitorGroup = new System.Windows.Forms.GroupBox();
            this.hotkeyResister1 = new MC_Debug_Monitor.Controls.HotkeyResister();
            this.testView = new System.Windows.Forms.DataGridView();
            this.testControlGroup = new System.Windows.Forms.GroupBox();
            this.getRawResult = new System.Windows.Forms.CheckBox();
            this.runTestButton = new System.Windows.Forms.Button();
            this.fileGroup = new System.Windows.Forms.GroupBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.editGroup = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteTestButton = new System.Windows.Forms.Button();
            this.mergeTestButton = new System.Windows.Forms.Button();
            this.addTestButton = new System.Windows.Forms.Button();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.testViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.copyResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteTestMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openTestFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveTestFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.testMonitorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testView)).BeginInit();
            this.testControlGroup.SuspendLayout();
            this.fileGroup.SuspendLayout();
            this.editGroup.SuspendLayout();
            this.testViewMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // testMonitorGroup
            // 
            this.testMonitorGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testMonitorGroup.BackColor = System.Drawing.Color.Transparent;
            this.testMonitorGroup.Controls.Add(this.hotkeyResister1);
            this.testMonitorGroup.Controls.Add(this.testView);
            this.testMonitorGroup.Controls.Add(this.testControlGroup);
            this.testMonitorGroup.Controls.Add(this.fileGroup);
            this.testMonitorGroup.Controls.Add(this.editGroup);
            this.testMonitorGroup.Location = new System.Drawing.Point(0, 0);
            this.testMonitorGroup.Name = "testMonitorGroup";
            this.testMonitorGroup.Size = new System.Drawing.Size(550, 330);
            this.testMonitorGroup.TabIndex = 0;
            this.testMonitorGroup.TabStop = false;
            this.testMonitorGroup.Text = "テストの実行";
            // 
            // hotkeyResister1
            // 
            this.hotkeyResister1.Location = new System.Drawing.Point(291, 161);
            this.hotkeyResister1.Name = "hotkeyResister1";
            this.hotkeyResister1.Size = new System.Drawing.Size(253, 76);
            this.hotkeyResister1.TabIndex = 10;
            this.hotkeyResister1.HotKeyPush += new System.EventHandler(this.hotkeyResister1_HotKeyPush);
            this.hotkeyResister1.onHotKeyResister += new System.EventHandler(this.hotkeyResister1_onHotKeyResister);
            this.hotkeyResister1.onFaildHotKeyResister += new System.EventHandler(this.hotkeyResister1_onFaildHotKeyResister);
            this.hotkeyResister1.onHotKeyDisResister += new System.EventHandler(this.hotkeyResister1_onHotKeyDisResister);
            // 
            // testView
            // 
            this.testView.AllowUserToAddRows = false;
            this.testView.AllowUserToDeleteRows = false;
            this.testView.AllowUserToResizeRows = false;
            this.testView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.testView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.testView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testView.Location = new System.Drawing.Point(6, 22);
            this.testView.Name = "testView";
            this.testView.ReadOnly = true;
            this.testView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.testView.RowHeadersVisible = false;
            this.testView.Size = new System.Drawing.Size(278, 302);
            this.testView.TabIndex = 6;
            this.testView.Text = "dataGridView1";
            this.testView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.testView_CellClick);
            this.testView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.testView_CellMouseClick);
            this.testView.SelectionChanged += new System.EventHandler(this.testView_SelectionChanged);
            // 
            // testControlGroup
            // 
            this.testControlGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testControlGroup.Controls.Add(this.getRawResult);
            this.testControlGroup.Controls.Add(this.runTestButton);
            this.testControlGroup.Location = new System.Drawing.Point(423, 244);
            this.testControlGroup.Name = "testControlGroup";
            this.testControlGroup.Size = new System.Drawing.Size(121, 80);
            this.testControlGroup.TabIndex = 5;
            this.testControlGroup.TabStop = false;
            this.testControlGroup.Text = "テストの操作";
            // 
            // getRawResult
            // 
            this.getRawResult.AutoSize = true;
            this.getRawResult.Location = new System.Drawing.Point(6, 26);
            this.getRawResult.Name = "getRawResult";
            this.getRawResult.Size = new System.Drawing.Size(80, 19);
            this.getRawResult.TabIndex = 1;
            this.getRawResult.Text = "RawResult";
            this.getRawResult.UseVisualStyleBackColor = true;
            // 
            // runTestButton
            // 
            this.runTestButton.Location = new System.Drawing.Point(6, 51);
            this.runTestButton.Name = "runTestButton";
            this.runTestButton.Size = new System.Drawing.Size(109, 23);
            this.runTestButton.TabIndex = 0;
            this.runTestButton.Text = "テストの実行";
            this.runTestButton.UseVisualStyleBackColor = true;
            this.runTestButton.Click += new System.EventHandler(this.runTestButton_Click);
            // 
            // fileGroup
            // 
            this.fileGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileGroup.Controls.Add(this.exportButton);
            this.fileGroup.Controls.Add(this.importButton);
            this.fileGroup.Location = new System.Drawing.Point(291, 243);
            this.fileGroup.Name = "fileGroup";
            this.fileGroup.Size = new System.Drawing.Size(126, 81);
            this.fileGroup.TabIndex = 4;
            this.fileGroup.TabStop = false;
            this.fileGroup.Text = "ファイル";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(7, 53);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(113, 23);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "エクスポート";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(7, 23);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(113, 23);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "インポート";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // editGroup
            // 
            this.editGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editGroup.Controls.Add(this.textBox1);
            this.editGroup.Controls.Add(this.deleteTestButton);
            this.editGroup.Controls.Add(this.mergeTestButton);
            this.editGroup.Controls.Add(this.addTestButton);
            this.editGroup.Controls.Add(this.commandBox);
            this.editGroup.Controls.Add(this.title);
            this.editGroup.Controls.Add(this.label3);
            this.editGroup.Controls.Add(this.label2);
            this.editGroup.Controls.Add(this.label1);
            this.editGroup.Location = new System.Drawing.Point(291, 22);
            this.editGroup.Name = "editGroup";
            this.editGroup.Size = new System.Drawing.Size(253, 133);
            this.editGroup.TabIndex = 2;
            this.editGroup.TabStop = false;
            this.editGroup.Text = "テストの編集";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(51, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(70, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "未実装";
            // 
            // deleteTestButton
            // 
            this.deleteTestButton.Location = new System.Drawing.Point(6, 104);
            this.deleteTestButton.Name = "deleteTestButton";
            this.deleteTestButton.Size = new System.Drawing.Size(42, 23);
            this.deleteTestButton.TabIndex = 8;
            this.deleteTestButton.Text = "削除";
            this.deleteTestButton.UseVisualStyleBackColor = true;
            this.deleteTestButton.Click += new System.EventHandler(this.deleteTestButton_Click);
            // 
            // mergeTestButton
            // 
            this.mergeTestButton.Location = new System.Drawing.Point(92, 104);
            this.mergeTestButton.Name = "mergeTestButton";
            this.mergeTestButton.Size = new System.Drawing.Size(75, 23);
            this.mergeTestButton.TabIndex = 7;
            this.mergeTestButton.Text = "編集の適用";
            this.mergeTestButton.UseVisualStyleBackColor = true;
            this.mergeTestButton.Click += new System.EventHandler(this.mergeTestButton_Click);
            // 
            // addTestButton
            // 
            this.addTestButton.Location = new System.Drawing.Point(173, 104);
            this.addTestButton.Name = "addTestButton";
            this.addTestButton.Size = new System.Drawing.Size(75, 23);
            this.addTestButton.TabIndex = 5;
            this.addTestButton.Text = "追加";
            this.addTestButton.UseVisualStyleBackColor = true;
            this.addTestButton.Click += new System.EventHandler(this.addTestButton_Click);
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(51, 75);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(197, 23);
            this.commandBox.TabIndex = 4;
            this.commandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandBox_KeyDown);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(51, 46);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(90, 23);
            this.title.TabIndex = 3;
            this.title.KeyDown += new System.Windows.Forms.KeyEventHandler(this.title_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "コマンド";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "タイトル";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "タグ";
            // 
            // testViewMenu
            // 
            this.testViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCommand,
            this.copyResult,
            this.toolStripSeparator1,
            this.deleteTestMenu});
            this.testViewMenu.Name = "testViewMenu";
            this.testViewMenu.Size = new System.Drawing.Size(212, 76);
            // 
            // copyCommand
            // 
            this.copyCommand.Name = "copyCommand";
            this.copyCommand.Size = new System.Drawing.Size(211, 22);
            this.copyCommand.Text = "コマンドをクリップボードにコピー";
            this.copyCommand.Click += new System.EventHandler(this.copyCommand_Click);
            // 
            // copyResult
            // 
            this.copyResult.Name = "copyResult";
            this.copyResult.Size = new System.Drawing.Size(211, 22);
            this.copyResult.Text = "Resultをクリップボードにコピー";
            this.copyResult.Click += new System.EventHandler(this.copyResult_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // deleteTestMenu
            // 
            this.deleteTestMenu.Name = "deleteTestMenu";
            this.deleteTestMenu.Size = new System.Drawing.Size(211, 22);
            this.deleteTestMenu.Text = "テストの削除";
            this.deleteTestMenu.Click += new System.EventHandler(this.deleteTestButton_Click);
            // 
            // openTestFileDialog
            // 
            this.openTestFileDialog.Filter = "mcfunctionファイル|*.mcfunction|テストJSONファイル|*.json";
            this.openTestFileDialog.Title = "テストデータのインポート";
            // 
            // saveTestFileDialog
            // 
            this.saveTestFileDialog.FileName = "testdata.csv";
            this.saveTestFileDialog.Filter = "CSVファイル|*.csv|JSONファイル|*.json|MCFunction|*.mcfunction";
            this.saveTestFileDialog.Title = "テストデータのエクスポート";
            // 
            // TestMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testMonitorGroup);
            this.Name = "TestMonitor";
            this.Size = new System.Drawing.Size(550, 330);
            this.Load += new System.EventHandler(this.TestMonitor_Load);
            this.testMonitorGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testView)).EndInit();
            this.testControlGroup.ResumeLayout(false);
            this.testControlGroup.PerformLayout();
            this.fileGroup.ResumeLayout(false);
            this.editGroup.ResumeLayout(false);
            this.editGroup.PerformLayout();
            this.testViewMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox testMonitorGroup;
        private System.Windows.Forms.GroupBox editGroup;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addTestButton;
        private System.Windows.Forms.Button mergeTestButton;
        private System.Windows.Forms.GroupBox fileGroup;
        private System.Windows.Forms.GroupBox testControlGroup;
        private System.Windows.Forms.DataGridView testView;
        private System.Windows.Forms.CheckBox getRawResult;
        private System.Windows.Forms.Button runTestButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button deleteTestButton;
        private System.Windows.Forms.ContextMenuStrip testViewMenu;
        private System.Windows.Forms.ToolStripMenuItem copyCommand;
        private System.Windows.Forms.ToolStripMenuItem copyResult;
        private System.Windows.Forms.OpenFileDialog openTestFileDialog;
        private System.Windows.Forms.SaveFileDialog saveTestFileDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem deleteTestMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private HotkeyResister hotkeyResister1;
    }
}
