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
using System.IO.Ports;
using System.Diagnostics;
using System.Runtime.InteropServices;



namespace Main
{
    public partial class Form1 : Form
    {
        // Declaration of some variables...
        Device device; AndroidController android = null; string serial;

        public Form1()
        {

            InitializeComponent();
            android = AndroidController.Instance; // Setting Android instance
            timer1.Interval = 200; // Setting timer interval to 2 milliseconds, This means it will check devices after every 2 milliseconds
            timer1.Start(); // Start the Timer :)
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        /// <summary>
		/// Set the timer Function,,
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        /// 
        bool isConnected()
        {
            bool i = false; // Initialize variable as false
            android.UpdateDeviceList(); // Update connected device list
            if (android.HasConnectedDevices) // Check for connected devices
            {
                serial = android.ConnectedDevices[0];
                i = true; // It is connected
            }
            else
                i = false; // It is not connected
            return i; // Return as function says
        }

        /// <summary>
        /// Set the work of background work, What it will do....
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        void Timer1Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy) // Check if backgroud worker is NOT (indicated by ! at start) busy otherwise both process may collide with each other
            {
                backgroundWorker1.RunWorkerAsync(); // Run Background worker, it will automatically prevent Application from hangs as it runs in background
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Checker_Tick(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl1.Show();
            userControl2.Hide();
            userControl3.Hide();
            userControl4.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl2.Show();
            userControl1.Hide();
            userControl3.Hide();
            userControl4.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl3.Show();
            userControl2.Hide();
            userControl1.Hide();
            userControl4.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl3.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl4.Show();
            userControl2.Hide();
            userControl3.Hide();
            userControl1.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl4.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl5.Show();
            userControl2.Hide();
            userControl3.Hide();
            userControl4.Hide();
            userControl1.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl5.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControl6.Show();
            userControl2.Hide();
            userControl3.Hide();
            userControl4.Hide();
            userControl5.Hide();
            userControl1.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl6.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userControl7.Show();
            userControl2.Hide();
            userControl3.Hide();
            userControl4.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl1.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl7.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            userControl8.Show();
            userControl2.Hide();
            userControl3.Hide();
            userControl4.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl1.Hide();
            userControl9.Hide();
            userControl8.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userControl9.Show();
            userControl2.Hide();
            userControl3.Hide();
            userControl4.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl1.Hide();
            userControl9.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (isConnected())
            {
                pictureBox1.BackColor = Color.Green; // Setting color to green
            }
            else
            {
                pictureBox1.BackColor = Color.Red; // Setting color to Red as not connected
            }
            /// <summary>
            /// Set the timer Function,,
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Process.Start("https://romprovider.com");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Process.Start("https://romprovider.com/flash-file-download/");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            userControl101.Show();
            userControl2.Hide();
            userControl4.Hide();
            userControl3.Hide();
            userControl1.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl101.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            userControl111.Show();
            userControl2.Hide();
            userControl4.Hide();
            userControl3.Hide();
            userControl1.Hide();
            userControl5.Hide();
            userControl6.Hide();
            userControl7.Hide();
            userControl8.Hide();
            userControl9.Hide();
            userControl101.Hide();
            userControl111.BringToFront();
        }
        private void button12_Click_1(object sender, EventArgs e)
        {
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void userControl1_Load(object sender, EventArgs e)
        {

        }

        private void textbox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
