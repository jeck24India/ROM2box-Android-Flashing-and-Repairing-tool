using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;


namespace Main
{
    public partial class UserControl9 : UserControl
    {
        public UserControl9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/rom2box");
        }
    }
}
