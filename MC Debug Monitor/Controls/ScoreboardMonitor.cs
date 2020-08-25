using MC_Debug_Monitor.Properties;
using MC_Debug_Monitor.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MC_Debug_Monitor.Program;

namespace MC_Debug_Monitor.Controls
{
    public partial class ScoreboardMonitor : RemovableControl
    {
        DataTable scoreboards = new DataTable();
        bool isScoreboardUpdateFinished = true;
        private System.Timers.Timer scoreboardTimer = new System.Timers.Timer();

        private BindingSource dataBinder = new BindingSource();
        private string[] playersCash = new string[0];
        private string[] objectivesCash = new string[0];


        public ScoreboardMonitor()
        {
            InitializeComponent();
        }

        private void ScoreboardMonitor_Load(object sender, EventArgs e)
        {
            scoreboardViewSetup();
            autoUpdateIntervalBox.Value = Settings.Default.scoreboardUpdateInterval;
            scoreboardTimer.Interval = (double)autoUpdateIntervalBox.Value;
            scoreboardTimer.Elapsed += onScoreboardTimerElapsed;
            filterSetup();
            setEnableControls(mainform.isConnectedServer);
        }

        private void setEnableControls(bool b)
        {
            autoUpdateGroup.Enabled = b;
            controlGroup.Enabled = b;
        }

        public override void onConnectServer()
        {
            setEnableControls(true);
        }

        public override void onDisconnectServer()
        {
            setEnableControls(false);
            useAutoUpdate.Checked = false;
        }

        private async void onScoreboardTimerElapsed(object sender, EventArgs args)
        {
            try
            {
                await updateScoreboard();
            }
            catch
            {
                Invoke((Action)(() =>
                {
                    mainform.setStatusText("スコアボードの更新中にエラーが発生しました");
                    useAutoUpdate.Checked = false;
                }));
                throw;
            }
        }

        private void scoreboardViewSetup()
        {
            scoreboards.Columns.Add("Objective");
            scoreboards.Columns.Add("Player");
            scoreboards.Columns.Add("Value");
            scoreboards.AcceptChanges();
            scoreboardView.DataSource = scoreboards;
            //scoreboardViewRebind();

            scoreboardView.Update();
            scoreboardView.Refresh();

            Type dgvtype = typeof(DataGridView);

            scoreboardView.ColumnAdded += new DataGridViewColumnEventHandler((obj, a) =>
            {
                if (scoreboardView.Columns.Count >= 3)
                {
                    scoreboardView.Columns[0].FillWeight = 16;
                    scoreboardView.Columns[1].FillWeight = 35;
                    scoreboardView.Columns[2].FillWeight = 6;
                }
            });

            // プロパティ設定の取得
            System.Reflection.PropertyInfo dgvPropertyInfo =
            dgvtype.GetProperty(
            "DoubleBuffered", System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic);

            dgvPropertyInfo.SetValue(scoreboardView, true, null);
        }

        private void scoreboardViewRebind()
        {
            dataBinder.DataSource = null;
            dataBinder.DataSource = scoreboards;
        }

        private void filterSetup()
        {
            plyComboBox.Items.Add("*");
            objComboBox.Items.Add("*");
            plyComboBox.SelectedIndex = 0;
            objComboBox.SelectedIndex = 0;
        }

        //追加だけ
        public void updateFilter(string[] objectives, string[] players)
        {
            //変更
            bool flag = false;
            foreach (string objective in objectives)
            {
                if (!objComboBox.Items.Contains(objective))
                {
                    flag = true;
                    objComboBox.Items.Add(objective);
                }
            }
            if (flag) sortFilter(objComboBox);
            flag = false;
            foreach (string player in players)
            {
                if (!plyComboBox.Items.Contains(player))
                {
                    flag = true;
                    plyComboBox.Items.Add(player);
                }
            }
            if (flag) sortFilter(plyComboBox);
        }

        //フィルタのソート
        public void sortFilter(ComboBox cm)
        {
            string nowSelecting = (string)cm.SelectedItem;
            List<string> items = new List<string> { };
            foreach (string item in cm.Items)
            {
                if (!item.Equals("*")) items.Add(item);
            }
            string[] itemsArray = items.ToArray();
            Array.Sort(itemsArray, new NaturalComparer(NaturalSortOrder.Ascending));
            cm.Items.Clear();
            cm.Items.Add("*");
            cm.Items.AddRange(itemsArray);
            int index = cm.Items.IndexOf(nowSelecting);
            if (index != -1)
            {
                cm.SelectedIndex = index;
            }
            else
            {
                cm.SelectedIndex = 0;
            }
        }

        private async Task updateScoreboard()
        {
            if (isScoreboardUpdateFinished)
            {
                isScoreboardUpdateFinished = false;
                string[] objectives = new string[0];
                string[] players = new string[0];
                await Task.Run(async () =>
                {
                    objectives = getObjectivesArray(await mainform.sendCommand("scoreboard objectives list"));
                    players = getEntitiesArray(await mainform.sendCommand("scoreboard players list"));
                    //objectivesにないobjectivesCashを削除
                    foreach (string objective in objectivesCash)
                    {
                        if (!objectives.Contains(objective))
                        {
                            //ついでに削除
                            Invoke((Action)(() =>
                            {
                                objComboBox.Items.Remove(objective);
                            }));
                            DataRow[] drs = scoreboards.Select("Objective='" + objective + "'");
                            foreach (DataRow dr in drs)
                            {
                                int index = scoreboards.Rows.IndexOf(dr);
                                Invoke((Action)(() =>
                                {
                                    scoreboards.Rows[index].Delete();
                                }));
                            }
                            scoreboards.AcceptChanges();
                        }

                    }

                    foreach (string player in playersCash)
                    {
                        if (!players.Contains(player))
                        {
                            //ついでに削除
                            Invoke((Action)(() =>
                            {
                                objComboBox.Items.Remove(player);
                            }));
                            DataRow[] drs = scoreboards.Select("Player='" + player + "'");
                            foreach (DataRow dr in drs)
                            {
                                int index = scoreboards.Rows.IndexOf(dr);
                                Invoke((Action)(() =>
                                {
                                    scoreboards.Rows[index].Delete();
                                }));
                            }
                            scoreboards.AcceptChanges();
                        }
                    }


                    //追加.または変更
                    foreach (string objective in objectives)
                    {
                        foreach (string player in players)
                        {
                            string result = await mainform.sendCommand("scoreboard players get " + player + " " + objective);
                            if (result.IndexOf("Can't") != -1)
                            {
                                continue;
                            }
                            int value = int.Parse(result.Split(' ')[2]);
                            DataRow[] dr = scoreboards.Select("Objective='" + objective + "' and Player='" + player + "'");
                            if (dr.Length == 0)
                            {
                                scoreboards.Rows.Add(objective, player, value);
                                scoreboards.AcceptChanges();
                                continue;
                            }
                            foreach (DataRow datarow in dr)
                            {
                                if (!datarow["Value"].Equals(value))
                                {
                                    int index = scoreboards.Rows.IndexOf(datarow);
                                    scoreboards.Rows[index]["Value"] = value;
                                    scoreboards.AcceptChanges();
                                }
                            }
                        }
                    }
                    Invoke((Action)(() =>
                    {
                        updateFilter(objectives, players);
                        runFilter();
                        scoreboardView.Update();
                        scoreboardView.Refresh();
                    }));
                    playersCash = (string[])players.Clone();
                    objectivesCash = (string[])objectives.Clone();
                });
                isScoreboardUpdateFinished = true;
            }
            scoreboards.AcceptChanges();
        }

        string[] getObjectivesArray(string input)
        {
            string keyword = "objectives:";
            int si = input.IndexOf(keyword);
            if (si != -1)
            {
                input = input.Substring(si + 1 + keyword.Length);
                return toCleanString(input).Split(',');
            }
            else
            {
                return new string[0];
            }
        }

        string[] getEntitiesArray(string input)
        {
            string keyword = "entities:";
            int si = input.IndexOf(keyword);
            if (si != -1)
            {
                input = input.Substring(si + 1 + keyword.Length);
                return toCleanString(input).Split(',');
            }
            else
            {
                return new string[0];
            }
        }

        string toCleanString(string input)
        {
            input = input.Replace(" ", "");
            input = input.Replace("[", "");
            input = input.Replace("]", "");
            return input;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await updateScoreboard();
            });
        }

        private void filterGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void runFilter()
        {
            scoreboards.DefaultView.RowFilter = string.Format("Objective LIKE '{0}' AND Player LIKE '{1}'",
               objComboBox.Text, plyComboBox.Text);
            scoreboards.AcceptChanges();
        }

        private void objComboBox_TextChanged(object sender, EventArgs e)
        {
            runFilter();
        }

        private void plyComboBox_TextChanged(object sender, EventArgs e)
        {
            runFilter();
        }

        private void autoUpdateIntervalBox_ValueChanged(object sender, EventArgs e)
        {
            scoreboardTimer.Interval = (double)autoUpdateIntervalBox.Value;
            Settings.Default.scoreboardUpdateInterval = autoUpdateIntervalBox.Value;
        }

        private void useAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            scoreboardTimer.Enabled = useAutoUpdate.Checked;
            autoUpdateIntervalBox.Enabled = !useAutoUpdate.Checked;
        }

        private void objComboBox_DataSourceChanged(object sender, EventArgs e)
        {
            sortFilter(objComboBox);
        }

        private void plyComboBox_DataSourceChanged(object sender, EventArgs e)
        {
            sortFilter(plyComboBox);
        }

        private void objComboBox_Leave(object sender, EventArgs e)
        {
            if (!objComboBox.Items.Contains(objComboBox.Text))
            {
                objComboBox.SelectedIndex = 0;
            }
        }

        private void plyComboBox_Leave(object sender, EventArgs e)
        {
            if (!plyComboBox.Items.Contains(plyComboBox.Text))
            {
                plyComboBox.SelectedIndex = 0;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "scoreboards.csv";
            sfd.AddExtension = true;
            sfd.Filter = "CSVファイル(*.csv)|*.csv|Jsonファイル(*.json)|*.json";
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                switch (Path.GetExtension(sfd.FileName))
                {
                    case ".csv":
                        FileUtil.saveDataTableToCSV(scoreboards, sfd.FileName);
                        break;
                    case ".json":
                        FileUtil.saveDataTableToJson(scoreboards, sfd.FileName);
                        break;
                }
            }
        }

        private void scoreboardView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
