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
        public static string tempDir;

        public static cls_globPara glob;
        public static ChatDatabase db;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] argv) {

            appDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
            dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\miniConf\\";
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(dataDir + "Received Files");
            System.IO.Directory.CreateDirectory(dataDir + "Temporary Data");
            tempDir = dataDir + "Temporary Data\\";

            singleInstanceMutex = new Mutex(true, "singleInstanceMutex@miniConf.max-weller.de");
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
