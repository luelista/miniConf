using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf
{
    public partial class UnreadMessageForm : Form
    {

        public delegate void MessageItemClickEventHandler(object sender, MouseEventArgs e, string chatroom);
        public event MessageItemClickEventHandler OnItemClick;

        public UnreadMessageForm()
        {
            InitializeComponent();
        }

        private void UnreadMessageForm_Load(object sender, EventArgs e)
        {

        }

        public void updateRooms(Dictionary<string, Roomdata> rooms)
        {
            listView1.Items.Clear();
            foreach(var r in rooms.Values) {
                if (r.unreadMsgCount > 0)
                {
                    listView1.Items.Add(r.roomName()).SubItems.Add(r.unreadMsgCount.ToString() + " unread message" + (r.unreadMsgCount > 1 ? "s" : ""));
                }
            }
            this.Height = listView1.Items.Count * 50 + 35;
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
                string room = listView1.SelectedItems[0].Text;
                if (OnItemClick != null) OnItemClick(this, e, room);
            }
        }

    }
}
