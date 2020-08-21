using System;
using System.Windows.Forms;
using static MC_Debug_Monitor.Program;

namespace MC_Debug_Monitor.Controls
{
    public partial class RemovableControl : UserControl
    {
        public RemovableControl()
        {
            InitializeComponent();

        }

        private void RemovableControl_Load(object sender, EventArgs e)
        {
            mainform.onRconConnect += onConnectServer;
            mainform.onRconDisconnect += onDisconnectServer;
            this.Disposed += new System.EventHandler((s, a) =>
            {
                mainform.onRconConnect -= onDisconnectServer;
                mainform.onRconDisconnect -= onDisconnectServer;
            });
        }

        /// <summary>
        /// サーバーと接続が確立された時に呼び出される
        /// </summary>
        public virtual void onConnectServer() { }


        /// <summary>
        /// サーバーの接続が切断された時に呼び出される
        /// </summary>
        public virtual void onDisconnectServer() { }
    }
}
