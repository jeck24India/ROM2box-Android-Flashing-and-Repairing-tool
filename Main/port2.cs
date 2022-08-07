using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.IO.Ports;

namespace Main
{
    internal class port2
    {
        public static TextBox LOGGE2, PORTER2;
        public static bool loadedhose = false;
        public static bool debug = false;
        public static string port = "NaN";
        private static List<string> notdevice = new List<string>();
        private static List<string> current = new List<string>();
        private static bool first = true;

        public static void PORTFIND2()
        {
            if (PORTER2 == null || LOGGE2 == null) return;
            current.Clear();
            foreach (var a in SerialPort.GetPortNames())
            {
                current.Add(a);
                if (first) notdevice.Add(a);
                if (!notdevice.Contains(a) && !first && port != a) { PORTER2.Text = "" + a; port = a; break; }
            }
            if (first) first = false;
            if (!current.Contains(port)) { if (port != "NaN") port = "NaN"; PORTER2.Text = "No USB Device Detected"; loadedhose = false; }
        }
    }
}
