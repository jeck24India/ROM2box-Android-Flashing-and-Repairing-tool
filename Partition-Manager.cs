using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Partition_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.DefaultCellStyle.ForeColor = Color.White;
            Control.CheckForIllegalCrossThreadCalls = false;
            int red = 44;
            int green = 44;
            int blue = 44;
            Color color = Color.FromArgb(red, green, blue);
            dataGridView3.DefaultCellStyle.BackColor = color;
        }
        public class PartitionInfo
        {
            public string PartitionName { get; set; }
            public string Block { get; set; }

            public PartitionInfo(string partitionName, string block)
            {
                PartitionName = partitionName;
                Block = block;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void guna2head_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void Guna2CircleClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void SendLog(string text, Color? color = null, bool time = true, bool breakline = true)
        {
            if (txtlog.InvokeRequired)
            {
                txtlog.BeginInvoke((Action)(() =>
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        txtlog.AppendText("\r\n");
                    }
                    else
                    {
                        if (time)
                            txtlog.SelectionStart = txtlog.TextLength;
                        txtlog.SelectionLength = 0;
                        txtlog.SelectionColor = color ?? txtlog.ForeColor;
                        if (breakline)
                            txtlog.AppendText(text + "\r\n");
                        else
                            txtlog.AppendText(text);
                        txtlog.SelectionColor = txtlog.ForeColor;
                    }

                }));
            }
            else
            {
                if (string.IsNullOrEmpty(text))
                {
                    txtlog.AppendText("\r\n");
                }
                else
                {
                    if (time)
                        txtlog.SelectionStart = txtlog.TextLength;
                    txtlog.SelectionLength = 0;
                    txtlog.SelectionColor = color ?? txtlog.ForeColor;
                    if (breakline)
                        txtlog.AppendText(text + "\r\n");
                    else
                        txtlog.AppendText(text);
                }
            }
            txtlog.ScrollToCaret();
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }
        private void Guna2CircleMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void runadb(string Commands)
        {
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
                this.SendLog(str2);
                string input = str2;
                foreach (string line in input.Split('\n'))
                {
                    string pattern = @"(\d+) bytes transferred in (\d+\.\d+) secs \((\d+) bytes\/sec";
                    MatchCollection matches = Regex.Matches(line, pattern);
                    foreach (Match match in matches)
                    {
                        string extractedValueInBytes = match.Groups[1].Value;
                        if (long.TryParse(extractedValueInBytes, out long totalBytes))
                        {
                            label_totalsize.Text = "";
                            sector.Text = "";
                            double totalMegabytes = totalBytes / (1024.0 * 1024.0);
                            label_totalsize.Text += $"{totalMegabytes:F2} MB "; // Use a space or any other separator between values
                            sector.Text += $"{totalMegabytes:F2} MB ";
                            Application.DoEvents(); // Allow the UI to update in real-time
                        }
                        else
                        {
                            Application.DoEvents();
                        }
                    }
                }
                foreach (string line in input.Split('\n'))
                {
                    string pattern = @"(\d+) bytes transferred in (\d+\.\d+) secs \((\d+) bytes\/sec";
                    MatchCollection matches = Regex.Matches(line, pattern);

                    foreach (Match match in matches)
                    {
                        string speedInBytesPerSec = match.Groups[3].Value;
                        if (double.TryParse(speedInBytesPerSec, out double speedBytesPerSec))
                        {
                            speed.Text = "";
                            double speedKilobytesPerSec = speedBytesPerSec / 1024.0;
                            speed.Text += $"{speedKilobytesPerSec:F2} KB/sec "; // Use a space or any other separator between values
                            Application.DoEvents(); // Allow the UI to update in real-time
                        }
                        else
                        {
                            speed.Text += "Conversion error ";
                            Application.DoEvents();
                        }
                    }
                }
                if (str2.Contains("Permission denied") == true)
                {
                    this.SendLog("Please Allow Root Permission to shell in Magisk app", new Color?(Color.YellowGreen));
                }
            }
            else
            {

            }
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }
        private async void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            txtlog.Clear();
            this.SendLog("Connecting to Device: ", new Color?(Color.White), breakline: false);
            runadb("bin\\adb.exe wait-for-device");
            this.SendLog("OKAY", new Color?(Color.YellowGreen));
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe"; // Passing main function to cmd.exe
            p.StartInfo.Arguments = "/c bin\\adb shell ls -al /dev/block/bootdevice/by-name";
            p.Start();
            string raw_data = p.StandardOutput.ReadToEnd();
            this.SendLog("Reading GPT: ", new Color?(Color.White), breakline: false);
            try
            {
                string inputText = raw_data;

                // Define the regex pattern for extracting partition information
                string regexPattern = @"lrwxrwxrwx\s+\d+\s+\S+\s+\S+\s+\d+\s+(\d{4}-\d{2}-\d{2}\s+\d{2}:\d{2})\s+(\S+)\s+->\s+(\S+)";

                // Create a regex object
                Regex regex = new Regex(regexPattern);

                // Match the regex pattern in the input text
                MatchCollection matches = regex.Matches(inputText);

                // Create a list to store extracted data
                List<PartitionInfo> partitionInfoList = new List<PartitionInfo>();

                foreach (Match match in matches)
                {
                    // Extract information from the matched groups
                    string partitionName = match.Groups[2].Value;
                    string block = match.Groups[3].Value;

                    // Create a PartitionInfo object and add it to the list
                    PartitionInfo partitionInfo = new PartitionInfo(partitionName, block);
                    partitionInfoList.Add(partitionInfo);
                    string filename = partitionName + ".img";
                    dataGridView3.Invoke(new Action(() => dataGridView3.Rows.Add(false, partitionName, filename, block)));

                }
                this.SendLog("OKAY", new Color?(Color.YellowGreen));
            }
            catch
            {
                this.SendLog("uanble to Read GPT");
            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                if (e.ColumnIndex == 2)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Title =
                            "Select Partition File" + dataGridView3.CurrentRow.Cells[1].Value.ToString(),
                        InitialDirectory = Environment.GetFolderPath(
                            Environment.SpecialFolder.MyComputer
                        ),
                        FileName = "*.*",
                        Filter = "ALL FILE  (*.*)|*.*",
                        FilterIndex = 2,
                        RestoreDirectory = true
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView3.CurrentRow.Cells[0].Value = true;
                        dataGridView3.CurrentRow.Cells[2].Value = openFileDialog.FileName;
                    }
                }
            }
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.txtlog.Clear();
            if (dataGridView3.Rows.Count == 0)
            {
                this.SendLog("Please Select Partition First", new Color?(Color.Red));
            }
            else
            {
                try
                {
                    int checkboxColumnIndex = 0;
                    int partitionColumnIndex = 1;
                    int blockColumnIndex = 3;
                    int totalCheckedRows = dataGridView3.Rows
                        .Cast<DataGridViewRow>()
                        .Count(row => IsRowChecked(row, checkboxColumnIndex));
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = totalCheckedRows;
                    progressBar1.Value = 0;

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        DataGridViewCheckBoxCell checkboxCell = row.Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;

                        if (IsRowChecked(row, checkboxColumnIndex))
                        {
                            string partition = row.Cells[partitionColumnIndex].Value != null ? row.Cells[partitionColumnIndex].Value.ToString() : "";
                            string block = row.Cells[blockColumnIndex].Value != null ? row.Cells[blockColumnIndex].Value.ToString() : "";

                            string adbCommand = "bin\\adb.exe shell su -c dd if=" + block + " of=/sdcard/" + partition + ".img";
                            string adbCommand2 = "bin\\adb.exe pull /sdcard/" + partition + ".img backup";
                            string adbCommand3 = "bin\\adb.exe shell rm /sdcard/" + partition + ".img";
                            this.SendLog("Reading " + partition + ": ", new Color?(Color.GreenYellow), breakline: false);
                            await FastbootCommandAsync(adbCommand);
                            this.SendLog("Pulling " + partition + ": ", new Color?(Color.GreenYellow), breakline: false);
                            await FastbootCommandAsync(adbCommand2);
                            this.SendLog("Deleting Local file: ", new Color?(Color.GreenYellow), breakline: false);
                            await FastbootCommandAsync(adbCommand3);
                            this.SendLog("OKAY");

                            // Increment the progress bar value
                            progressBar1.Value++;
                        }
                    }
                    // Reset the progress bar
                    progressBar1.Value = progressBar1.Maximum;
                    this.SendLog("ALL Finished");
                    string s1 = txtlog.Text;
                    if (s1.Contains("Reading abl: /system/bin/sh: su: inaccessible or not found") == true)
                    {
                        
                    }
                }
                catch
                {
                    this.SendLog("unable to Read", new Color?(Color.Red));
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {
                foreach (DataGridViewRow item in dataGridView3.Rows)
                {
                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        item.Cells[0].Value = true;
                    }
                }
                return;
            }
            else
            {
                foreach (DataGridViewRow item in dataGridView3.Rows)
                {
                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        item.Cells[0].Value = false;
                    }
                }
                return;
            }
        }

        private async void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            this.guna2GradientButton3.PerformClick();
            progressBar1.Value = 0;
            checkBox3.Checked = true;
            checkBox3.Checked = false;
            checkBox3.Checked = true;
            // Assuming that the checkbox column is at index 0, and the data columns are at index 1 and 3
            int checkboxColumnIndex = 0;
            int partitionColumnIndex = 1;
            int blockColumnIndex = 3;

            string[] partitionsToUncheck = { "userdata", "last_parti",};

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                string partitionValue = row.Cells[partitionColumnIndex].Value?.ToString();

                if (partitionValue != null && partitionsToUncheck.Contains(partitionValue))
                {
                    DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)row.Cells[checkboxColumnIndex];
                    checkboxCell.Value = false;
                }
            }
            int totalCheckedRows = dataGridView3.Rows
                .Cast<DataGridViewRow>()
                .Count(row => IsRowChecked(row, checkboxColumnIndex));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = totalCheckedRows;
            progressBar1.Value = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = row.Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;

                if (IsRowChecked(row, checkboxColumnIndex))
                {
                    string partition = row.Cells[partitionColumnIndex].Value != null ? row.Cells[partitionColumnIndex].Value.ToString() : "";
                    string block = row.Cells[blockColumnIndex].Value != null ? row.Cells[blockColumnIndex].Value.ToString() : "";

                    string adbCommand = "bin\\adb.exe shell su -c dd if=" + block + " of=/sdcard/" + partition + ".img";
                    string adbCommand2 = "bin\\adb.exe pull /sdcard/" + partition + ".img backup";
                    string adbCommand3 = "bin\\adb.exe shell rm /sdcard/" + partition + ".img";
                    this.SendLog("Reading " + partition + ": ", new Color?(Color.GreenYellow), breakline: false);
                    await FastbootCommandAsync(adbCommand);
                    this.SendLog("Pulling " + partition + ": ", new Color?(Color.GreenYellow), breakline: false);
                    await FastbootCommandAsync(adbCommand2);
                    this.SendLog("Deleting Local file: ", new Color?(Color.GreenYellow), breakline: false);
                    await FastbootCommandAsync(adbCommand3);
                    this.SendLog("OKAY");

                    // Increment the progress bar value
                    progressBar1.Value++;
                }
            }
            // Reset the progress bar
            progressBar1.Value = progressBar1.Maximum;
            this.SendLog("ALL Finished");
            string s1 = txtlog.Text;
            if (s1.Contains("Reading abl: /system/bin/sh: su: inaccessible or not found") == true)
            {
               
            }
        }
        // Helper method to check if a row is checked
        private bool IsRowChecked(DataGridViewRow row, int checkboxColumnIndex)
        {
            DataGridViewCheckBoxCell checkboxCell = row.Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
            return checkboxCell != null && Convert.ToBoolean(checkboxCell.Value);
        }

        private async Task FastbootCommandAsync(string Commands)
        {
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
        }

        private async void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.txtlog.Clear();
            if (dataGridView3.Rows.Count == 0)
            {
                this.SendLog("Please Select Partition First", new Color?(Color.Red));
            }
            else
            {
                progressBar1.Value = 0;
                // Assuming that the checkbox column is at index 0, and the data columns are at index 1 and 3
                int checkboxColumnIndex = 0;
                int partitionColumnIndex = 1;
                int blockColumnIndex = 3;
                int fileColumnIndex = 2;
                int totalCheckedRows = dataGridView3.Rows
                    .Cast<DataGridViewRow>()
                    .Count(row => IsRowChecked(row, checkboxColumnIndex));

                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalCheckedRows;
                progressBar1.Value = 0;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    DataGridViewCheckBoxCell checkboxCell = row.Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;

                    if (IsRowChecked(row, checkboxColumnIndex))
                    {
                        string partition = row.Cells[partitionColumnIndex].Value != null ? row.Cells[partitionColumnIndex].Value.ToString() : "";
                        string block = row.Cells[blockColumnIndex].Value != null ? row.Cells[blockColumnIndex].Value.ToString() : "";
                        string file = row.Cells[fileColumnIndex].Value != null ? row.Cells[fileColumnIndex].Value.ToString() : "";
                        string filename = Path.GetFileName(file);
                        this.SendLog("Pushing " + partition + ": ", new Color?(Color.GreenYellow), breakline: false);
                        string adbCommand2 = "bin\\adb.exe push " + file + " /sdcard/";
                        await FastbootCommandAsync(adbCommand2);
                        this.SendLog("Writing " + partition + ": ", new Color?(Color.GreenYellow), breakline: false);
                        string adbCommand = "bin\\adb.exe shell su -c dd if=/sdcard/" + filename + " of=" + block;
                        await FastbootCommandAsync(adbCommand);
                        this.SendLog("Deleting Local File " + partition + ": ", new Color?(Color.GreenYellow), breakline: false);
                        string adbCommand3 = "bin\\adb.exe shell rm /sdcard/" + partition + ".img";
                        this.SendLog("OKAY");
                        await FastbootCommandAsync(adbCommand3);
                        // Increment the progress bar value
                        progressBar1.Value++;
                    }
                }

                // Reset the progress bar
                progressBar1.Value = progressBar1.Maximum;
                this.SendLog("ALL Finished");
                string s1 = txtlog.Text;
                if (s1.Contains("Reading abl: /system/bin/sh: su: inaccessible or not found") == true)
                {
                    
                }
            }
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Developed by ROMProvider.COM for Community Support, Would You Like to Support Developers?", "About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start("https://paypal.me/rom2support");
            }
        }
    }
}
