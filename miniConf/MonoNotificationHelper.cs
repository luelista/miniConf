using System;
using Gtk;
using Gdk;
using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace miniConf {
    public class MonoNotificationHelper : NotificationHelper {

        private static StatusIcon trayIcon;

        public override void InitializeTrayIcon() {
            //new Thread(TrayIconThread).Start();
        }

        private void TrayIconThread() {

            // Creation of the Icon
            trayIcon = new StatusIcon(new Pixbuf("/usr/share/icons/gnome/16x16/apps/kuser.png"));
            trayIcon.Visible = true;

            // Show/Hide the window (even from the Panel/Taskbar) when the TrayIcon has been clicked.
            trayIcon.Activate += delegate { 
                Program.MainWnd.Invoke(new ThreadStart(Program.MainWnd.ShowMe));
            };
            // Show a pop up menu when the icon has been right clicked.
            trayIcon.PopupMenu += OnTrayIconPopup;
            
            // A Tooltip for the Icon
            //trayIcon.Tooltip = "miniConf";

            Application.Run();
        }

        // Create the popup menu, on right click.
        static void OnTrayIconPopup(object o, EventArgs args) {
            Menu popupMenu = new Menu();
            ImageMenuItem menuItemTest = new ImageMenuItem("Open miniConf");
            Gtk.Image appimg2 = new Gtk.Image(Stock.Add, IconSize.Menu);
            menuItemTest.Image = appimg2;
            popupMenu.Add(menuItemTest);

            menuItemTest.Activated += delegate {
                Program.MainWnd.Invoke(new ThreadStart(Program.MainWnd.ShowMe));
            };


            ImageMenuItem menuItemQuit = new ImageMenuItem("Quit");
            Gtk.Image appimg = new Gtk.Image(Stock.Quit, IconSize.Menu);
            menuItemQuit.Image = appimg;
            popupMenu.Add(menuItemQuit);
            // Quit the application when quit has been clicked.
            menuItemQuit.Activated += delegate {
                Program.MainWnd.Invoke((ThreadStart)delegate {
                    Program.MainWnd.beendenToolStripMenuItem_Click(null,null);
                });
            };


            popupMenu.ShowAll();
            popupMenu.Popup();
        }

        // 

        public override void DoNotifyPopup(Roomdata room, agsXMPP.protocol.client.Message msg, string messageBody) {
          ProcessStartInfo psi = new ProcessStartInfo();
          psi.FileName = "/usr/bin/notify-send";
          psi.Arguments = "\"Nachricht von " + msg.From.ToString() + "\" \"" + messageBody + "\"";
          Process.Start(psi);
        }

    }
}

