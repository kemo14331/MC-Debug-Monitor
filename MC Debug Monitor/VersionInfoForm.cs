using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace MC_Debug_Monitor
{
    public partial class VersionInfoForm : Form
    {
        public VersionInfoForm()
        {
            InitializeComponent();
        }

        private void VersionInfoForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = String.Format("Ver.{0}", GetType().Assembly.GetName().Version.ToString());
        }
    }
}
