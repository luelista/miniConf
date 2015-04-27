using System;
using System.Windows.Forms;
using System.Drawing;

namespace miniConf {
    public class WindowsNotificationHelper : NotificationHelper {

        string balloonRoom = null;

        NotifyIcon nfi;

        UnreadMessageForm popupWindow;

        public override void InitializeTrayIcon() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            nfi = new NotifyIcon(Program.MainWnd.Container);
            //this.nfi.ContextMenuStrip = this.contextMenuStrip1;
            this.nfi.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.nfi.Text = "miniConf";
            this.nfi.Visible = true;
            this.nfi.BalloonTipClicked += new System.EventHandler(this.OnBalloonTipClicked);
            this.nfi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnTrayiconClicked);

        }

        private void OnBalloonTipClicked(object sender, EventArgs e) {
            Program.MainWnd.ShowMe(); Program.MainWnd.onChatroomSelect(balloonRoom);
        }

        protected void OnTrayiconClicked(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                OnShowMiniconfClicked(sender, e);
            } else {
                ContextMenuStrip ctx = new ContextMenuStrip();
                ToolStripItem i;
                i = ctx.Items.Add("Open miniConf");
                i.Click += OnShowMiniconfClicked;
                i.Font = new Font(i.Font, FontStyle.Bold);
                i = ctx.Items.Add("Quit");
                i.Click += Program.MainWnd.beendenToolStripMenuItem_Click;
                ctx.Show((Control)sender, e.Location);
            }
        }

        public override void InitializePopupNotification() {
            popupWindow = new UnreadMessageForm();
            popupWindow.OnItemClick += popupWindow_OnItemClick;
            var createTheHandlePlease = popupWindow.Handle;

        }

        void popupWindow_OnItemClick(object sender, MouseEventArgs e, string chatroom) {
            Program.MainWnd.ShowMe(); Program.MainWnd.onChatroomSelect(chatroom);
        }

        public override void DoNotifyPopup(Roomdata room, agsXMPP.protocol.client.Message msg, string messageBody) {
            //WindowHelper.ShowWindow(popupWindow.Handle, WindowHelper.SW_SHOWNOACTIVATE); //
            room.unreadNotifyText = msg.From.Resource + ":" + messageBody;
            popupWindow.Show();
            popupWindow.updateRooms(Program.MainWnd.rooms);
        }


        public override void DoNotifyBalloon(Roomdata room, agsXMPP.protocol.client.Message msg, string messageBody) {
            balloonRoom = msg.From.Bare;
            nfi.ShowBalloonTip(30000, msg.From.Resource + " in " + msg.From.User + ":", messageBody, ToolTipIcon.Info);
        }


        public override void updateIcon() {
            this.nfi.Icon = Program.MainWnd.Icon;
        }


        public override void ResetNotification(Roomdata room) {
            base.ResetNotification(room);
            popupWindow.updateRooms(Program.MainWnd.rooms);
        }

    }
}

