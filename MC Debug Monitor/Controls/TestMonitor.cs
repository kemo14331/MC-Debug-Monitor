using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Configuration;
using System.Numerics;
using static MC_Debug_Monitor.Program;
using MC_Debug_Monitor.utils;
using System.IO;

namespace MC_Debug_Monitor.Controls
{
    public partial class TestMonitor : RemovableControl
    {

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        public Color Mcolor = Color.FromArgb(255, 255, 0, 0);
        public DataTable tests = new DataTable();

        private Keys hotKeyCode;
        private HotKey hotkey;


        public TestMonitor()
        {
            InitializeComponent();
        }

        private void TestMonitor_Load(object sender, EventArgs e)
        {
            resultViewSetup();
            mergeTestButton.Enabled = false;
            deleteTestButton.Enabled = false;
            enableHotkey.Enabled = false;
            Ctrl.Checked = true;
            testControlGroup.Enabled = mainform.isConnectedServer;
        }

        public override void onConnectServer()
        {
            base.onConnectServer();
            testControlGroup.Enabled = true;
        }

        public override void onDisconnectServer()
        {
            base.onDisconnectServer();
            testControlGroup.Enabled = false;
        }

        private void resultViewSetup()
        {
            tests.Columns.Add("Title");
            tests.Columns.Add("Command");
            tests.Columns.Add("Result");
            tests.AcceptChanges();
            testView.DataSource = tests;
            foreach (DataGridViewColumn c in testView.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            testView.Update();
            testView.Refresh();

            Type dgvtype = typeof(DataGridView);

            testView.ColumnAdded += new DataGridViewColumnEventHandler((obj, a) =>
            {
                if (testView.Columns.Count >= 3)
                {
                    testView.Columns[0].FillWeight = 10;
                    testView.Columns[1].FillWeight = 5;
                    testView.Columns[1].Visible = false;
                    testView.Columns[2].FillWeight = 50;
                }
            });

            // プロパティ設定の取得
            System.Reflection.PropertyInfo dgvPropertyInfo =
            dgvtype.GetProperty(
            "DoubleBuffered", System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic);

            dgvPropertyInfo.SetValue(testView, true, null);
        }

        private void addTestButton_Click(object sender,  EventArgs e)
        {
            if (commandBox.Text.Length > 2)
            {
                tests.Rows.Add(title.Text, commandBox.Text, " ");
                commandBox.Text = "";
                title.Text = "";
            }
            else
            {
                MessageBox.Show("コマンドを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateEditTest(DataRow row)
        {
            title.Text = (string)row["Title"];
            commandBox.Text = (string)row["Command"];
        }

        private void testView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (testView.SelectedCells.Count > 0)
            {
                int index = testView.SelectedCells[0].RowIndex;
                testView.ClearSelection();
                testView.Rows[index].Selected = true;
                updateEditTest(((DataRowView)testView.Rows[index].DataBoundItem).Row);
            }
        }

        private void mergeEditTest(int index)
        {
            tests.Rows[index]["Title"] = title.Text;
            tests.Rows[index]["Command"] = commandBox.Text;
            tests.Rows[index]["Result"] = " ";
            tests.AcceptChanges();
        }

        private void mergeTestButton_Click(object sender, EventArgs e)
        {
            if(commandBox.Text.Length < 2)
            {
                MessageBox.Show("コマンドを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (testView.SelectedRows.Count > 0)
            {
                DataRow dr = ((DataRowView)testView.SelectedRows[0].DataBoundItem).Row;
                int index = tests.Rows.IndexOf(dr);
                mergeEditTest(index);
            }
        }

        private void testView_SelectionChanged(object sender, EventArgs e)
        {
            if(testView.SelectedRows.Count > 0)
            {
                mergeTestButton.Enabled = true;
                deleteTestButton.Enabled = true;
            } else
            {
                mergeTestButton.Enabled = false;
                deleteTestButton.Enabled = false;
            }
        }

        private void title_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                commandBox.Focus();
            }
        }

        private void commandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mergeTestButton.Enabled)
                {
                    DataRow dr = ((DataRowView)testView.SelectedRows[0].DataBoundItem).Row;
                    int index = tests.Rows.IndexOf(dr);
                    mergeEditTest(index);
                }
                else
                {
                    tests.Rows.Add(title.Text, commandBox.Text, " ");
                    tests.AcceptChanges();
                }
                commandBox.Text = "";
                title.Text = "";
            }
        }

        private void deleteTestButton_Click(object sender, EventArgs e)
        {
            deleteTest();
        }

        private void deleteTest()
        {
            DataRow dr = ((DataRowView)testView.SelectedRows[0].DataBoundItem).Row;
            int index = tests.Rows.IndexOf(dr);
            tests.Rows.RemoveAt(index);
            testView.ClearSelection();
            if (index > 0) testView.Rows[index - 1].Selected = true;
            tests.AcceptChanges();
            commandBox.Text = "";
            title.Text = "";
            mainform.setStatusText("テストを削除しました");
        }

        private void runTestButton_Click(object sender, EventArgs e)
        {
            runTest();
        }

        private async void runTest()
        {
            try {
                sw.Reset();
                sw.Start();
                int index = 0;
                foreach (DataRow row in tests.Rows)
                {
                    string result = await mainform.sendCommand((string)row["Command"]);
                    if (!getRawResult.Checked) result = MCCommand.getResultString(result);
                    tests.Rows[index]["Result"] = result;
                    tests.AcceptChanges();
                    index++;
                }
                sw.Stop();
                Invoke((Action)(() => {
                    mainform.setStatusText(String.Format("{0}個のテストを実行しました({1}ms)", tests.Rows.Count, sw.ElapsedMilliseconds));
                }));
            }
            catch
            {
                MessageBox.Show("テストの実行に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyCommand_Click(object sender, EventArgs e)
        {
            if(testView.SelectedRows.Count > 0)
            {
                DataRow dr = ((DataRowView)testView.SelectedRows[0].DataBoundItem).Row;
                int index = tests.Rows.IndexOf(dr);
                Clipboard.SetText((string)tests.Rows[index]["Command"]);
                mainform.setStatusText("コマンドをクリップボードにコピーしました");
            }
        }

        private void copyResult_Click(object sender, EventArgs e)
        {
            if (testView.SelectedRows.Count > 0)
            {
                DataRow dr = ((DataRowView)testView.SelectedRows[0].DataBoundItem).Row;
                int index = tests.Rows.IndexOf(dr);
                Clipboard.SetText((string)tests.Rows[index]["Result"]);
                mainform.setStatusText("結果をクリップボードにコピーしました");
            }
        }

        private void testView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                testViewMenu.Show(MousePosition);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = openTestFileDialog;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (Path.GetExtension(ofd.FileName))
                    {
                        case ".mcfunction":
                            tests.Clear();
                            tests.Merge(FileUtil.loadTestDataFromMCF(ofd.OpenFile()));
                            tests.AcceptChanges();
                            break;
                        case ".json":
                            tests.Clear();
                            tests.Merge(FileUtil.loadTestDataFromJson(ofd.OpenFile()));
                            tests.AcceptChanges();
                            break;
                    }
                    mainform.setStatusText(String.Format("インポート完了: {0}項目", tests.Rows.Count));
                }
                catch
                {
                    MessageBox.Show("ファイルのインポートに失敗しました。\nファイルが正しいか確認してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = saveTestFileDialog;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                switch (Path.GetExtension(sfd.FileName))
                {
                    case ".csv":
                        FileUtil.saveDataTableToCSV(tests, sfd.FileName);
                        break;
                    case ".mcfunction":
                        FileUtil.saveTestDataToMCF(tests, sfd.OpenFile());
                        break;
                    case ".json":
                        FileUtil.saveDataTableToJson(tests, sfd.FileName);
                        break;
                }
                mainform.setStatusText(String.Format("エクスポート完了: {0}項目", tests.Rows.Count));
            }
        }

        private void enableHotkey_CheckedChanged(object sender, EventArgs e)
        {
            if (enableHotkey.Checked)
            {
                MOD_KEY modkey = MOD_KEY.CONTROL;
                if (Alt.Checked) modkey |= MOD_KEY.ALT;
                if (Shift.Checked) modkey |= MOD_KEY.SHIFT;
                hotkey = new HotKey(modkey, hotKeyCode);
                if (hotkey.OK)
                {
                    hotkey.HotKeyPush += new EventHandler((obj, e) => {
                        if (mainform.isConnectedServer) runTest();
                    });
                    Alt.Enabled = false;
                    Shift.Enabled = false;
                    Ctrl.Enabled = false;
                    mainform.setStatusText("ホットキーを登録しました");
                }
                else
                {
                    enableHotkey.Checked = false;
                    System.Media.SystemSounds.Beep.Play();
                    mainform.setStatusText("ホットキーはすでに登録されています");
                }
            }
            else
            {
                Alt.Enabled = true;
                Shift.Enabled = true;
                Ctrl.Enabled = true;
                hotkey.Dispose();
                mainform.setStatusText("ホットキーの登録を解除しました");
            }
        }

        private void Ctrl_CheckedChanged(object sender, EventArgs e)
        {
            Ctrl.Checked = true;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text.Length > 0)
            {
                enableHotkey.Enabled = true;
                hotKeyCode = (Keys)Enum.Parse(typeof(Keys), maskedTextBox1.Text[0].ToString(), ignoreCase: true);
            }
            else
            {
                enableHotkey.Enabled = false;
            }
        }

        public override void onClosedTab()
        {
            if (hotkey != null) hotkey.Dispose();
        }
    }
}
