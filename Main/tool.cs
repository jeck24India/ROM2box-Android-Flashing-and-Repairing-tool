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
    internal class tool
    {
        public static TextBox LOGGE, PORTER;
        public static bool loadedhose = false;
        public static bool debug = false;
        public static string port = "NaN";
        private static List<string> notdevice = new List<string>();
        private static List<string> current = new List<string>();
        private static bool first = true;

        public static void PORTFIND()
        {
            if (PORTER == null || LOGGE == null) return;
            current.Clear();
            foreach (var a in SerialPort.GetPortNames())
            {
                current.Add(a);
                if (first) notdevice.Add(a);
                if (!notdevice.Contains(a) && !first && port != a) { PORTER.Text = "" + a; port = a; break; }
            }
            if (first) first = false;
            if (!current.Contains(port)) { if (port != "NaN") port = "NaN"; PORTER.Text = "Connect Your Device"; loadedhose = false; }
        }
    }
}
