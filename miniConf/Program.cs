using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace miniConf {
    static class Program {

        public static Mutex singleInstanceMutex;

        public static JabberService Jabber { get; private set; }
        public static string dataDir;
        public static string appDir;
        public static string tempDir;

        public static cls_globPara glob;
        public static ChatDatabase db;
        public static Form1 MainWnd;
        
        public static bool isAutorun;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] argv) {
            Application.ThreadException += delegate(object sender, ThreadExceptionEventArgs e) {
                Console.Error.WriteLine("Unhandled Thread Exception!\n" + e.Exception.ToString());
            };
            AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e) {
                Console.Error.WriteLine("Unhandled AppDomain Exception!\n" + e.ExceptionObject.ToString());
            };

            Jabber = new JabberService();

			appDir = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar;
			dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "miniConf" + Path.DirectorySeparatorChar;
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(dataDir + "Received Files");
            System.IO.Directory.CreateDirectory(dataDir + "Temporary Data");
            System.IO.Directory.CreateDirectory(dataDir + "Avatars");
            System.IO.Directory.CreateDirectory(dataDir + "Emoticons");
			tempDir = dataDir + "Temporary Data" + Path.PathSeparator;

            singleInstanceMutex = new Mutex(true, "singleInstanceMutex@miniConf.luelista.net");
            if (singleInstanceMutex.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainWnd = new Form1();
                isAutorun = ! (argv.Length < 1 || argv[0] != "/autostart");
                //MainWnd.Show();
                //MainWnd.onIni(shouldShow);
                //if (!shouldShow) MainWnd.Hide();
                Application.Run(MainWnd);
                singleInstanceMutex.ReleaseMutex();
            } else {
                /*WindowHelper.PostMessage((IntPtr)WindowHelper.HWND_BROADCAST,
                                        WindowHelper.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                                        */
				MessageBox.Show ("miniConf is already running.");
            }
        }
    }
}
