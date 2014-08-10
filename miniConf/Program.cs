using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace miniConf {
    static class Program {

        public static Mutex singleInstanceMutex;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] argv) {
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
