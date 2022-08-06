using System;
using System.Windows.Forms;
using System.Diagnostics; //

namespace Main
{
    public partial class UserControl1 : UserControl
    {
        // Declaring some variables here
        
        public UserControl1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is a function through which we pass the commands the cmd.exe explicitly for running various task.
        /// Usage:- run_process(@"adb.exe reboot recovery");
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

        // This tool use a New process every time, You can use run_process command to execute a command Like emmcdl.exe --function
        //have tried run process but it's not fast as a New process...
        // you can define your code under the specific button
        // only GUI code are shared

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (mycheck1.Checked == true) 
                {
                //define here what to do when user select this option and click Start button
                }
            else
            {
                //define here waht to show whene something is wrong
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }
        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            
        }

        private void button28_Click(object sender, EventArgs e)
        {
            
        }

        private void button30_Click(object sender, EventArgs e)
        {
            
        }

        private void button32_Click(object sender, EventArgs e)
        {
            
        }

        private void button33_Click(object sender, EventArgs e)
        {
            
        }

        private void button34_Click(object sender, EventArgs e)
        {
            
        }

        private void button42_Click(object sender, EventArgs e)
        {
           //define a File loader here e.g open file dialog or folder dialog
        }

        private void button41_Click(object sender, EventArgs e)
        {
            
        }

        private void button40_Click(object sender, EventArgs e)
        {
            
        }

        private void button39_Click(object sender, EventArgs e)
        {
        }

        private void button38_Click(object sender, EventArgs e)
        {
        }

        private void button49_Click(object sender, EventArgs e)
        {
            
        }

        private void button50_Click(object sender, EventArgs e)
        {
            
        }

        private void button51_Click(object sender, EventArgs e)
        {
            
        }

        private void button53_Click(object sender, EventArgs e)
        {
            
        }

        private void button54_Click(object sender, EventArgs e)
        {
            
        }

        private void button55_Click(object sender, EventArgs e)
        {
            
        }

        private void button52_Click(object sender, EventArgs e)
        {
            
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button56_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }
        void romprovider(object sender, DataReceivedEventArgs e)
        {
           //run process is not enough to handle the output
           //you can define a editional even handler here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void mycheck21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
