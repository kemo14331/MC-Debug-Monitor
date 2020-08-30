using System;
using System.ComponentModel;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace UpdateTool
{
    public partial class updateForm : Form
    {
        public updateForm()
        {
            InitializeComponent();
        }
        private void startDownload()
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(UpdateManager.downloadURL), @"./temp/newVersion.zip");
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                statusLabel.Text = "ダウンロード中: " + e.BytesReceived + "/" + e.TotalBytesToReceive;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                statusLabel.Text = "完了";
                start_Extract();
            });
        }

        private void start_Extract()
        {
            Thread thread = new Thread(() => {
                this.BeginInvoke((MethodInvoker)delegate {
                    statusLabel.Text = "解凍しています";
                });
                ZipFile.ExtractToDirectory("./temp/newVersion.zip", "./temp/ext", true);
                this.BeginInvoke((MethodInvoker)delegate {
                    statusLabel.Text = "完了";
                    start_Copy();
                });
            });
            thread.Start();
        }

        private void start_Copy()
        {
            Thread thread = new Thread(() => {
                string[] files = Directory.GetFiles("./temp/ext", "*", SearchOption.AllDirectories);
                int index = 0;
                foreach (string file in files)
                {
                    this.BeginInvoke((MethodInvoker)delegate {
                        statusLabel.Text = "コピー中: " + index + "/" + files.Length;
                        progressBar1.Value = (int)((index / files.Length * 1.0) * 100);
                        if (!file.Contains("Update"))
                        {
                            try
                            {
                                string destFile = file.Replace("temp/ext", "");
                                string distDir = Path.GetDirectoryName(destFile);
                                if (!Directory.Exists(distDir)) Directory.CreateDirectory(distDir);
                                File.Copy(file, destFile, true);
                            }
                            catch
                            {

                            }
                        }
                    });
                    index++;
                }
                this.BeginInvoke((MethodInvoker)delegate {
                    statusLabel.Text = "完了";
                    this.Close();
                });
            });
            thread.Start();
        }

        private void updateForm_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("./temp");
            Directory.CreateDirectory("./temp/ext");
            startDownload();
        }
    }
}
