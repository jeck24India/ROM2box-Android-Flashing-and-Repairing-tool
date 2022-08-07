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
using System.Threading;

namespace Main
{
    public partial class UserControl11 : UserControl
    {
        public UserControl11()
        {
            InitializeComponent();
        }


        private void UserControl11_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (!comboBox1.Items.Contains("item"))
            {
                comboBox1.Items.Add("samsung");
                comboBox1.Items.Add("sharp");
                comboBox1.Items.Add("oneplus");
                comboBox1.Items.Add("LG");
                comboBox1.Items.Add("Pixel");
                comboBox1.Items.Add("asus");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedItem == "samsung")
            {
                comboBox2.Items.Add("Galaxy_A52");
                comboBox2.Items.Add("Galaxy_A72");
            }
            if (comboBox1.SelectedItem == "sharp")
            {
                comboBox2.Items.Add("Aquos-Sense4");
                comboBox2.Items.Add("Aquos-Sense4_Pro");
            }
            if (comboBox1.SelectedItem == "oneplus")
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (checkBox4.Checked == true)
            {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Clear();
                    myform1textbox1.AppendText("Please Wait..." + Environment.NewLine);
                    myform1textbox1.AppendText("Sending commands..." + Environment.NewLine);
                    myform1textbox1.AppendText("Loading Programmer to device......." + Environment.NewLine);
                    myform1textbox1.AppendText("Waiting for Result's......." + Environment.NewLine);
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "./c emmcdl.exe -p \"" + PORTER9.Text + "\" -MemoryName ufs -f qcom/others/sm_720.elf -e config";
                    p.OutputDataReceived += new DataReceivedEventHandler(Sortie_Console);
                    p.Start();
                    p.BeginOutputReadLine();
                }
            if (checkBox1.Checked == true)
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Clear();
                    myform1textbox1.AppendText("Please Wait..." + Environment.NewLine);
                    myform1textbox1.AppendText("Sending commands..." + Environment.NewLine);
                    myform1textbox1.AppendText("Loading Programmer to device......." + Environment.NewLine);
                    myform1textbox1.AppendText("Waiting for Result's......." + Environment.NewLine);
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "./c emmcdl.exe -p \"" + PORTER9.Text + "\" -MemoryName ufs -f qcom/others/sm_720.elf -e userdata";
                    p.OutputDataReceived += new DataReceivedEventHandler(Sortie_Console);
                    p.Start();
                    p.BeginOutputReadLine();
                }
            if (checkBox3.Checked == true)
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Clear();
                    myform1textbox1.AppendText("Please Wait..." + Environment.NewLine);
                    myform1textbox1.AppendText("Sending commands..." + Environment.NewLine);
                    myform1textbox1.AppendText("Loading Programmer to device......." + Environment.NewLine);
                    myform1textbox1.AppendText("Waiting for Result's......." + Environment.NewLine);
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "./c emmcdl.exe -p \"" + PORTER9.Text + "\" -MemoryName ufs -f qcom/others/sm_720.elf -e persist";
                    p.OutputDataReceived += new DataReceivedEventHandler(Sortie_Console);
                    p.Start();
                    p.BeginOutputReadLine();
                }
            if (checkBox2.Checked == true)
                {
                    String line;
                    try
                    {
                        //Pass the filepath and filename to the StreamWriter Constructor
                        StreamWriter sw = new StreamWriter("qcom/params.cmd");
                        //Write a line of text
                        sw.Write("set SaharaComPort=");
                        sw.Write(PORTER9.Text);
                        sw.WriteLine();
                        //Write a second line of text
                        sw.Write("set FirehoseFile=qcom/others/sm_720.elf");
                        sw.WriteLine();
                        sw.WriteLine("set SelPartsFile=%~dp0parttable.txt");
                        sw.WriteLine("set PartTableFile=%~dp0parttable.txt");
                        sw.WriteLine("set PartTableFileX=%~dp0parttable2.txt");
                        sw.WriteLine("set RawProgFile=%~dp0rawprogram0.xml");
                        sw.WriteLine("set emmcdl_dir=%~dp0");
                        sw.WriteLine("set memory=ufs");
                        sw.WriteLine("set xmlFile=%~dp0rawprogram0.xml");

                    //Close the file
                    sw.Close();
                }
                catch (Exception a)
                {
                    Console.WriteLine("Exception: " + a.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Clear();
                myform1textbox1.AppendText("===================================Process Started..........================================================" + Environment.NewLine);
                myform1textbox1.AppendText("===================================Waiting for Result's.....================================================" + Environment.NewLine);
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "./c qcom\\start.cmd";
                p.OutputDataReceived += new DataReceivedEventHandler(Sortie_Console);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (checkBox5.Checked == true)
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Clear();
                    myform1textbox1.AppendText("Please Wait..." + Environment.NewLine);
                    myform1textbox1.AppendText("Sending commands..." + Environment.NewLine);
                    myform1textbox1.AppendText("Loading Programmer to device......." + Environment.NewLine);
                    myform1textbox1.AppendText("Waiting for Result's......." + Environment.NewLine);
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "./c emmcdl.exe -p \"" + PORTER9.Text + "\" -MemoryName ufs -f qcom/others/sm_720.elf -d boot -o qcom/readed/boot.img";
                    p.OutputDataReceived += new DataReceivedEventHandler(Sortie_Console);
                    p.Start();
                    p.BeginOutputReadLine();
            }
            if (checkBox6.Checked == true)
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Clear();
                    myform1textbox1.AppendText("Please Wait..." + Environment.NewLine);
                    myform1textbox1.AppendText("Sending commands..." + Environment.NewLine);
                    myform1textbox1.AppendText("Loading Programmer to device......." + Environment.NewLine);
                    myform1textbox1.AppendText("Waiting for Result's......." + Environment.NewLine);
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "./c emmcdl.exe -p \"" + PORTER9.Text + "\" -MemoryName ufs -f qcom/others/sm_720.elf -d recovery -o qcom/readed/recovery.img";
                    p.OutputDataReceived += new DataReceivedEventHandler(Sortie_Console);
                    p.Start();
                    p.BeginOutputReadLine();
            }
        }
        void Sortie_Console(object sender, DataReceivedEventArgs e)
        {
            string receivedMessage = e.Data + Environment.NewLine;
            if (!string.IsNullOrEmpty(receivedMessage))
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                //Output the data into the TextBox
                SetTextToTextBox(myform1textbox1, receivedMessage);
                myform1textbox1.SelectionStart = myform1textbox1.Text.Length;
                myform1textbox1.ScrollToCaret();
                string str = null;
                str = e.Data;
                str = e.Data + null;
                if (str.Contains("The handle is invalid.") == true)
                {
                    myform1textbox1.Text = ("===========================Error device in sahara Mod or Somthing is wrong=================================" + Environment.NewLine);
                }
                if (str.Contains("0 partition images created") == true)
                {
                    myform1textbox1.AppendText("========================Error device in sahara Mod or Somthing is wrong==================================" + Environment.NewLine);
                }
                if (str.Contains("<?xml") == true)
                {
                    myform1textbox1.AppendText("==============================Processing============================================" + Environment.NewLine);
                }
                if (str.Contains("Successfully found GPT partition") == true)
                {
                    myform1textbox1.Text = ("================================Processing============================================" + Environment.NewLine);
                }
                if (str.Contains("ERROR: Option") == true)
                {
                    myform1textbox1.Text = ("==============================Error device in sahara Mod or Somthing is wrong===================================" + Environment.NewLine);
                }
                if (str.Contains("fh_loader.exe") == true)
                {
                    myform1textbox1.Text = ("==============================Flashing Process Started.. don't disconnect device==================================" + Environment.NewLine);
                }
                if (str.Contains("pathFile") == true)
                {
                    myform1textbox1.Text = ("===============================Please Wait.. don't disconnect device==================================" + Environment.NewLine);
                }
                if (str.Contains("emmcdl.exe") == true)
                {
                    myform1textbox1.Text = ("===============================Please Wait.. don't disconnect device==================================" + Environment.NewLine);
                }
                if (str.Contains("fh.attrs.MaxPayloadSizeToTargetInBytes") == true)
                {

                }
                if (str.Contains("partition images created") == true)
                {
                    myform1textbox1.AppendText("==================================Success- You can disconnect device==================================" + Environment.NewLine);
                }
                if (str.Contains("echo Firehose file") == true)
                {
                    myform1textbox1.Text = ("================================Please Select Firehose File==================================" + Environment.NewLine);
                }
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
    }
}
