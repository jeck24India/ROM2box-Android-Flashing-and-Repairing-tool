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
    internal class port7
    {
        public static TextBox LOGGE7, PORTER7;
        public static bool loadedhose = false;
        public static bool debug = false;
        public static string port = "NaN";
        private static List<string> notdevice = new List<string>();
        private static List<string> current = new List<string>();
        private static bool first = true;

        public static void PORTFIND7()
        {
            if (PORTER7 == null || LOGGE7 == null) return;
            current.Clear();
            foreach (var a in SerialPort.GetPortNames())
            {
                current.Add(a);
                if (first) notdevice.Add(a);
                if (!notdevice.Contains(a) && !first && port != a) { PORTER7.Text = "" + a; port = a; break; }
            }
            if (first) first = false;
            if (!current.Contains(port)) { if (port != "NaN") port = "NaN"; PORTER7.Text = "No USB Device Detected"; loadedhose = false; }
        }
    }
}