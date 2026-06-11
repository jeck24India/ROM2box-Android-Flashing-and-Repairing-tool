using mtkclient.library;
using mtkclient.MTK.Client.Scatter;
using mtkclient.Tasks;
using Partition_Manager;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LogService;
using static mtkclient.USBFastConnect;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace mtkclient
{
    public partial class Main : Form
    {
        public static LogService Logger;
        public static Main SharedUI;
        private IProgress<int> progress;
        CancellationTokenSource cts = new CancellationTokenSource();

        public Main()
        {
            InitializeComponent();
            Logger = new LogService();
            Logger.WriteLog = logs;
            SharedUI = this;
            getcomInfo();
        }

        private void log_TextChanged(object sender, EventArgs e)
        {
            log.Invoke(
                new Action(() =>
                {
                    log.SelectionStart = log.TextLength;
                    log.ScrollToCaret();
                })
            );
        }

        private void ComboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboPort.Text))
            {
                MtkTask.AllowSleep();
                CkBromReady.Checked = false;
            }
            else
            {
                MtkTask.PreventSleep();
            }
        }
        public void dotemp(string Commands)
        {

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe"; // Passing main function to cmd.exe
            p.StartInfo.Arguments = "/c " + Commands; // Commands string passed here. /c argument is used to passed parameters explicitly.
            p.Start();
            while (!p.HasExited)
            {
                Application.DoEvents();
            }
        }
        public void runadb(string Commands)
        {
            progressBar1.Value = 0;
            timer5.Start();
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe"; // Passing main function to cmd.exe
            p.StartInfo.Arguments = "/c " + Commands; // Commands string passed here. /c argument is used to passed parameters explicitly.
            p.OutputDataReceived += new DataReceivedEventHandler(adb);
            p.ErrorDataReceived += new DataReceivedEventHandler(adb);
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            while (!p.HasExited)
            {
                Application.DoEvents();

            }
            timer5.Stop();
            progressBar1.Invoke(new Action(() => progressBar1.Value = progressBar1.Maximum));
            customprogressBar1.Invoke(new Action(() => customprogressBar1.Value = customprogressBar1.Maximum));
        }
        void adb(object sender, DataReceivedEventArgs e)
        {
            string receivedMessage = e.Data;
            if (!string.IsNullOrEmpty(receivedMessage))
            {
                string str = null;
                str = e.Data;
                str = e.Data + null;
                string str2 = str.Replace(")", "").Replace("deleting", "Removing").Replace("failed", "Failed").Replace("err: ", "Error: ").Replace("error: ", "Error: ").Replace("partition-size:", "Size: ").Replace("partition-type:", "Partition Name: ").Replace("writing", "Writing").Replace("sending", "Sending").Replace("target reported max download size of", "Max Size to be Downloaded").Replace("finished.", "Finished.").Replace("erasing", "Erasing").Replace("(bootloader) ", "").Replace("* daemon not running; starting now at tcp:5037", "").Replace("* daemon started successfully", "");
                this.SendLog(str2, new Color?(Color.Black));

            }
            else
            {

            }
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }
        private void CkList_CheckedChanged(object sender, EventArgs e)
        {
            if (DataViewmtk.Rows.Count > 0)
            {
                if (CkList.Checked)
                {
                    foreach (DataGridViewRow item in DataViewmtk.Rows)
                        item.Cells[0].Value = true;
                }
                else
                {
                    foreach (DataGridViewRow item in DataViewmtk.Rows)
                        item.Cells[0].Value = false;
                }
            }
        }

        private void DataViewmtk_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataViewmtk.Rows.Count > 0)
            {
                if (e.ColumnIndex == 4)
                {
                    var openFileDialog = new OpenFileDialog();
                    openFileDialog.Title =
                        "Select File Partition " + DataViewmtk.CurrentRow.Cells[1].Value;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(
                        Environment.SpecialFolder.MyComputer
                    );
                    openFileDialog.FileName = "*.*";
                    openFileDialog.Filter = "ALL FILE  (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        DataViewmtk.CurrentRow.Cells[4].Value = openFileDialog.FileName;
                    }
                }
            }
        }

        public static void ProcessBar(long Process, long total)
        {
            int res = (int)Math.Round(Math.Round(Process * 100L / (double)total));
            if (res > 100)
                res = 100;

            Main.SharedUI.progressBar1.Invoke(
                (Action)(() => Main.SharedUI.progressBar1.Value = res)
            );
        }

        private void logs(Status status, string arg2, bool newline = true)
        {
            if (newline)
            {
                log.Invoke((Action)(() => log.Text += arg2 + "\n"));
            }
            else
            {
                log.Invoke((Action)(() => log.Text += arg2));
            }
        }

        private void ButtonSTOP_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void BtnEmi_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select EMI | Preloader File";
            fd.InitialDirectory = System.Environment.GetFolderPath(
                Environment.SpecialFolder.MyComputer
            );
            fd.FileName = "*.*";
            fd.Filter = "Preloader file |*.bin*;";
            fd.FilterIndex = 1;
            fd.RestoreDirectory = true;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtEMI.Text = fd.FileName;
             
            }
        }


        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (DataViewmtk.Rows.Count > 0)
            {
                var folderBrowserDialog = new FolderBrowserDialog() { ShowNewFolderButton = true };
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                    TxtIMGBin.Text = folderBrowserDialog.SelectedPath;
                    foreach (DataGridViewRow row in DataViewmtk.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string fileName = row.Cells[1].Value.ToString();

                            string filePath = Path.Combine(selectedFolderPath, fileName);
                            if (File.Exists(filePath))
                            {
                                row.Cells[0].Value = true;
                                row.Cells[4].Value = filePath;
                            }
                            else
                            {
                                filePath = Path.Combine(selectedFolderPath, fileName + ".img");
                                if (File.Exists(filePath))
                                {
                                    row.Cells[0].Value = true;
                                    row.Cells[4].Value = filePath;
                                }
                                else
                                {
                                    filePath = Path.Combine(selectedFolderPath, fileName + ".bin");
                                    if (File.Exists(filePath))
                                    {
                                        row.Cells[0].Value = true;
                                        row.Cells[4].Value = filePath;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    TxtIMGBin.Text = "";
                }
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            Main.Logger.Write("Not Support use MTK Version", Status.SUCCESS, true);
        }

        private async void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            BtnIdentify.Enabled = false;
            try
            {
                cts = new CancellationTokenSource();
                var token = cts.Token;

                if (DataViewmtk.Rows.Count > 0)
                {
                    DataViewmtk.Rows.Clear();
                }

                if (CkBromReady.Checked)
                {
                    await Task.Run(() => MtkTask.ReadGPT(token));
                }
                else
                {
                    log.Clear();
                    await Task.Run(() => MtkTask.InitAsync(token));
                    if (CkBromReady.Checked)
                    {
                        await Task.Run(() => MtkTask.ReadGPT(token));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message, Status.SUCCESS);
            }
            finally
            {
                CkBromReady.Invoke((Action)(() => CkBromReady.Checked = true));
                guna2GradientButton2.Invoke((Action)(() => guna2GradientButton2.Enabled = true));
                guna2GradientButton3.Invoke((Action)(() => guna2GradientButton3.Enabled = true));
                guna2GradientButton1.Invoke((Action)(() => guna2GradientButton1.Enabled = true));
                BtnBrowse.Invoke((Action)(() => BtnBrowse.Enabled = true));
                BtnIdentify.Invoke((Action)(() => BtnIdentify.Enabled = true));

                Logger.Write(" ", Status.SUCCESS, true);
                Logger.Write("Success! You can use Partition Manager", Status.SUCCESS, true);
            }
        }

        private async void guna2GradientButton3_Click_1(object sender, EventArgs e)
        {
            guna2GradientButton3.Enabled = false;
            log.Clear();
            try
            {
                cts = new CancellationTokenSource();
                var token = cts.Token;
                if (CkBromReady.Checked)
                {
                    await Task.Run(() => MtkTask.Erase(token));
                }
                else
                {
                    await Task.Run(() => MtkTask.InitAsync(token));
                    await Task.Run(() => MtkTask.Erase(token));
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message, Status.SUCCESS);
            }
            guna2GradientButton3.Enabled = true;
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Enabled = false;
            log.Clear();
            try
            {
                cts = new CancellationTokenSource();
                var token = cts.Token;
                if (CkBromReady.Checked)
                {
                    await Task.Run(() => MtkTask.Flash(token));
                }
                else
                {
                    await Task.Run(() => MtkTask.InitAsync(token));
                    await Task.Run(() => MtkTask.Flash(token));
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message, Status.SUCCESS);
            }
            finally
            {
                string tmp = Application.StartupPath + "\\tmp";
                if (Directory.Exists(tmp))
                {
                    DirectoryInfo directory = new DirectoryInfo(tmp);
                    foreach (FileInfo File in directory.EnumerateFiles())
                    {
                        File.Delete();
                    }
                    foreach (DirectoryInfo subDirectory in directory.EnumerateDirectories())
                    {
                        subDirectory.Delete(true);
                    }
                    directory.Delete(true);
                }
            }
            guna2GradientButton1.Enabled = true;
        }

        private async void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2GradientButton2.Enabled = false;
            string folder;
            var folderBrowserDialog = new FolderBrowserDialog() { ShowNewFolderButton = true };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                log.Clear();
                folder = folderBrowserDialog.SelectedPath;

                try
                {
                    cts = new CancellationTokenSource();
                    var token = cts.Token;
                    if (CkBromReady.Checked)
                    {
                        await Task.Run(() => MtkTask.Read(folder, token));
                    }
                    else
                    {
                        await Task.Run(() => MtkTask.InitAsync(token));
                        await Task.Run(() => MtkTask.Read(folder, token));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write(ex.Message, Status.SUCCESS);
                }
            }
            guna2GradientButton2.Enabled = true;
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            // 1. Change the URL to '://githubusercontent.com' to get pure text, not HTML.
            string statusUrl = "https://://githubusercontent.com/jeck24India/ROM2box-Android-Flashing-and-Repairing-tool/main/status.txt";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Set a quick timeout (e.g., 5 seconds) so the app doesn't freeze waiting on slow internet
                    client.Timeout = TimeSpan.FromSeconds(5);

                    string statusText = await client.GetStringAsync(statusUrl);

                    // Trim spaces and lowercase it to avoid formatting mistakes
                    if (statusText.Trim().ToLower().Contains("update"))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "https://romprovider.com/rom2box-download/",
                            UseShellExecute = true // Required for .NET Core / modern Windows forms
                        });

                        MessageBox.Show("A critical update is required. Please download the latest version to continue.", "ROM2box Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\cimv2", "Select * FROM Win32_PnPEntity  WHERE Name Like '%9008%'  ");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"].ToString().ToUpper().Contains("9008") == true) ;
                {
                    string str = managementObject["Name"].ToString().Substring(checked(managementObject["Name"].ToString().IndexOf("(") + 1));
                    string str2 = str.Replace(")", "");
                    port.Text = str2;
                    ComboPort.Text = str2;

                }
            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            log.Clear();
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                this.SendLog("please Select Firehose file", new Color?(Color.Black), breakline: false);
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                this.SendLog("please Select firmware folder", new Color?(Color.Black), breakline: false);
            }
            else
            {
                flash.Checked = true;
                this.SendLog("Waiting for Qualcomm Device: ", new Color?(Color.Black), breakline: false);
                timer2.Start();

            }
        }
        private void SendLog(string text, Color? color = null, bool time = true, bool breakline = true)
        {
            if (log.InvokeRequired)
            {
                log.BeginInvoke((Action)(() =>
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        log.AppendText("\r\n");
                    }
                    else
                    {
                        if (time)
                            log.SelectionStart = log.TextLength;
                        log.SelectionLength = 0;
                        log.SelectionColor = color ?? log.ForeColor;
                        if (breakline)
                            log.AppendText(text + "\r\n");
                        else
                            log.AppendText(text);
                        log.SelectionColor = log.ForeColor;
                    }

                }));
            }
            else
            {
                if (string.IsNullOrEmpty(text))
                {
                    log.AppendText("\r\n");
                }
                else
                {
                    if (time)
                        log.SelectionStart = log.TextLength;
                    log.SelectionLength = 0;
                    log.SelectionColor = color ?? log.ForeColor;
                    if (breakline)
                        log.AppendText(text + "\r\n");
                    else
                        log.AppendText(text);
                }
            }
            try
            {
                log.ScrollToCaret();
            }catch{ }
        }
        private void port_TextChanged(object sender, EventArgs e)
        {
            timer2.Stop();
            this.SendLog("Done ✓", new Color?(Color.Orange));
            string str = port.Text;
            if (str.Contains("COM") == true)
            {
                timer5.Start();
                this.loader();
            }
        }
        public async Task<string> emmcdl_classAsync(string cmd)
        {
            Console.WriteLine(cmd);

            var a = new Process();
            a.StartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = "bin/qdl.exe",
                Arguments = cmd,
                RedirectStandardOutput = true,
            };
            var edl_Renamed = a;
            edl_Renamed.Start();

            var output = new StringBuilder();
            string line;
            while ((line = await edl_Renamed.StandardOutput.ReadLineAsync()) != null)
            {
                output.AppendLine(line);
            }

            return output.ToString();
        }
        private async void loader()
        {
            string cmd = " -p \\\\.\\\\\"" + port.Text + "\" -s 13:\"" + textBox2.Text + "\"";
            string table = await emmcdl_classAsync(cmd);
            if (table.Contains("File transferred successfully") == true)
            {
                this.SendLog("Done ✓", new Color?(Color.Orange));
                await this.dowork();
            }
            else
            {
                this.SendLog("Failed", new Color?(Color.Red));
                this.SendLog("Tip: Reset EDL Mod", new Color?(Color.Orange));
                Process.Start("https://romprovider.com/qfil-download-fail-sahara-failqsahara-server-fail/");
            }
        }
        private async void demomod(string text)
        {
            if (log.InvokeRequired)
            {
                log.Invoke((Action)(() =>
                {
                    string str = text + null;
                    if (str.Contains("The handle is invalid.") == true)
                    {
                        this.SendLog("Failed", new Color?(Color.Red));
                    }
                    if (str.Contains("0 The operation completed successfully.") == true)
                    {
                        this.SendLog("Done ✓", new Color?(Color.Cyan));
                        this.SendLog("====================================================", new Color?(Color.Cyan));
                    }
                    if (str.Contains("MFR_ID") == true)
                    {
                        string str2 = str.Replace(": INFO: TARGET SAID:", "").Replace("%}", "").Replace(" ", "").Replace("'", "");
                        str2 = str2.Substring(str2.IndexOf(str2.Substring(8)));
                        this.SendLog("  " + str2, new Color?(Color.Yellow));

                    }
                    if (str.Contains("Product name") == true)
                    {
                        string str2 = str.Replace(": INFO: TARGET SAID:", "").Replace("Product name", "Board_Name ").Replace("%}", "").Replace(" ", "").Replace("'", "");
                        str2 = str2.Substring(str2.IndexOf(str2.Substring(8)));
                        this.SendLog("  " + str2, new Color?(Color.Yellow));

                    }
                    if (str.Contains("storage_info") == true)
                    {
                        string str2 = str.Replace("INFO:", "").Replace(": INFO: TARGET SAID:", "").Replace("{", "").Replace("INFO:", "").Replace(" ", "").Replace(this.textBox22.Text, "  ").Replace("}}", "").Replace(":", "=").Replace("'", "").Replace(",", "" + Environment.NewLine);
                        str2 = str2.Substring(str2.IndexOf(str2.Substring(8)));
                        string str3 = str2.Replace("  storage_info  =  total_blocks  ", "Total Blocks").Replace("=TARGETSAID=", "");
                        this.SendLog("  " + str3, new Color?(Color.Yellow));

                        
                    }
                }));
                RichTextBox.CheckForIllegalCrossThreadCalls = false;
            }

        }
        private void erasedb(string text)
        {
            if (log.InvokeRequired)
            {
                log.Invoke((Action)(() =>
                {
                    string str = text + null;
                    string s1 = str.Replace(" INFO", "").Replace("1", "").Replace("9", "").Replace("8", "").Replace("7", "").Replace("6", "").Replace("5", "").Replace("4", "").Replace("3", "").Replace("2", "").Replace("0", "").Replace("{", "").Replace("('", "").Replace("')", "").Replace("{", "").Replace("}", "").Replace("INFO:", "").Replace("In handleProgram", "Writing > ").Replace("In handleRead", "Reading > ").Replace("Dumping data to file", "Reading: ");
                    if (str.Contains("ERROR:") == true)
                    {
                        this.SendLog(str, new Color?(Color.Red));
                    }
                    if (str.Contains("fail:") == true)
                    {
                        this.SendLog(str, new Color?(Color.Red));
                    }
                    if (str.Contains("Failed:") == true)
                    {
                        this.SendLog(str, new Color?(Color.Red));
                    }
                    if (str.Contains("All Finished Successfully") == true)
                    {
                        this.SendLog("Done ✓", new Color?(Color.Orange));
                    }
                    if (str.Contains("The operation completed successfully.") == true)
                    {
                        this.SendLog("  Done ✓", new Color?(Color.Cyan));
                    }
                    if (str.Contains("All Not Finished Successfully") == true)
                    {
                        this.SendLog("Failed", new Color?(Color.Black));
                    }
                    if (str.Contains("target rejected") == true)
                    {
                        this.SendLog(str, new Color?(Color.Black));
                    }
                    if (str.Contains("cannot find the file") == true)
                    {
                        this.SendLog(str, new Color?(Color.Black));
                    }
                    if (str.Contains("Failed to open device,") == true)
                    {
                        this.SendLog(str, new Color?(Color.Black));
                    }
                    if (str.Contains("The handle is invalid") == true)
                    {
                        this.SendLog("Failed!", new Color?(Color.Red));
                    }
                    if (str.Contains("File transferred successfully") == true)
                    {
                        this.SendLog("Done ✓", new Color?(Color.Orange));
                    }
                }));
                RichTextBox.CheckForIllegalCrossThreadCalls = false;
            }
        }
        private void flashpartdb(string text)
        {
            if (log.InvokeRequired)
            {
                log.Invoke((Action)(() =>
                {
                    string str = text + null;
                    string input = str;
                    foreach (string line in input.Split('\n'))
                    {
                        string pattern = @"\((\d+\.\d+ (?:KBps|MBps))\)";
                        MatchCollection matches = Regex.Matches(line, pattern);

                        foreach (Match match in matches)
                        {
                            string extractedValue = match.Groups[1].Value;
                            label_transferrate.Text = "";
                            label_transferrate.Text = extractedValue; // Append to the TextBox
                            Application.DoEvents(); // Allow the UI to update in real-time
                        }
                    }
                    foreach (string line in input.Split('\n'))
                    {
                        if (line.Contains("In handleRead"))
                        {

                            string pattern = @"'([^']+)'";
                            Match match = Regex.Match(line, pattern);

                            if (match.Success)
                            {
                                string extractedValue = match.Groups[1].Value;
                                this.SendLog("Reading > " + extractedValue + ": ", new Color?(Color.Black), breakline: false);
                                progressBar1.Value = 5;
                                Application.DoEvents(); // Allow the UI to update in real-time
                            }
                        }
                    }
                    foreach (string line in input.Split('\n'))
                    {
                        string pattern = @"is (\d+(\.\d+)?) (\w{2})";
                        MatchCollection matches = Regex.Matches(line, pattern);

                        foreach (Match match in matches)
                        {
                            string extractedValue = match.Groups[0].Value; // Use Groups[0] to get the entire match
                            label_totalsize.Text = "";
                            label_totalsize.Text = extractedValue; // Set the label text
                            Application.DoEvents(); // Allow the UI to update in real-time
                        }
                    }
                    foreach (string line in input.Split('\n'))
                    {
                        string pattern = @"\{percent files transferred\s+(\d+\.\d+)%\}";
                        Match match = Regex.Match(line, pattern);

                        if (match.Success)
                        {
                            string extractedValue = match.Groups[1].Value;
                            int percentage = (int)Math.Round(double.Parse(extractedValue));
                            customprogressBar1.Value = percentage; // Update the ProgressBar
                            Application.DoEvents(); // Allow the UI to update in real-time
                        }
                    }
                    HashSet<string> processedLines = new HashSet<string>(); // Store processed lines
                    foreach (string line in input.Split('\n'))
                    {
                        if (line.Contains("In handleProgram"))
                        {
                            // Check if this line hasn't been processed before
                            if (!processedLines.Contains(line))
                            {
                                string pattern = @"'([^']+)'";
                                Match match = Regex.Match(line, pattern);

                                if (match.Success)
                                {
                                    string extractedValue = match.Groups[1].Value;
                                    this.SendLog("Writing > " + extractedValue + ": ", new Color?(Color.Black), breakline: false);
                                    progressBar1.Value = 5;
                                    Application.DoEvents(); // Allow the UI to update in real-time
                                }

                                // Add the line to the processed set
                                processedLines.Add(line);
                            }
                        }
                    }
                    foreach (string line in input.Split('\n'))
                    {
                        string pattern = @"INFO: <read> \((\d+\.\d+)KB\) (\d+) sectors from location (\d+) FILE: '([^']+)'";
                        Match match = Regex.Match(line, pattern);

                        if (match.Success)
                        {
                            double readSizeKB = double.Parse(match.Groups[1].Value);
                            int numSectors = int.Parse(match.Groups[2].Value);
                            int location = int.Parse(match.Groups[3].Value);

                            double progress = (location * 100.0) / numSectors;
                            progressBar1.BeginInvoke((Action)(() =>
                            {
                                progressBar1.Value = (int)Math.Round(progress);
                            }));

                            Application.DoEvents(); // Allow the UI to update in real-time
                        }
                    }
                    string s1 = str.Replace(" INFO", "").Replace(":", "").Replace("1", "").Replace("9", "").Replace("8", "").Replace("7", "").Replace("6", "").Replace("5", "").Replace("4", "").Replace("3", "").Replace("2", "").Replace("0", "").Replace("{", "").Replace("('", "").Replace("')", "").Replace("{", "").Replace("}", "").Replace("INFO:", "").Replace("In handleProgram", "Writing > ").Replace("In handleRead", "    Reading > ").Replace("Dumping data to file", "Reading: ");
                    if (s1.Contains("SUCCESS") == true)
                    {
                        this.SendLog("Done ✓", new Color?(Color.Orange));
                        progressBar1.Value = progressBar1.Maximum;
                        Application.DoEvents(); // Allow the UI to update in real-time
                    }
                    if (str.Contains("ERROR:") == true)
                    {
                        this.SendLog(str, new Color?(Color.Red));
                    }
                    if (s1.Contains("All Finished Successfully") == true)
                    {
                        this.SendLog("=========================================================", new Color?(Color.Black));
                        this.SendLog(">>>>>>>>>>>>>>>>>>>>> { SUCCESS }<<<<<<<<<<<<<<<<<<<<<<<<<<", new Color?(Color.Black));
                        this.SendLog("=========================================================", new Color?(Color.Black));
                    }
                }));
                RichTextBox.CheckForIllegalCrossThreadCalls = false;
            }

        }
        private async Task erasepart(string command, IProgress<int> progress)
        {
            progressBar1.Value = 0;
            timer5.Start();
            using (var j = new Process())
            {
                j.StartInfo.UseShellExecute = false;
                j.StartInfo.RedirectStandardOutput = true;
                j.StartInfo.RedirectStandardError = true;
                j.StartInfo.CreateNoWindow = true;
                j.StartInfo.FileName = "cmd.exe";
                j.StartInfo.Arguments = $"/c {command}";

                j.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        erasedb(e.Data);
                    }
                };

                j.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        erasedb(e.Data);
                    }
                };

                j.Start();
                j.BeginOutputReadLine();
                j.BeginErrorReadLine();
                while (!j.HasExited)
                {
                    await Task.Delay(100); // Adjust the delay as needed

                    // Calculate progress based on whether the process has exited or not
                }
            }
            timer5.Stop();
            progressBar1.Value = progressBar1.Maximum;
        }
        private async Task erasedemo(string command, IProgress<int> progress)
        {
            progressBar1.Value = 0;
            timer5.Start();
            using (var p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = $"/c {command}";
                p.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        demomod(e.Data);
                    }
                };

                p.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        demomod(e.Data);
                    }
                };

                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
            }
            timer5.Stop();
            progressBar1.Value = progressBar1.Maximum;
        }
        private async Task flashpart(string command, IProgress<int> progress)
        {
            progressBar1.Value = 0;
            timer5.Start();
            using (var k = new Process())
            {
                k.StartInfo.UseShellExecute = false;
                k.StartInfo.RedirectStandardOutput = true;
                k.StartInfo.RedirectStandardError = true;
                k.StartInfo.CreateNoWindow = true;
                k.StartInfo.FileName = "cmd.exe";
                k.StartInfo.Arguments = $"/c {command}";

                k.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        flashpartdb(e.Data);
                    }
                };

                k.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        flashpartdb(e.Data);
                    }
                };

                k.Start();
                k.BeginOutputReadLine();
                k.BeginErrorReadLine();
                while (!k.HasExited)
                {
                    await Task.Delay(100); // Adjust the delay as needed

                    // Calculate progress based on whether the process has exited or not
                }
            }
            timer5.Stop();
            progressBar1.Value = progressBar1.Maximum;
        }
        private void waitt(int seconds)
        {
            checked
            {
                int num = seconds * 30;
                for (int i = 0; i <= num; i++)
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
            }
        }
        public async Task dowork()
        {
            this.SendLog("Done ✓", new Color?(Color.Orange));
            this.SendLog("Reading Board info", new Color?(Color.Cyan));
            await erasedemo("bin\\fh.exe --port=\\\\.\\\\\"" + port.Text + "\" --getstorageinfo=1 --memoryname=ufs", progress);
            this.waitt(2);
            if (flash.Checked == true)
            {
                try
                {
                    if (checkBox1.Checked == true)
                    {
                        await flashpart("bin\\fh.exe --port=\\\\.\\\\\"" + port.Text + "\" --sendxml=rawprogram0.xml,patch0.xml --search_path=\"" + textBox3.Text + "\" --noprompt --showpercentagecomplete --zlpawarehost=1 --memoryname=emmc --reset", progress);
                    }
                    if (checkBox2.Checked == true)
                    {

                        await flashpart("bin\\fh.exe --port=\\\\.\\\\\"" + port.Text + "\" --sendxml=rawprogram0.xml,rawprogram1.xml,rawprogram2.xml,rawprogram3.xml,rawprogram4.xml,rawprogram5.xml,patch0.xml,patch1.xml,patch2.xml,patch3.xml,patch4.xml,patch5.xml --search_path=\"" + textBox3.Text + "\" --noprompt --setactivepartition=1 --showpercentagecomplete --zlpawarehost=1 --memoryname=ufs --reset", progress);
                    }
                }
                catch
                {
                    this.SendLog("there was a error to Process flash", new Color?(Color.Red));
                }
            }
           
            
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value += 1;
                if (progressBar1.Value == 100)
                {
                    progressBar1.Value = 1;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                progressBar1.Value = 0;
                if (progressBar1.Value == 100)
                {
                    progressBar1.Value = 1;
                }
            }
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    textBox3.Text = dialog.SelectedPath;
                }
            }
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Title = "Firehose File",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                FileName = "*.*",
                Filter = "all file |*.mbn;*.elf ",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fd.FileName;
                
            }
        }

        private void account_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void guna2GradientButton14_Click(object sender, EventArgs e)
        {
            this.dataGridView3.Rows.Clear();
            this.SendLog("Operation : ", new Color?(Color.Black), breakline: false);
            this.waitt(1);
            this.SendLog("Read Partition Table", new Color?(Color.YellowGreen));
            this.SendLog("Connecting to Device: ", new Color?(Color.Black), breakline: false);
            dotemp("bin\\fastboot.exe oem device-info");
            this.SendLog("Done ✓", new Color?(Color.YellowGreen));
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe"; // Passing main function to cmd.exe
            p.StartInfo.Arguments = "/c bin\\fastboot.exe getvar all";
            p.Start();
            string raw_data = p.StandardError.ReadToEnd();
            string raw_data2 = raw_data.Replace("(bootloader) ", "").Replace("partition-size:", "@").Replace(":", "").Replace("	", "").Replace("0x", "");

            string searchFor = "partition-type";
            // split the content of the text variable into lines
            var lines = raw_data2.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None).ToList();

            // Iterate through the lines and remove any containing the search string
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (lines[i].Contains(searchFor)) { lines.RemoveAt(i); }
            }

            //  Join the remaining lines back into a single string
            string newstr = string.Join(System.Environment.NewLine, lines);
            string A = newstr;
            string str = A.Substring(A.IndexOf("@") + -0);
            string str2 = str.Replace("@", "");
            if (str2.Contains("serialno"))
                str2 = str2.Substring(0, str2.LastIndexOf("serialno"));
            using (StreamWriter writetext = new StreamWriter("bin\\demo.txt"))
            {
                writetext.WriteLine(str2);
            }
            string filePath = "bin\\demo.txt";

            string[] lines2 = File.ReadAllLines(filePath);

            foreach (string line in lines2)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine))
                {
                    continue;
                }

                string[] parts = trimmedLine.Split(' ');
                if (parts.Length == 2)
                {
                    string currentName = parts[0].Trim();
                    string currentValue = parts[1].Trim();
                    dataGridView3.Rows.Add(false, currentName, currentValue);
                }
                else if (parts.Length == 1)
                {
                    string currentName = parts[0].Trim();
                    dataGridView3.Rows.Add(false, currentName, "");
                }
                else
                {
                    // Handle other cases or ignore lines with more than two parts
                }
            }
        }

        private void guna2GradientButton17_Click(object sender, EventArgs e)
        {
            this.SendLog("====================================================", new Color?(Color.Black));
            this.SendLog("Connecting to Device: ", new Color?(Color.Black), breakline: false);
            dotemp("bin\\fastboot.exe oem device-info");
            this.SendLog("Done ✓", new Color?(Color.Yellow));
            if (mycheck46.Checked == true)
            {
                runadb("bin\\fastboot.exe reboot fastboot");
            }
            if (mycheck37.Checked == true)
            {
                runadb("bin\\fastboot.exe getvar all");
            }
            if (mycheck36.Checked == true)
            {
                runadb("bin\\fastboot.exe reboot");
            }
            if (mycheck35.Checked == true)
            {
                runadb("bin\\fastboot.exe flashing unlock");
            }
            if (mycheck34.Checked == true)
            {
                runadb("bin\\fastboot.exe oem unlock");
            }
            if (mycheck33.Checked == true)
            {
                runadb("bin\\fastboot.exe oem unlock-go");
            }
            if (mycheck32.Checked == true)
            {
                runadb("bin\\fastboot.exe oem edl");
            }
            if (mycheck31.Checked == true)
            {
                runadb("bin\\fastboot.exe oem enter-dload");
            }
            if (mycheck30.Checked == true)
            {
                runadb("bin\\python\\edl.exe reboot-edl");
            }
            if (mycheck27.Checked == true)
            {
                runadb("bin\\fastboot.exe flashing unlock_critical");
                runadb("bin\\fastboot.exe oem unlock_critical");
            }
            if (mycheck26.Checked == true)
            {
                runadb("bin\\fastboot.exe erase userdata");
            }
            customprogressBar1.Value = customprogressBar1.Maximum;
            this.waitt(2);
            this.SendLog("====================================================", new Color?(Color.Black));
        }

        private void guna2GradientButton15_Click(object sender, EventArgs e)
        {
            log.Clear();
            string block = dataGridView3.CurrentRow.Cells[1].Value != null ? dataGridView3.CurrentRow.Cells[2].Value.ToString() : "";
            string partition = dataGridView3.CurrentRow.Cells[1].Value != null ? dataGridView3.CurrentRow.Cells[1].Value.ToString() : "";
            DialogResult dialogResult = this.openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                customprogressBar1.Value = 10;
                runadb("bin\\fastboot.exe flash \"" + partition + "\" \"" + openFileDialog1.FileName + "\"");
                customprogressBar1.Value = 100;
            }
        }

        private void guna2GradientButton16_Click(object sender, EventArgs e)
        {
            log.Clear();
            string block = dataGridView3.CurrentRow.Cells[1].Value != null ? dataGridView3.CurrentRow.Cells[2].Value.ToString() : "";
            string partition = dataGridView3.CurrentRow.Cells[1].Value != null ? dataGridView3.CurrentRow.Cells[1].Value.ToString() : "";
            this.SendLog("Erasing " + partition, new Color?(Color.GreenYellow));
            customprogressBar1.Value = 10;
            runadb("bin\\fastboot.exe erase \"" + partition + "\"");
            customprogressBar1.Value = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/ROM2box_Logs");
        }

    }
}
