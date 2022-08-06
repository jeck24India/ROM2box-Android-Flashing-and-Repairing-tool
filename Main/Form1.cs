using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;



namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        /// <summary>
        /// below i have include some code for learn test and try
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //seup a file dialog to load a file or folder
        private void button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolder = new FolderBrowserDialog();
            backupfolder.Description = "Choose backup location";
            if (backupfolder.ShowDialog() == DialogResult.OK)
            {
                textbox1.Text = backupfolder.SelectedPath + "\\backup.ab";
            }
        }
        /// <summary>
        /// run a Process using below code
        /// </summary>
        /// <param name="Commands"></param>
        public void run_process(string Commands)
        {
            var p = new Process(); // Declaring new process

            // Defining the process, setting its parameters
            p.StartInfo.FileName = "cmd.exe"; // Passing main function to cmd.exe
            p.StartInfo.Arguments = "/c " + Commands; // Commands string passed here. /c argument is used to passed parameters explicitly.
            p.StartInfo.CreateNoWindow = true; // No displaying a window
            p.StartInfo.UseShellExecute = false; // No using cmd.exe to execute shell
            p.StartInfo.RedirectStandardOutput = true;
            p.Start(); // Starting the process
            do
            {
                Application.DoEvents(); // This will prevent application from hang
            } while (!p.HasExited); // Will wait until process been released from memory
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
           
            
        }

        private void userControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
