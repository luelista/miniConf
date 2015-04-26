using System;
using System.Collections.Generic;
using System.Drawing;

using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    class WindowHelper {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_SHOWNOACTIVATE = 4;

        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessageSafe("WM_SHOWME");
        public const int WM_ACTIVATEAPP = 0x001C;

        private static int RegisterWindowMessageSafe(string message) {
            if (VbHelper.runningOnMono())
                return -1;
            return RegisterWindowMessage(message);
        }

        public static bool IsActive(Control wnd) {
            // workaround for minimization bug
            // Managed .IsActive may return wrong value
            if (wnd == null)
                return false;
            return GetForegroundWindow() == wnd.Handle;
        }

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public static void SetCueBanner(TextBox textBox, string banner) {
            if (VbHelper.runningOnMono())
                return;
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, banner);

        }

        public static Color getColorForHSL(double hue, double sat, double light) {
            double[] t = new double[] { 0, 0, 0 };

            try {
                double tH = hue;
                double tS = sat;
                double tL = light;

                if (tS.Equals(0)) {
                    t[0] = t[1] = t[2] = tL;
                } else {
                    double q, p;

                    q = tL < 0.5 ? tL * (1 + tS) : tL + tS - (tL * tS);
                    p = 2 * tL - q;

                    t[0] = tH + (1.0 / 3.0);
                    t[1] = tH;
                    t[2] = tH - (1.0 / 3.0);

                    for (byte i = 0; i < 3; i++) {
                        t[i] = t[i] < 0 ? t[i] + 1.0 : t[i] > 1 ? t[i] - 1.0 : t[i];

                        if (t[i] * 6.0 < 1.0)
                            t[i] = p + ((q - p) * 6 * t[i]);
                        else if (t[i] * 2.0 < 1.0)
                            t[i] = q;
                        else if (t[i] * 3.0 < 2.0)
                            t[i] = p + ((q - p) * 6 * ((2.0 / 3.0) - t[i]));
                        else
                            t[i] = p;
                    }
                }
            } catch (Exception ee) {
                throw new Exception("HSL Color Error", ee);
            }

            return Color.FromArgb((int)(t[0] * 255), (int)(t[1] * 255), (int)(t[2] * 255));
        }

    }
}
