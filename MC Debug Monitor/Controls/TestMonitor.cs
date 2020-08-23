using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MC_Debug_Monitor.Controls
{
    public partial class TestMonitor : RemovableControl
    {
        public TestMonitor()
        {
            InitializeComponent();
        }

        private void TestMonitor_Load(object sender, EventArgs e)
        {

        }

        public override void onConnectServer()
        {
            base.onConnectServer();
        }

        public override void onDisconnectServer()
        {
            base.onDisconnectServer();
        }

        private void testMonitorGroup_Enter(object sender, EventArgs e)
        {

        }

        private void hotkeySettingGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
