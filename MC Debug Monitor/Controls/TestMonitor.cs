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

namespace MC_Debug_Monitor.Controls
{
    public partial class TestMonitor : RemovableControl
    {

        public Color Mcolor = Color.FromArgb(255, 255, 0, 0);
        public DataTable tests = new DataTable();

        public TestMonitor()
        {
            InitializeComponent();
        }

        private void TestMonitor_Load(object sender, EventArgs e)
        {
            resultViewSetup();
            mergeTestButton.Enabled = false;
            deleteTestButton.Enabled = false;
            markerColor.Image = getMarkerImage(Mcolor);
            testControlGroup.Enabled = mainform.isConnectedServer;
        }

        public override void onConnectServer()
        {
            base.onConnectServer();
            testControlGroup.Enabled = false;
            enableHotkey.Enabled = true;
        }

        public override void onDisconnectServer()
        {
            base.onDisconnectServer();
            testControlGroup.Enabled = false;
            enableHotkey.Enabled = false;
        }

        private void resultViewSetup()
        {
            Bitmap bpm = new Bitmap(1, 1);
            tests.Columns.Add("M", bpm.GetType());
            tests.Columns.Add("Tilte");
            tests.Columns.Add("Command");
            tests.Columns.Add("Result");
            tests.AcceptChanges();
            testView.DataSource = tests;
            testView.Update();
            testView.Refresh();
            bpm.Dispose();

            Type dgvtype = typeof(DataGridView);

            testView.ColumnAdded += new DataGridViewColumnEventHandler((obj, a) =>
            {
                if (testView.Columns.Count >= 4)
                {
                    testView.Columns[0].FillWeight = 3;
                    testView.Columns[0].Width = 10;
                    testView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    testView.Columns[1].FillWeight = 10;
                    testView.Columns[2].FillWeight = 5;
                    testView.Columns[2].Visible = false;
                    testView.Columns[3].FillWeight = 50;
                }
            });

            testView.SizeChanged += new EventHandler((obj, a) => {
                testView.Columns[0].Width = 10;
            });

            // プロパティ設定の取得
            System.Reflection.PropertyInfo dgvPropertyInfo =
            dgvtype.GetProperty(
            "DoubleBuffered", System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic);

            dgvPropertyInfo.SetValue(testView, true, null);
        }

        private Bitmap getMarkerImage(Color color)
        {
            Bitmap bpm = new Bitmap(markerColor.Width, markerColor.Height);
            Graphics g = Graphics.FromImage(bpm);
            SolidBrush sb = new SolidBrush(color);
            g.FillRectangle(sb, 0, 0, markerColor.Width, markerColor.Height);
            g.DrawRectangle(new Pen(Brushes.Black), 0, 0, markerColor.Width - 1, markerColor.Height - 1);
            return bpm;
        }

        private void markerColor_Click(object sender, EventArgs e)
        {
            //ColorDialogクラスのインスタンスを作成
            ColorDialog cd = new ColorDialog();

            cd.Color = Mcolor;

            cd.SolidColorOnly = false;

            //ダイアログを表示する
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //選択された色の取得
                Mcolor = cd.Color;
                markerColor.Image = getMarkerImage(Mcolor);
            }
        }

        private void addTestButton_Click(object sender, EventArgs e)
        {
            tests.Rows.Add(markerColor.Image, title.Text, commandBox.Text, "");
        }

        private void updateEditTest(DataRow row)
        {
            markerColor.Image = (Bitmap)row[0];
            title.Text = (string)row[1];
            commandBox.Text = (string)row[2];
        }


        /// <summary>
        /// resultsのデータテーブルを一般的なデータテーブルに変換したものを返す
        /// </summary>
        private DataTable resultsToGDataTable(DataTable dtin)
        {
            DataTable newdt = new DataTable();
            newdt.Columns.Add("M");
            newdt.Columns.Add("Title");
            newdt.Columns.Add("Command");
            newdt.Columns.Add("Result");
            newdt.AcceptChanges();

            foreach(DataRow row in dtin.Rows)
            {
                Bitmap bmp = (Bitmap)row.ItemArray[0];
                Color color = bmp.GetPixel(2, 2);
                int Argb = color.ToArgb();
                newdt.Rows.Add(Argb, row[1], row[2], row[3]);
                bmp.Dispose();
            }

            newdt.AcceptChanges();
            return newdt;
        }

        /// <summary>
        /// 一般的なデータテーブルをresultsのデータテーブルに変換して返す
        /// </summary>
        private DataTable dataTableToResults(DataTable dtin)
        {
            DataTable newdt = new DataTable();
            Bitmap tmpbpm = new Bitmap(1, 1);
            newdt.Columns.Add("M", tmpbpm.GetType());
            newdt.Columns.Add("Title");
            newdt.Columns.Add("Command");
            newdt.Columns.Add("Result");
            newdt.AcceptChanges();
            tmpbpm.Dispose();

            foreach (DataRow row in dtin.Rows)
            {
                Int32 argb = (Int32)row.ItemArray[0];
                Color color = Color.FromArgb(argb);
                newdt.Rows.Add(getMarkerImage(color), row[1], row[2], row[3]);
            }

            newdt.AcceptChanges();
            return newdt;
        }

        private void testView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = testView.SelectedCells[0].RowIndex;
            testView.ClearSelection();
            testView.Rows[index].Selected = true;
            updateEditTest(((DataRowView)testView.Rows[index].DataBoundItem).Row);
        }

        private void mergeEditTest(int index)
        {
            tests.Rows[index][0] = markerColor.Image;
            tests.Rows[index][1] = title.Text;
            tests.Rows[index][2] = commandBox.Text;
            tests.Rows[index][3] = "";
            tests.AcceptChanges();
        }

        private void mergeTestButton_Click(object sender, EventArgs e)
        {
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
                    tests.Rows.Add(markerColor.Image, title.Text, commandBox.Text, "");
                    tests.AcceptChanges();
                }
            }
        }

        private void deleteTestButton_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)testView.SelectedRows[0].DataBoundItem).Row;
            int index = tests.Rows.IndexOf(dr);
            tests.Rows.RemoveAt(index);
            tests.AcceptChanges();
        }
    }
}
