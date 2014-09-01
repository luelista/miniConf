using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace miniConf {
    static class Program {

        public static Mutex singleInstanceMutex;

        public static agsXMPP.XmppClientConnection conn = null;
        public static string dataDir;
        public static string appDir;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] argv) {

            appDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
            dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\miniConf\\";
            System.IO.Directory.CreateDirectory(dataDir);

            singleInstanceMutex = new Mutex(true, "singleInstanceMutex@miniConf.luelista.net");
            if (singleInstanceMutex.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 form1 = new Form1();
                if (argv.Length < 1 || argv[0] != "/autostart") form1.Show();
                Application.Run();
                singleInstanceMutex.ReleaseMutex();
            } else {
                WindowHelper.PostMessage((IntPtr)WindowHelper.HWND_BROADCAST,
                                        WindowHelper.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
}
