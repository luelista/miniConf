using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace miniConf
{
    public partial class UnreadMessageForm : Form
    {

        public delegate void MessageItemClickEventHandler(object sender, MouseEventArgs e, string chatroom);
        public event MessageItemClickEventHandler OnItemClick;

        public const uint WS_CHILD = 0x40000000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_EX_TOOLWINDOW = 0x00000080;
        public const uint WS_EX_NOACTIVATE = 0x08000000;
        protected override bool ShowWithoutActivation {
            get { return true; }
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams baseParams = base.CreateParams;
                baseParams.ExStyle |= (int)WS_EX_NOACTIVATE | (int)WS_EX_TOOLWINDOW;

                return baseParams;
            }
        }

        public UnreadMessageForm()
        {
            InitializeComponent();
            if (ApplicationPreferences.WineTricks) {
                listView1.View = View.Details; this.Width = 350;
            }
        }

        private void UnreadMessageForm_Load(object sender, EventArgs e)
        {
        }

        public void updateRooms(Dictionary<string, Roomdata> rooms)
        {
            listView1.Items.Clear();
            foreach(var r in rooms.Values) {
                if (r.unreadNotifyCount > 0)
                {
                    var l=listView1.Items.Add(r.RoomName + "(" + r.unreadNotifyCount.ToString()+")");
                    l.SubItems.Add(r.unreadNotifyText);
                    l.Tag = r.RoomName;
                }
            }
            if (ApplicationPreferences.WineTricks) {
                this.Height = listView1.Items.Count * 25 + 65;
            } else {
                this.Height = listView1.Items.Count * 50 + 35;
            }
            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Left = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            if (listView1.Items.Count == 0)
            {
                this.Hide();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string room =(string) listView1.SelectedItems[0].Tag;
                if (OnItemClick != null) OnItemClick(this, e, room);
            }
        }

        private void UnreadMessageForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true; this.Hide();
            }
         }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            string room =(string) listView1.Items[0].Tag;
            if (OnItemClick != null) OnItemClick(this, null, room);
            this.Hide();
        }

    }
}
