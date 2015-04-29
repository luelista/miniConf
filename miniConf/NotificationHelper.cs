using System;
using System.Media;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace miniConf {
    public abstract class NotificationHelper {

        public abstract void InitializeTrayIcon();

        public virtual void InitializePopupNotification() {
        }
        public virtual void InitializeBlinky() {
            tmrBlinky = new Timer();

            icon1 = Program.MainWnd.Icon; 
            icon2 = Icon.FromHandle(new Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("miniConf.Resources.bell16.png")).GetHicon());

        }

        protected void OnShowMiniconfClicked(object sender, EventArgs e) {
            Program.MainWnd.ShowMe();
        }


        private bool IsMention(string text) {
            text = text.ToLower(); string nick = ApplicationPreferences.Nickname.ToLower();
            return text.Contains("@" + nick) || text.Contains(nick + ":");
        }

        public void NotifyMessage(Roomdata room, agsXMPP.protocol.client.Message msg, bool isCurrent) {
            string messageBody = msg.GetTag("body");
            bool mention = IsMention(messageBody);
            bool notify = !msg.HasTag("delay");
            if (room != null && room.Notify == Roomdata.NotifyMode.Never) notify = false;
            if (room != null && room.Notify == Roomdata.NotifyMode.OnMention && !mention) notify = false;
            if (notify) {
                if (Program.MainWnd.enableSoundToolStripMenuItem.Checked) {
                    DoNotifySound(mention ? "popup" : "correct");
                }

                if (!WindowHelper.IsActive(Program.MainWnd) || !isCurrent) {
                    room.unreadNotifyCount++; 
                    if (Program.MainWnd.enablePopupToolStripMenuItem.Checked) {
                       DoNotifyPopup(room, msg, messageBody);
                    }
                    if (Program.MainWnd.enableNotificationsToolStripMenuItem.Checked && !String.IsNullOrEmpty(messageBody)) {
                    }

                }
                //if (!WindowHelper.IsActive(this)) tmrBlinky.Start();
            }
        }

        public virtual void DoNotifyBalloon(Roomdata room, agsXMPP.protocol.client.Message msg, string messageBody) {
        }

        public virtual void DoNotifyPopup(Roomdata room, agsXMPP.protocol.client.Message msg, string messageBody) {

        }

        public virtual void DoNotifySound(string soundName) {
            SoundPlayer dingdong = new SoundPlayer(Program.appDir + Path.DirectorySeparatorChar+"Sounds"+Path.DirectorySeparatorChar+soundName+".wav");
            dingdong.Play();
        }


        public virtual void ResetNotification(Roomdata room) {
            room.ResetUnread();
            stopBlinky();
        }

        Icon icon1;
        Icon icon2;
        Timer tmrBlinky;

        private void tmrBlinky_Tick(object sender, EventArgs e) {
            Program.MainWnd.Icon = (DateTime.Now.Second % 2 == 0) ? icon1 : icon2;
            updateIcon();
        }
        public void startBlinky() {
            tmrBlinky.Start();
        }
        public void stopBlinky() {
            tmrBlinky.Stop(); Program.MainWnd.Icon = icon1; updateIcon();
        }
        public virtual void updateIcon() {}

    }
}

