using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // For Files reading and writting
using System.Windows.Forms;
using System.Diagnostics; // Add this Import

namespace Main
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        private void button42_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Full Firmware Pac File|*.pac";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openfile.FileName;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Clear();
            myform1textbox1.AppendText("Please Wait..." + Environment.NewLine);
            myform1textbox1.AppendText("Loading Pac File..." + Environment.NewLine);
            myform1textbox1.AppendText("Extracting Pac File......." + Environment.NewLine);
            myform1textbox1.AppendText("Waiting for USB Device Response......." + Environment.NewLine);
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "./c bin\\python2.exe -pac \"" + textBox4.Text + "\" -port \"" + textBox3.Text + "\"";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        void romprovider(object sender, DataReceivedEventArgs e)
        {
            string receivedMessage = e.Data + Environment.NewLine;
            if (!string.IsNullOrEmpty(receivedMessage))
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                //Output the data into the TextBox
                SetTextToTextBox(myform1textbox1, receivedMessage);
                myform1textbox1.SelectionStart = myform1textbox1.Text.Length;
                myform1textbox1.ScrollToCaret();
            }
            else
            {

            }
        }
        //Delegate representing the method in which you set text to a RichTextBox
        delegate void CallBackTextBox(TextBox rtf, string text);
        //The method in which you set text to a RichTextBox
        private void SetTextToTextBox(TextBox rtf, string text)
        {
            try
            {
                if (rtf.InvokeRequired)
                {
                    CallBackTextBox d = new CallBackTextBox(SetTextToTextBox);
                    this.Invoke(d, new object[] { rtf, text });
                }
                else
                {
                    rtf.Text = rtf.Text + text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
