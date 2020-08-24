﻿using MC_Debug_Monitor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            versionLabel.Text = String.Format("Ver.{0}", Settings.Default.version);
            textbox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            textbox.Text = Resources.VersionInfo;
        }
    }
}