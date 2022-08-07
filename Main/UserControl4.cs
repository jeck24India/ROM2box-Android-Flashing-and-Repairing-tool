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
	public partial class UserControl4 : UserControl
	{
		// Declaring some variables
		Device device; AndroidController android = null; string serial;
		public UserControl4()
		{
			InitializeComponent();
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

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button7_Click(object sender, EventArgs e)
		{

        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
        }

        private void button18_Click(object sender, EventArgs e)
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
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}

        private void button17_Click(object sender, EventArgs e)
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
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}

        private void button16_Click(object sender, EventArgs e)
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
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}

        private void button14_Click(object sender, EventArgs e)
        {
			OpenFileDialog openfile = new OpenFileDialog();
			openfile.Filter = "Partition file|*.img";
			openfile.Title = "Open a file..";
			if (openfile.ShowDialog() == DialogResult.OK)
			{
				textBox1.Text = openfile.FileName;
			}
		}

        private void button28_Click(object sender, EventArgs e)
        {
			if (isConnected())
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
				myform1textbox1.Text = "-------Starting Vivo/Iqoo Script-------" + Environment.NewLine;
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.apps.photos")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.music")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.apps.docs")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.browser")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.android.bbkmusic")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.appstore")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.easyshare")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.iqoo.secure")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.website")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.email")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.apps.tachyon")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.projection.gearhead")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.android.bbklog")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.bbk.cloud")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.bbk.iqoo.logsystem")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.facebook.appmanager")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.netflix.mediaclient")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.appfilter")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.appstore")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.assistant")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.doubletimezoneclock")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.favorite")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.feedback")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.game")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.globalsearch")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.livewallpaper.plant")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.magazine")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.omacp")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.share")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.Tips")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vlife.vivo.wallpaper")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.pushservice")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.vivo.demovideo")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.yozo.vivo.office")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.cellbroadcastreceiver")) + Environment.NewLine);
				myform1textbox1.Text = "-------Starting Samsung Script-------" + Environment.NewLine;
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.appsegde")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.visionarapps")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.ardrawing")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.aremoji")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.aremojieditor")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.android.mimage.avatarstickers")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.arzone")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.ar.core")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.samsungpassautofill")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.bbc.bbcagent")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.bixby.service")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.bixby.agent")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.bixby.agent.dummy")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.drivelink.stub")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.cidmanager")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.clipboardedge")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.clipboardsaveservice")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.clipboarduiservice")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.knox.attestation")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.entreprise.knox.attestation")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.omcagent")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.camera.sticker.facearavatar.preload")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.livestickers")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.as")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.android.app.dexonpc")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.forest")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.cocktailbarservice")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.facebook.katana")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.facebook.system")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.facebook.apadb shell pmanager")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.facebook.services")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.game.gametools")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.game.gamehome")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.entreprise.knox.analytics.uploader")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.entreprise.knox.cloudmdmsmdms")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.knox.keychain")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.knox.vpn.proxyhandler")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.ledbackcover")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.android.cover.ledcover")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.mdx")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.microsoft.skydrive")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.netflix.partner.activation")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.knox.containercore")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.reminder")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.scloud")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.spage")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.android.desktoadb shell pmode.uiservice")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.android.app.desktoplauncher")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.android.desktopsystemui")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.mateagent")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.sbrowseredge")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.kidsinstaller")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.location.nsflp2")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.mirrorlink")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.samsungpass")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.spp.push")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.knox.securefolder")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.fast")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.settings.bixby")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.entreprise.knox.shareddevice.keyguard")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.smartswitchassistant")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.sec.android.easyMover.agent")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.beaconmanager")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.stickercenter")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.systemui.bixby2")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.de.axelspringer.yana.zeropage")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.bixby.wakeup")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.watchmanagerstub")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.app.social")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.knox.containeragent")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.microsoft.apppmanager")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.visionintelligence")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.samsung.android.bixbyvision.framework")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.hiya.star")) + Environment.NewLine);
				myform1textbox1.Text = "-------Starting Oppo/Realme Script-------" + Environment.NewLine;
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.ar.core")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.nearme.browser")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.apps.wellbeing")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.colouros.gamespace")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.assistantscreen")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.weather.service")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.weather2")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.nearme.statistics.rom")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.pictorial")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.ted.number")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.apps.youtube.music")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.heytap.cloud")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.googlequicksearchbox")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.heytap.usercenter")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.opera.branding.news")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.realme.securitycheck")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.floatassistant")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.oppo.rftoolkit")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.oppo.logkit")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.compass2")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.youtube")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.athena")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.childrenspace")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.cloud")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.healthcheck")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.phonenoareainquire")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.resmonitor")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.smartdrive")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.translate.engine")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.wallet")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.widget.smallweather")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.dropboxchmod")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.dsi.ant.server")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.oppo.criticallog")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.oppo.oppopowermonitor")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.oppo.ovoicemanager")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.realme.logtool")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.realme.securitycheck")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.tencent.soter.soterserver")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.opera.browser")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.coloros.gamespaceui")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.opera.preinstall")) + Environment.NewLine);
				myform1textbox1.Text = "-------Starting Xiaomi/Redmi/Poco Script-------" + Environment.NewLine;
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.enbbs")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.joom")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.amazon.mShop.android.shopping")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.duokan.phone.remotecontroller")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.duokan.phone.remotecontroller.peel.plugin")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.android.fashiongallery")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.mi.global.bbs")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.analytics")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.daemon")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.msa.global")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.xiaomi.mipicks")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.bugreport")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.miservice")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.xiaomi.midrop")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.mipay.wallet.in")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.miui.vsimcore")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.qualcomm.qti.haven.telemetry.service")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.ar.lens")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.marvin.talkback")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.google.android.talk")) + Environment.NewLine);
				myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell pm uninstall -k --user 0 com.amazon.appmanager")) + Environment.NewLine);
				myform1textbox1.Text = "-Process Success-" + Environment.NewLine;
			}
			else
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}

        private void button23_Click(object sender, EventArgs e)
        {
			OpenFileDialog openfile = new OpenFileDialog();
			openfile.Filter = "Partition file|*.apk";
			openfile.Title = "Open a file..";
			if (openfile.ShowDialog() == DialogResult.OK)
			{
				textBox2.Text = openfile.FileName;
			}
		}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
			if (isConnected())
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "-------Device Connected-------" + Environment.NewLine;
				myform1textbox1.AppendText("Installation Started: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("install \"" + textBox2.Text + "\"")) + Environment.NewLine);
				myform1textbox1.Text = "----Success----" + Environment.NewLine;
			}
			else
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
			if (isConnected())
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.AppendText("Device Status- Connected: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("devices")) + Environment.NewLine);

			}
			else
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}

        private void button32_Click(object sender, EventArgs e)
        {
			if (isConnected())
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "Please confirm backup operation!!" + Environment.NewLine;
				myform1textbox1.AppendText("Status: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("backup -all -f backup.db")) + Environment.NewLine);
				myform1textbox1.Text = "Success! collect backup.db!" + Environment.NewLine;

			}
			else
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}

        private void button31_Click(object sender, EventArgs e)
        {
			if (isConnected())
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "Device Connected!!" + Environment.NewLine;
				myform1textbox1.AppendText("Status: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("restore backup.db")) + Environment.NewLine);

			}
			else
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
				myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;
			}
		}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
			if (mycheck1.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "==================================Device Connected! Checking Info=====================================" + Environment.NewLine;
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
					myform1textbox1.AppendText("==========================================Device Not Connected!======================================" + Environment.NewLine);

				}
			if (mycheck2.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "Device Connected!" + Environment.NewLine;
					myform1textbox1.AppendText("rebooting Recovery: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot recovery")) + Environment.NewLine);
					myform1textbox1.AppendText("===============================================Success!================================================" + Environment.NewLine);

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
					myform1textbox1.AppendText("===============================================Success!================================================" + Environment.NewLine);

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
					myform1textbox1.AppendText("===============================================Success!================================================" + Environment.NewLine);

				}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck5.Checked == true) if (isConnected())
			{
			TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
			myform1textbox1.Text = "=====================================Removing userlock!=====================================" + Environment.NewLine;
			myform1textbox1.AppendText("Manufacture: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.manufacturer")) + Environment.NewLine);
			myform1textbox1.AppendText("device Name: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device")) + Environment.NewLine);
			myform1textbox1.AppendText("Serial Number: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.serialno")) + Environment.NewLine);
			myform1textbox1.AppendText("Build Date: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.date")) + Environment.NewLine);
			myform1textbox1.AppendText("Version: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.release")) + Environment.NewLine);
			myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell su rm /data/system/password.key")) + Environment.NewLine);
			myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell su rm /data/system/pattern.key")) + Environment.NewLine);
			myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell su rm /data/system/locksettings.db")) + Environment.NewLine);
			myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell su rm /data/system/locksettings.db-shm")) + Environment.NewLine);
			myform1textbox1.AppendText("Removing: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell su rm /data/system/locksettings.db-wal")) + Environment.NewLine);
			myform1textbox1.AppendText("=========================================Process OK=============================================" + Environment.NewLine);
			}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck10.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "Device Connected!" + Environment.NewLine;
					myform1textbox1.AppendText("rebooting device to EDL: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot edl")) + Environment.NewLine);
					myform1textbox1.AppendText("===============================================Success!================================================" + Environment.NewLine);

				}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck9.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "Device Connected!" + Environment.NewLine;
					myform1textbox1.AppendText("Connected device Name: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device")) + Environment.NewLine);
					myform1textbox1.AppendText("Enabling Diag Mod: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell su setprop sys.usb.config rndis,diag,adb")) + Environment.NewLine);

				}
			else
			{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

			}
			if (mycheck7.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Connected!=====================================" + Environment.NewLine;
					myform1textbox1.AppendText("Reading Prop: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop")) + Environment.NewLine);

				}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck8.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Connected!=====================================" + Environment.NewLine;
					progressBar1.Value = 15;
					myform1textbox1.AppendText("Battery Status: " + device.Battery.Level.ToString() + Environment.NewLine); // Show battery percentage as string
					myform1textbox1.AppendText("Battery Temperature: " + device.Battery.Temperature + Environment.NewLine); // Show battery temperature                                                                                                      // Get some Additional details and show in textbox
					myform1textbox1.AppendText("Platform: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform")) + Environment.NewLine);
					myform1textbox1.AppendText("Manufacture: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.manufacturer")) + Environment.NewLine);
					myform1textbox1.AppendText("Device Name: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device")) + Environment.NewLine);
					progressBar1.Value = 20;
					myform1textbox1.AppendText("Serial Number: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.serialno")) + Environment.NewLine);
					myform1textbox1.AppendText("Build Date: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.date")) + Environment.NewLine);
					myform1textbox1.AppendText("Version: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.release")) + Environment.NewLine);
					progressBar1.Value = 40;
					myform1textbox1.AppendText("hardware: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.hardware")) + Environment.NewLine);
					myform1textbox1.AppendText("SDK Version: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.sdk")) + Environment.NewLine);
					myform1textbox1.AppendText("build ID: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.id")) + Environment.NewLine);
					myform1textbox1.AppendText("Regions: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.locale.region")) + Environment.NewLine);
					myform1textbox1.AppendText("Platform: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform")) + Environment.NewLine);
					progressBar1.Value = 60;
					myform1textbox1.AppendText("bootloader: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.bootloader")) + Environment.NewLine);
					myform1textbox1.AppendText("codename: " + Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.codename")) + Environment.NewLine);
					myform1textbox1.AppendText("Product Model: " + device.BuildProp.GetProp("ro.product.model") + Environment.NewLine);  // Show device's model, you can use other prop commands to, you will find it in basic device info project
					progressBar1.Value = 80;
					myform1textbox1.AppendText("Encryption: " + device.BuildProp.GetProp("ro.crypto.state") + Environment.NewLine); // Show encryption state
					myform1textbox1.AppendText("Is Rooted: " + device.HasRoot + Environment.NewLine); // Show if device rooted
					myform1textbox1.AppendText("Su Version: " + device.Su.Version + Environment.NewLine); // Show the SU Version installed
					myform1textbox1.AppendText("BusyBox: " + device.BusyBox.IsInstalled + ", " + device.BusyBox.Version + Environment.NewLine); // Checks if busybox installed and its version
					myform1textbox1.AppendText("========================================================================================================" + Environment.NewLine);
					progressBar1.Value = 100;

				}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
		}

        private void button1_Click(object sender, EventArgs e)
        {
			if (mycheck15.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("Reading info: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("getvar all")) + Environment.NewLine);
				}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck14.Checked == true) if (isConnected())
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
			if (mycheck13.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem unlock")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck12.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flashing unlock")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck11.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem unlock-go")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck20.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("Rebooting EDL M1: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem edl")) + Environment.NewLine);
					myform1textbox1.AppendText("=========================================Success=============================================" + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck19.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("Rebooting EDL M2: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("oem enter-dload")) + Environment.NewLine);
					myform1textbox1.AppendText("=========================================Success=============================================" + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck18.Checked == true) if (isConnected())
				{
					Process process = new Process();
					ProcessStartInfo startInfo = new ProcessStartInfo();
					startInfo.WindowStyle = ProcessWindowStyle.Hidden;
					startInfo.CreateNoWindow = true;
					startInfo.UseShellExecute = false;
					startInfo.RedirectStandardOutput = true;
					startInfo.FileName = "bin/edl.exe";
					startInfo.Arguments = " reboot-edl";
					process.StartInfo = startInfo;
					process.Start();
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("======================================Done check Device Manager=========================================" + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck16.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("unlocking bootloader to erase frp: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flashing unlock")) + Environment.NewLine);
					myform1textbox1.AppendText("Erasing FRP: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("erase frp")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck17.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("unlocking bootloader to erase frp: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flashing unlock")) + Environment.NewLine);
					myform1textbox1.AppendText("Erasing FRP2: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("erase config")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck24.Checked == true) if (isConnected())
			{
				TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Connected!=====================================" + Environment.NewLine;
					myform1textbox1.AppendText("Flashing boot.img: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flash boot \"" + textBox1.Text + "\"")) + Environment.NewLine);
			}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck23.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Connected!=====================================" + Environment.NewLine;
					myform1textbox1.AppendText("Flashing recovery.img: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flash recovery \"" + textBox1.Text + "\"")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck22.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Connected!=====================================" + Environment.NewLine;
					myform1textbox1.AppendText("Flashing vbmeta.img: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flash vbmeta \"" + textBox1.Text + "\"")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck21.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "=====================================Device Connected!=====================================" + Environment.NewLine;
					myform1textbox1.AppendText("Flashing system.img: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flash system \"" + textBox1.Text + "\"")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck25.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("unlocking bootloader: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flashing unlock_critical")) + Environment.NewLine);
				}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
			if (mycheck26.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("unlocking bootloder: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("flashing unlock")) + Environment.NewLine);
					myform1textbox1.AppendText("erasing data: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("erase userdata")) + Environment.NewLine);
			}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("=====================================Device Not Connected!=====================================" + Environment.NewLine);

				}
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

        private void button3_Click_1(object sender, EventArgs e)
        {
			CommonOpenFileDialog dialog = new CommonOpenFileDialog();
			dialog.InitialDirectory = "C:";
			dialog.IsFolderPicker = true;
			if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
			{

				textBox4.Text = dialog.FileName;
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
			if (mycheck27.Checked == true) if (isConnected())
				{
				String line;
				try
				{
					//Pass the filepath and filename to the StreamWriter Constructor
					StreamWriter sw = new StreamWriter("dir.cmd");
					//Write a line of text
					sw.Write("set dir=");
					sw.Write(textBox4.Text);
					sw.Write("\\");
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
				myform1textbox1.AppendText("=============================Process-Started=====================================" + Environment.NewLine);
				Process p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardError = true;
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.FileName = "flasha.bat";
				p.Start();
				StreamReader outputStream = p.StandardOutput;
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

			}
			else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck28.Checked == true) if (isConnected())
				{
				String line;
				try
				{
					//Pass the filepath and filename to the StreamWriter Constructor
					StreamWriter sw = new StreamWriter("dir.cmd");
					//Write a line of text
					sw.Write("set dir=");
					sw.Write(textBox4.Text);
					sw.Write("\\");
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
				myform1textbox1.AppendText("=============================Process-Started======================================" + Environment.NewLine);
				Process p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardError = true;
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.FileName = "flashab.bat";
				p.Start();
				StreamReader outputStream = p.StandardOutput;
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

			}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;

				}
			if (mycheck29.Checked == true) if (isConnected())
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.AppendText("Rebooting device: " + Fastboot.ExecuteFastbootCommand(Fastboot.FormFastbootCommand("reboot")) + Environment.NewLine);
					myform1textbox1.AppendText("=========================================Success=============================================" + Environment.NewLine);
				}
				else
				{
					TextBox myform1textbox1 = (ParentForm.Controls["textbox1"] as TextBox);
					myform1textbox1.Text = "================================Device Not Connected!=====================================" + Environment.NewLine;

				}
		}
    }
}
