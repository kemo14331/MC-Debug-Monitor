using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Net;
using System.Windows.Forms;
using MC_Debug_Monitor.Properties;
using System.Resources;

namespace MC_Debug_Monitor.Controls
{
    public partial class serverManager : UserControl
    {
        public serverManager()
        {
            InitializeComponent();
        }

        private void rconIPLeaved(object sender, EventArgs e)
        {
            try
            {
                IPAddress.Parse(rconIP.Text);
            }
            catch
            {
                rconIP.Text = Settings1.Default.rconIP;
                System.Media.SystemSounds.Beep.Play();
            }
            saveAllSettings();
        }

        private void rconPortLeaved(object sender, EventArgs e)
        {
            saveAllSettings();
        }

        private void rconPassLeaved(object sender, EventArgs e)
        {
            saveAllSettings();
        }

        private void scoreboardMonitor_Load(object sender, EventArgs e)
        {
            rconIP.Text = Settings1.Default.rconIP;
            rconPort.Value = Settings1.Default.rconPort;
            rconPass.Text = Settings1.Default.rconPass;
        }

        private void saveAllSettings()
        {
            Settings1.Default.rconIP = rconIP.Text;
            Settings1.Default.rconPass = rconPass.Text;
            Settings1.Default.rconPort = rconPort.Value;
            Settings1.Default.Save();
        }

        private void getIPButton_Click(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();

            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                rconIP.Text = address.ToString();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Server properties file|server.properties";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();
                if (stream != null)
                {
                    Dictionary<string, string> settings = new Dictionary<string, string>();
                    System.IO.StreamReader sr = new System.IO.StreamReader(stream);

                    try
                    {
                        while (sr.Peek() >= 0)
                        {
                            string str = sr.ReadLine();
                            if (!str[0].Equals("#") && str.IndexOf("=") != -1)
                            {
                                int keyIndex = str.IndexOf("=");
                                string key = str.Substring(0, keyIndex);
                                string value;
                                if (keyIndex + 1 <= str.Length - 1)
                                {
                                    value = str.Substring(keyIndex + 1, str.Length - (keyIndex + 1));
                                }
                                else
                                {
                                    value = null;
                                }
                                settings.Add(key, value);
                            }
                        }
                        if (settings["enable-rcon"].Equals("true"))
                        {
                            rconIP.Text = settings["server-ip"];
                            rconPort.Value = int.Parse(settings["rcon.port"]);
                            rconPass.Text = settings["rcon.password"];
                            System.Media.SystemSounds.Asterisk.Play();
                        }
                        else
                        {
                            MessageBox.Show("Your Server don't enable Rcon!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("This file has a wrong value!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            saveAllSettings();
        }
    }
}
