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
    internal class port4
    {
        public static TextBox LOGGE4, PORTER4;
        public static bool loadedhose = false;
        public static bool debug = false;
        public static string port = "NaN";
        private static List<string> notdevice = new List<string>();
        private static List<string> current = new List<string>();
        private static bool first = true;

        public static void PORTFIND4()
        {
            if (PORTER4 == null || LOGGE4 == null) return;
            current.Clear();
            foreach (var a in SerialPort.GetPortNames())
            {
                current.Add(a);
                if (first) notdevice.Add(a);
                if (!notdevice.Contains(a) && !first && port != a) { PORTER4.Text = "" + a; port = a; break; }
            }
            if (first) first = false;
            if (!current.Contains(port)) { if (port != "NaN") port = "NaN"; PORTER4.Text = "No USB Device Detected"; loadedhose = false; }
        }
    }
}