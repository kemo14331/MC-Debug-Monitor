using MC_Debug_Monitor.utils;
using System;
using System.Windows.Forms;

namespace MC_Debug_Monitor.Controls
{
    public partial class HotkeyResister : UserControl
    {

        private Keys hotKeyCode;
        public HotKey hotkey;

        /// <summary>
        /// ホットキーが押されると発生する。
        /// </summary>
        public event EventHandler HotKeyPush;
        /// <summary>
        /// ホットキーが登録された時発生する
        /// </summary>
        public event EventHandler onHotKeyResister;
        /// <summary>
        /// ホットキーの登録が失敗したとき発生する
        /// </summary>
        public event EventHandler onFaildHotKeyResister;
        /// <summary>
        /// ホットキーの登録が解除された時発生する
        /// </summary>
        public event EventHandler onHotKeyDisResister;

        public HotkeyResister()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(onDispose);
        }

        public void onDispose(object sender, EventArgs e)
        {
            if (hotkey != null) hotkey.Dispose();
        }

        private void HotkeyResister_Load(object sender, EventArgs e)
        {
            enableHotkey.Enabled = false;
            Ctrl.Checked = true;
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
                    hotkey.HotKeyPush += new EventHandler((obj, e) =>
                    {
                        if (HotKeyPush != null) HotKeyPush(obj, e);
                    });
                    if (onHotKeyResister != null) onHotKeyResister(this, EventArgs.Empty);
                    Alt.Enabled = false;
                    Shift.Enabled = false;
                    Ctrl.Enabled = false;
                }
                else
                {
                    enableHotkey.Checked = false;
                    if (onFaildHotKeyResister != null) onFaildHotKeyResister(this, EventArgs.Empty);
                }
            }
            else
            {
                if (onHotKeyResister != null) onHotKeyDisResister(this, EventArgs.Empty);
                Alt.Enabled = true;
                Shift.Enabled = true;
                Ctrl.Enabled = true;
                hotkey.Dispose();
            }
        }

        private void Ctrl_CheckedChanged(object sender, EventArgs e)
        {
            Ctrl.Checked = true;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length > 0)
            {
                enableHotkey.Enabled = true;
                hotKeyCode = (Keys)Enum.Parse(typeof(Keys), maskedTextBox1.Text[0].ToString(), ignoreCase: true);
            }
            else
            {
                enableHotkey.Enabled = false;
            }
        }
    }
}
