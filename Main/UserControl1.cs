using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO; // For Files reading and writting
using System.Windows.Forms;
using System.Diagnostics; // Add this Import

namespace Main
{
    public partial class UserControl1 : UserControl
    {
        // Declaring some variables
        Device device; AndroidController android = null; string serial;
        public UserControl1()
        {
            InitializeComponent();
            this.Load += UserControl1_Load;
            android = AndroidController.Instance; // Setting Android instance
        }

        bool isConnected()
        {
            bool i = false; // Initialize variable as false
            android.UpdateDeviceList(); // Update connected device list
            if (android.HasConnectedDevices) // Check for connected devices
            {
                serial = android.ConnectedDevices[0]; // Get first connected device's serial '0' means first
                device = android.GetConnectedDevice(serial); // Use device serial to get device
                i = true; // It is connected
            }
            else
                i = false; // It is not connected
            return i; // Return as function says
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

        /// <summary>
        /// This is for Normal Reboot button will Restart your device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void button5_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
                myform1textbox1.AppendText("Checking unlockability: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("getvar all")) + Environment.NewLine);
            }
            else
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Error No Device Connected--------";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (mycheck1.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "==============================Device Connected! Checking Info=====================================" + Environment.NewLine;
                    myform1textbox1.AppendText("Platform: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform")) + Environment.NewLine);
                    myform1textbox1.AppendText("Manufacture: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.manufacturer")) + Environment.NewLine);
                    myform1textbox1.AppendText("Device Name: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device")) + Environment.NewLine);
                    myform1textbox1.AppendText("Serial Number: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.serialno")) + Environment.NewLine);
                    myform1textbox1.AppendText("Build Date: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.date")) + Environment.NewLine);
                    myform1textbox1.AppendText("Version: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.release")) + Environment.NewLine);
                    myform1textbox1.AppendText("hardware: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.hardware")) + Environment.NewLine);
                    myform1textbox1.AppendText("SDK Version: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.sdk")) + Environment.NewLine);
                    myform1textbox1.AppendText("build ID: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.id")) + Environment.NewLine);
                    myform1textbox1.AppendText("Regions: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.locale.region")) + Environment.NewLine);
                    myform1textbox1.AppendText("Platform: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform")) + Environment.NewLine);
                    myform1textbox1.AppendText("bootloader: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.bootloader")) + Environment.NewLine);
                    myform1textbox1.AppendText("codename: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.codename")) + Environment.NewLine);
                    myform1textbox1.AppendText("========================================================================================================" + Environment.NewLine);
                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================";

                }
            if (mycheck2.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "Device Connected!" + Environment.NewLine;
                    myform1textbox1.AppendText("rebooting Recovery: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot recovery")) + Environment.NewLine);
                    myform1textbox1.AppendText("=========================================Success=============================================" + Environment.NewLine);

                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck3.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "Device Connected!" + Environment.NewLine;
                    myform1textbox1.AppendText("rebooting bootloader: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot bootloader")) + Environment.NewLine);
                    myform1textbox1.AppendText("=========================================Success=============================================" + Environment.NewLine);

                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck4.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "Device Connected!" + Environment.NewLine;
                    myform1textbox1.AppendText("rebooting device: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot")) + Environment.NewLine);
                    myform1textbox1.AppendText("=========================================Success=============================================" + Environment.NewLine);

                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck10.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText("Checking Connected Devices: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("devices")) + Environment.NewLine);
                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck9.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText("Rebooting device: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("reboot")) + Environment.NewLine);
                    myform1textbox1.AppendText("=========================================Success=============================================" + Environment.NewLine);
                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck8.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem unlock")) + Environment.NewLine);
                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck7.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flashing unlock")) + Environment.NewLine);
                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck6.Checked == true) if (isConnected())
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem unlock-go")) + Environment.NewLine);
                }
                else
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

                }
            if (mycheck20.Checked == true)
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Clear();
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk payload";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck19.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk e frp";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck18.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk e userdata";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck17.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk e persist";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck16.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk e oeminfo";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck27.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk payload --metamode FASTBOOT";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
                myform1textbox1.AppendText("Connected device Name: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device")) + Environment.NewLine);
                myform1textbox1.AppendText("Enabling Diag Mod: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell su setprop sys.usb.config rndis,diag,adb")) + Environment.NewLine);
            }
            else
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Error No Device Connected--------";
                myform1textbox1.Text = "-------Please use only when device is Connected--------";
                myform1textbox1.Text = "---No Device Connected--You have to restart the box to use these feature back---";

            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
                myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem unlock")) + Environment.NewLine);
            }
            else
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Error No Device Connected--------";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
                myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flashing unlock")) + Environment.NewLine);
            }
            else
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Error No Device Connected--------";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
                myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem unlock-go")) + Environment.NewLine);
            }
            else
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Error No Device Connected--------";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
                myform1textbox1.AppendText("Rebooting: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("reboot")) + Environment.NewLine);
            }
            else
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "-------Error No Device Connected--------";
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk rf flash.bin";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk rl out";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk r boot boot.img";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk r vbmeta vbmeta.img";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk r recovery recovery.img";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk r boot,vbmeta,recovery boot.img,vbmeta.img,recovery.img";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk e metadata,userdata,md_udc";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk da seccfg unlock";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk xflash seccfg unlock";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk da seccfg lock";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk e frp";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk e userdata";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string op = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin/python.exe";
            p.StartInfo.Arguments = @"-u mtk e persist";
            p.Start();
            StreamReader outputStream = p.StandardOutput;
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = outputStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Full Firmware Flash.bin|*.bin";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openfile.FileName;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk wf \"" + textBox4.Text + "\"";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                textBox3.Text = dialog.FileName;
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk wf \"" + textBox3.Text + "\"";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Partition Image|*.img;*.bin;";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openfile.FileName;
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk e frp";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk e userdata";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk e persist";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk e metadata,userdata,md_udc";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk da seccfg unlock";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk xflash seccfg unlock";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk da seccfg lock";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button56_Click(object sender, EventArgs e)
        {
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Text = "-------Waiting for connection-------" + Environment.NewLine;
            if (isConnected())
            {
                myform1textbox1.AppendText("Platform: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform")) + Environment.NewLine);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\python.exe";
            p.StartInfo.Arguments = " mtk payload";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
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
                string str = null;
                str = e.Data;
                str = e.Data + null;
                if (str.Contains("Mediatek HighSpeed Mod by ROMProvider.COM") == true)
                {
                    myform1textbox1.Clear();
                }
                if (str.Contains("Preloader - Status: Waiting for PreLoader VCOM, please connect mobile") == true)
                {
                    myform1textbox1.Text = ("===================================Waiting for USB Device==========================================");
                }
                if (str.Contains("Port - Hint:") == true)
                {

                    myform1textbox1.Text = ("===================================Waiting for USB Device==========================================");
                }
                if (str.Contains("Power off the phone before connecting.") == true)
                {

                }
                if (str.Contains("For brom mode, press and hold vol up, vol dwn, or all hw buttons and connect usb.") == true)
                {

                }
                if (str.Contains("For preloader mode, don't press any hw button and connect usb.") == true)
                {

                }
                if (str.Contains("Begin") == true)
                {
                    myform1textbox1.Text = ("=====================================Waiting for USB Device========================================");
                }
                if (str.Contains("v5.2136.00") == true)
                {
                    myform1textbox1.Text = ("=====================================Waiting for USB Device========================================" + Environment.NewLine);
                }
                if (str.Contains("Logger deinited.") == true)
                {
                    myform1textbox1.AppendText("===================================Process Completed==========================================");
                }
                if (str.Contains("flash_tool -a auth_file.auth -s MT6575_Anroid_scatter.txt ") == true)
                {
                    myform1textbox1.Text = ("==============================Error Please Select Require Files===================================");
                }
                if (str.Contains("Search usb, timeout set as 120000 ms") == true)
                {
                    myform1textbox1.AppendText("===========================Waiting for USB device==============================================");
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (mycheck15.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk w boot \"" + textBox4.Text + "\"";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();

            }
            if (mycheck14.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk w vbmeta \"" + textBox4.Text + "\"";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();

            }
            if (mycheck13.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk w system \"" + textBox4.Text + "\"";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();

            }
            if (mycheck12.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk w recovery \"" + textBox4.Text + "\"";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();

            }
            if (mycheck11.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk w preloader \"" + textBox4.Text + "\"";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();

            }
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void mycheck21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mycheck25.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk rf flash.bin";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck28.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk da rpmb r";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck29.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk dumpbrom --ptype=kamakiri --filename=brom.bin";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck30.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk r nvram,nvcfg,nvdata nvram.bin,nvcfg.bin,nvdata.bin";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck24.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk rl --skip userdata out";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck23.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk r boot boot.img";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck22.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk r vbmeta vbmeta.img";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck21.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk r recovery recovery.img";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck26.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk r boot,vbmeta,recovery boot.img,vbmeta.img,recovery.img";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        
            string path = @"bin/oth";
            DataTable table = new DataTable();
            table.Columns.Add("File Name");
            table.Columns.Add("File Path");

            string[] files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                table.Rows.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "File Name";
            comboBox1.ValueMember = "File Path";
            comboBox1.SelectedItem = files[0];
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Clear();
            myform1textbox1.AppendText("Please Wait..." + Environment.NewLine);
            myform1textbox1.AppendText("Loading Scatter..." + Environment.NewLine);
            myform1textbox1.AppendText("========================================================Waiting for Result's.....================================================" + Environment.NewLine);
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "flashtool\\flash_tool.exe";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            progressBar2.Value = 20;
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Clear();
            myform1textbox1.AppendText("========================================================Process Started..........================================================" + Environment.NewLine);
            myform1textbox1.AppendText("========================================================Waiting for Result's.....================================================" + Environment.NewLine);
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "mt/mtk.exe";
            p.StartInfo.Arguments = " -b -a \"" + textBox2.Text + "\" -d \"" + textBox1.Text + "\" -s \"" + textBox5.Text + "\" -c download";
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
            while (!p.HasExited)
            {
                Application.DoEvents();

            }
            progressBar2.Value = 100;
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "bin\\kill.bat";
            p.Start();
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Clear();
            myform1textbox1.ForeColor = Color.DarkCyan;
            myform1textbox1.AppendText("=========================================Aborted by user====================================================" + Environment.NewLine);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "MTK DA File|*.bin";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openfile.FileName;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "MTK Auth File|*.auth";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openfile.FileName;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Scatter file|*.txt";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openfile.FileName;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Clear();
            if (mycheck33.Checked == true)
            {
                
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk payload";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
   
            }
            if (mycheck31.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk e frp";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck32.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk e userdata";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck37.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk payload --metamode FASTBOOT";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck36.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk rl --skip userdata out";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck35.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk r boot,vbmeta,recovery boot.img,vbmeta.img,recovery.img";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
            if (mycheck34.Checked == true)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "bin\\python.exe";
                p.StartInfo.Arguments = " mtk r nvram,nvdata,nvcfg nvram.bin,nvdata.bin,nvcfg.bin";
                p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
                p.Start();
                p.BeginOutputReadLine();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string comboBox1 = this.comboBox1.Text;
            comboBox2.Items.Clear();
            if (comboBox1.Contains("360") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\360.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Alcatel") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Alcatel.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("allview") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\allview.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("archos") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\archos.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("artel") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\artel.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("blackview") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\blackview.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("blu") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\blu.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("casper") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\casper.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("condor") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\condor.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("coolpad") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\coolpad.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("hisense") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\hisense.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("hotwav") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\hotwav.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Huawei") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Huawei.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("infinix") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\infinix.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("itel") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\itel.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("lava") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\lava.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("lenovo") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\lenovo.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("lg") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\lg.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("meizu") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\meizu.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("motorola") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\motorola.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("nokia") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\nokia.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("oneplus") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\oneplus.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Oppo") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Oppo.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("panasonic") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\panasonic.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Realme") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Realme.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Samsung") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Samsung.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("tecno") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\tecno.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("tp-link") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\tp-link.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Vivo") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Vivo.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("vsmart") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\vsmart.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("wiko") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\wiko.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Xiaomi") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Xiaomi.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("zte") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\zte.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("Micromax") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\Micromax.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("walton") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\walton.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            if (comboBox1.Contains("symphony") == true)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("bin\\oth\\symphony.txt");
                while (!sr.EndOfStream)
                {
                    comboBox2.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Scatter file|*.txt";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = openfile.FileName;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
            progressBar2.Value = 20;
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Clear();
            myform1textbox1.AppendText("==================================Process Started================================================" + Environment.NewLine);
            myform1textbox1.AppendText("==================================Waiting for Result's================================================" + Environment.NewLine);
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "./c bin\\python.exe a \"" + textBox6.Text + "\"";
            p.Start();
            StreamReader errorStream = p.StandardError;
            string output = "";
            int offset = 0, readBytes = 0;
            char[] buffer = new char[512];
            do
            {
                output = errorStream.ReadLine();
                if (!string.IsNullOrEmpty(output))
                {
                    myform1textbox1.AppendText(output);
                    myform1textbox1.AppendText(Environment.NewLine);
                    offset += readBytes;
                    Application.DoEvents();
                }
            } while (!p.HasExited);
            progressBar2.Value = 100;
            myform1textbox1.AppendText("==================================Process execution Success================================================" + Environment.NewLine);
            }
            else
            {
                TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
                myform1textbox1.Text = "=====================================Device Not Connected!=====================================";

            }
        }
    }
}
