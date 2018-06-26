using CodePoints;
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
        public static TodoForm wvl;
        
        public static bool isAutorun;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] argv) {
            Jabber = new JabberService();

            string profileName = "";
            int c;
            string[] cmdline = Environment.GetCommandLineArgs();
            while ((c = GetOpt.GetOptions(cmdline, "p:")) != (-1)) {
                switch ((char)c) {
                    case 'p':
                        profileName = GetOpt.Text;
                        break;
                    case '?':
                        Console.WriteLine("Error in parsing option '{0}'", GetOpt.Item);
                        break;
                    default:
                        break;
                }
            }

            appDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
            dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\miniConf\\";
            System.IO.Directory.CreateDirectory(dataDir);
            if (profileName != "") {
                dataDir += "Profiles\\";
                System.IO.Directory.CreateDirectory(dataDir);
                dataDir += profileName + "\\";
                System.IO.Directory.CreateDirectory(dataDir);
            }
            System.IO.Directory.CreateDirectory(dataDir + "Received Files");
            System.IO.Directory.CreateDirectory(dataDir + "Temporary Data");
            System.IO.Directory.CreateDirectory(dataDir + "Avatars");
            System.IO.Directory.CreateDirectory(dataDir + "Emoticons");
            tempDir = dataDir + "Temporary Data\\";

            singleInstanceMutex = new Mutex(true, "singleInstanceMutex"+profileName+"@miniConf.luelista.net");
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
                WindowHelper.PostMessage((IntPtr)WindowHelper.HWND_BROADCAST,
                                        WindowHelper.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
}
