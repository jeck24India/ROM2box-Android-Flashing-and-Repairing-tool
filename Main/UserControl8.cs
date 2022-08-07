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
    public partial class UserControl8 : UserControl
    {
        public UserControl8()
        {
            InitializeComponent();
            getavaialbleports();
        }
        void getavaialbleports()
        {
            String[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPort.Text == "" || cboPort.Text == "")
                {
                    cboPort.Text = "Please select port settings";
                }
                else
                {
                    _serialPort.PortName = cboPort.Text;
                    cboPort.Enabled = true;
                }
            }

            catch (UnauthorizedAccessException)
            {
                cboPort.Text = "Unauthorised Access";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            try
                {
                    _serialPort.Open();
                    if (!_serialPort.IsOpen)
                    {
                        
                    }
                    else
                    {
                    myform1textbox1.AppendText("Hold up a min, running." + Environment.NewLine);
                        _serialPort.Write("AT+KSTRINGB=0,3\r\n");
                        Thread.Sleep(1000);
                        int num = (int)MessageBox.Show("Go to emergency dialer enter *#0*#, click ok when done");
                    myform1textbox1.AppendText("Activating ADB for older devices" + Environment.NewLine);
                    _serialPort.Write("AT+DUMPCTRL=1,0\r\n");
                        Thread.Sleep(1000);
                        _serialPort.Write("AT+DEBUGLVC=0,5\r\n");
                        Thread.Sleep(1000);
                    myform1textbox1.AppendText("Activating ADB for Newer devices" + Environment.NewLine);
                    _serialPort.Write("AT+SWATD=0\r\n");
                        Thread.Sleep(1000);
                        _serialPort.Write("AT+ACTIVATE=0,0,0\r\n");
                        Thread.Sleep(1000);
                        _serialPort.Write("AT+SWATD=1\r\n");
                        Thread.Sleep(1000);
                        _serialPort.Write("AT+DEBUGLVC=0,5\r\n");
                        Thread.Sleep(1000);
                    myform1textbox1.AppendText("ADB Mod Activation Failed" + Environment.NewLine);
                    myform1textbox1.AppendText("Hold up a min, running." + Environment.NewLine);
                    _serialPort.Write("AT+KSTRINGB=0,3\r\n");
                    Thread.Sleep(1000);
                    myform1textbox1.AppendText("Activating ADB for older devices" + Environment.NewLine);
                    _serialPort.Write("AT+DUMPCTRL=1,0\r\n");
                    Thread.Sleep(1000);
                    _serialPort.Write("AT+DEBUGLVC=0,5\r\n");
                    Thread.Sleep(1000);
                    myform1textbox1.AppendText("Activating ADB for Newer devices" + Environment.NewLine);
                    _serialPort.Write("AT+SWATD=0\r\n");
                    Thread.Sleep(1000);
                    _serialPort.Write("AT+ACTIVATE=0,0,0\r\n");
                    Thread.Sleep(1000);
                    _serialPort.Write("AT+SWATD=1\r\n");
                    Thread.Sleep(1000);
                    _serialPort.Write("AT+DEBUGLVC=0,5\r\n");
                    Thread.Sleep(1000);
                    myform1textbox1.AppendText("ADB Mod Activated" + Environment.NewLine);
                }
                }
                catch
                {
                }
                finally
                {
                    if (_serialPort.IsOpen)
                        _serialPort.Close();
                }
            myform1textbox1.Text = "bypass Process Started" + Environment.NewLine;
            Thread.Sleep(5000);
            myform1textbox1.AppendText("Platform: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform")) + Environment.NewLine);
            myform1textbox1.AppendText("Manufacture: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.manufacturer")) + Environment.NewLine);
            myform1textbox1.AppendText("device Name: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device")) + Environment.NewLine);
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
            myform1textbox1.AppendText("Please do factory Reset: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("push bin/adb.bin /data/local/tmp/temp")) + Environment.NewLine);
            myform1textbox1.AppendText("Setting Require Permission: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell chmod 777 /data/local/tmp/temp")) + Environment.NewLine);
            myform1textbox1.AppendText("Waiting for Response: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell /data/local/tmp/temp")) + Environment.NewLine);
            myform1textbox1.Text = "Success" + Environment.NewLine;
        }

        public class ComPort
        {
            public string Name { get; set; }

            public string Vid { get; set; }

            public string Pid { get; set; }

            public string Description { get; set; }

            public string DisplayName => this.Description + " (" + this.Name + ")";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
            myform1textbox1.Text = "Disabling Knox" + Environment.NewLine;
            myform1textbox1.AppendText("Platform: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform")) + Environment.NewLine);
            myform1textbox1.AppendText("Manufacture: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.manufacturer")) + Environment.NewLine);
            myform1textbox1.AppendText("device Name: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device")) + Environment.NewLine);
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
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.knox.rcp.components")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.knox.foldercontainer")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.knox.securefolder")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.knox.knoxsetupwizardclient")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.enterprise.knox.cloudmdm.smdms")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.knox.switcher")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.knox.kccagent")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.knox.vpn.proxyhandler")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.postmates.android.merchant")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.knox.containercore")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.enterprise.knox.attestation")) + Environment.NewLine);
            myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.knox.containeragent")) + Environment.NewLine);
        }
    }
}
