
using System.Drawing;
using System.Windows.Forms;

namespace mtkclient
{
    partial class Main
    {

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.CkAutoReboot = new System.Windows.Forms.CheckBox();
            this.CkBromReady = new System.Windows.Forms.CheckBox();
            this.ComboPort = new System.Windows.Forms.ComboBox();
            this.ButtonSTOP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_status = new System.Windows.Forms.Label();
            this.label_transferrate = new System.Windows.Forms.Label();
            this.lb_transferrate = new System.Windows.Forms.Label();
            this.label_writensize = new System.Windows.Forms.Label();
            this.lb_writensize = new System.Windows.Forms.Label();
            this.label_totalsize = new System.Windows.Forms.Label();
            this.lb_totalsize = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button1 = new System.Windows.Forms.Button();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BtnIdentify = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnEMI1 = new System.Windows.Forms.Button();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEMI = new System.Windows.Forms.TextBox();
            this.TxtIMGBin = new System.Windows.Forms.TextBox();
            this.CkList = new System.Windows.Forms.CheckBox();
            this.DataViewmtk = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customprogressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.flash = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2GradientButton6 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton5 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton4 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.guna2GradientButton7 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.guna2GradientButton16 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.headerCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_sector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GradientButton15 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.guna2GradientButton17 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.mycheck35 = new System.Windows.Forms.RadioButton();
            this.mycheck34 = new System.Windows.Forms.RadioButton();
            this.mycheck33 = new System.Windows.Forms.RadioButton();
            this.mycheck46 = new System.Windows.Forms.RadioButton();
            this.mycheck30 = new System.Windows.Forms.RadioButton();
            this.mycheck31 = new System.Windows.Forms.RadioButton();
            this.mycheck32 = new System.Windows.Forms.RadioButton();
            this.mycheck27 = new System.Windows.Forms.RadioButton();
            this.mycheck36 = new System.Windows.Forms.RadioButton();
            this.mycheck26 = new System.Windows.Forms.RadioButton();
            this.mycheck37 = new System.Windows.Forms.RadioButton();
            this.guna2GradientButton14 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.p1 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.port = new System.Windows.Forms.TextBox();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewmtk)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // CkAutoReboot
            // 
            this.CkAutoReboot.AutoSize = true;
            this.CkAutoReboot.Location = new System.Drawing.Point(16, 29);
            this.CkAutoReboot.Name = "CkAutoReboot";
            this.CkAutoReboot.Size = new System.Drawing.Size(92, 17);
            this.CkAutoReboot.TabIndex = 8;
            this.CkAutoReboot.Text = "Auto Reboot";
            this.CkAutoReboot.UseVisualStyleBackColor = true;
            // 
            // CkBromReady
            // 
            this.CkBromReady.AutoSize = true;
            this.CkBromReady.Location = new System.Drawing.Point(114, 29);
            this.CkBromReady.Name = "CkBromReady";
            this.CkBromReady.Size = new System.Drawing.Size(86, 17);
            this.CkBromReady.TabIndex = 8;
            this.CkBromReady.Text = "Brom Ready";
            this.CkBromReady.UseVisualStyleBackColor = true;
            // 
            // ComboPort
            // 
            this.ComboPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ComboPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboPort.FormattingEnabled = true;
            this.ComboPort.Location = new System.Drawing.Point(0, 0);
            this.ComboPort.Name = "ComboPort";
            this.ComboPort.Size = new System.Drawing.Size(992, 21);
            this.ComboPort.TabIndex = 11;
            this.ComboPort.SelectedIndexChanged += new System.EventHandler(this.ComboPort_SelectedIndexChanged);
            // 
            // ButtonSTOP
            // 
            this.ButtonSTOP.BackColor = System.Drawing.Color.Maroon;
            this.ButtonSTOP.ForeColor = System.Drawing.Color.White;
            this.ButtonSTOP.Location = new System.Drawing.Point(603, 449);
            this.ButtonSTOP.Name = "ButtonSTOP";
            this.ButtonSTOP.Size = new System.Drawing.Size(101, 26);
            this.ButtonSTOP.TabIndex = 0;
            this.ButtonSTOP.Text = "STOP";
            this.ButtonSTOP.UseVisualStyleBackColor = false;
            this.ButtonSTOP.Click += new System.EventHandler(this.ButtonSTOP_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_status);
            this.panel1.Controls.Add(this.label_transferrate);
            this.panel1.Controls.Add(this.lb_transferrate);
            this.panel1.Controls.Add(this.label_writensize);
            this.panel1.Controls.Add(this.lb_writensize);
            this.panel1.Controls.Add(this.label_totalsize);
            this.panel1.Controls.Add(this.lb_totalsize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 22);
            this.panel1.TabIndex = 16;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(600, 6);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(0, 13);
            this.label_status.TabIndex = 7;
            // 
            // label_transferrate
            // 
            this.label_transferrate.AutoSize = true;
            this.label_transferrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_transferrate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_transferrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_transferrate.Location = new System.Drawing.Point(487, 5);
            this.label_transferrate.Name = "label_transferrate";
            this.label_transferrate.Size = new System.Drawing.Size(90, 13);
            this.label_transferrate.TabIndex = 1;
            this.label_transferrate.Text = "0.00 Bytes /s   ";
            // 
            // lb_transferrate
            // 
            this.lb_transferrate.AutoSize = true;
            this.lb_transferrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_transferrate.Location = new System.Drawing.Point(426, 6);
            this.lb_transferrate.Name = "lb_transferrate";
            this.lb_transferrate.Size = new System.Drawing.Size(55, 13);
            this.lb_transferrate.TabIndex = 2;
            this.lb_transferrate.Text = "SPEED : ";
            // 
            // label_writensize
            // 
            this.label_writensize.AutoSize = true;
            this.label_writensize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_writensize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_writensize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_writensize.Location = new System.Drawing.Point(277, 5);
            this.label_writensize.Name = "label_writensize";
            this.label_writensize.Size = new System.Drawing.Size(99, 13);
            this.label_writensize.TabIndex = 3;
            this.label_writensize.Text = "0.00 Bytes           ";
            // 
            // lb_writensize
            // 
            this.lb_writensize.AutoSize = true;
            this.lb_writensize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_writensize.Location = new System.Drawing.Point(200, 5);
            this.lb_writensize.Name = "lb_writensize";
            this.lb_writensize.Size = new System.Drawing.Size(85, 13);
            this.lb_writensize.TabIndex = 4;
            this.lb_writensize.Text = "Write Size : ";
            // 
            // label_totalsize
            // 
            this.label_totalsize.AutoSize = true;
            this.label_totalsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_totalsize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalsize.ForeColor = System.Drawing.Color.Fuchsia;
            this.label_totalsize.Location = new System.Drawing.Point(82, 5);
            this.label_totalsize.Name = "label_totalsize";
            this.label_totalsize.Size = new System.Drawing.Size(99, 13);
            this.label_totalsize.TabIndex = 5;
            this.label_totalsize.Text = "0.00 Bytes           ";
            // 
            // lb_totalsize
            // 
            this.lb_totalsize.AutoSize = true;
            this.lb_totalsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_totalsize.Location = new System.Drawing.Point(13, 5);
            this.lb_totalsize.Name = "lb_totalsize";
            this.lb_totalsize.Size = new System.Drawing.Size(85, 13);
            this.lb_totalsize.TabIndex = 6;
            this.lb_totalsize.Text = "Total Size : ";
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.log.Dock = System.Windows.Forms.DockStyle.Right;
            this.log.Location = new System.Drawing.Point(587, 21);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(405, 460);
            this.log.TabIndex = 18;
            this.log.Text = "";
            this.log.TextChanged += new System.EventHandler(this.log_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(13, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 420);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage1.Controls.Add(this.textBox22);
            this.tabPage1.Controls.Add(this.guna2GradientButton1);
            this.tabPage1.Controls.Add(this.guna2GradientButton3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.guna2GradientButton2);
            this.tabPage1.Controls.Add(this.BtnIdentify);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.BtnEMI1);
            this.tabPage1.Controls.Add(this.BtnBrowse);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TxtEMI);
            this.tabPage1.Controls.Add(this.TxtIMGBin);
            this.tabPage1.Controls.Add(this.CkList);
            this.tabPage1.Controls.Add(this.DataViewmtk);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(556, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MTK Client";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(514, 164);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(36, 20);
            this.textBox22.TabIndex = 154;
            this.textBox22.Text = "\"";
            this.textBox22.Visible = false;
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderRadius = 3;
            this.guna2GradientButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton1.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton1.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton1.Location = new System.Drawing.Point(407, 352);
            this.guna2GradientButton1.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(143, 35);
            this.guna2GradientButton1.TabIndex = 151;
            this.guna2GradientButton1.Text = "FLASH";
            this.guna2GradientButton1.UseTransparentBackground = true;
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // guna2GradientButton3
            // 
            this.guna2GradientButton3.Animated = true;
            this.guna2GradientButton3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.BorderRadius = 3;
            this.guna2GradientButton3.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton3.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton3.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton3.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton3.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton3.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton3.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton3.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton3.Location = new System.Drawing.Point(9, 352);
            this.guna2GradientButton3.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton3.Name = "guna2GradientButton3";
            this.guna2GradientButton3.Size = new System.Drawing.Size(135, 35);
            this.guna2GradientButton3.TabIndex = 153;
            this.guna2GradientButton3.Text = "ERASE";
            this.guna2GradientButton3.UseTransparentBackground = true;
            this.guna2GradientButton3.Click += new System.EventHandler(this.guna2GradientButton3_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(451, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 25);
            this.button1.TabIndex = 38;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.Animated = true;
            this.guna2GradientButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BorderRadius = 3;
            this.guna2GradientButton2.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton2.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton2.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton2.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton2.Location = new System.Drawing.Point(216, 352);
            this.guna2GradientButton2.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(143, 35);
            this.guna2GradientButton2.TabIndex = 152;
            this.guna2GradientButton2.Text = "READ";
            this.guna2GradientButton2.UseTransparentBackground = true;
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // BtnIdentify
            // 
            this.BtnIdentify.Animated = true;
            this.BtnIdentify.BackColor = System.Drawing.Color.Transparent;
            this.BtnIdentify.BorderColor = System.Drawing.Color.Transparent;
            this.BtnIdentify.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.BtnIdentify.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.BtnIdentify.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnIdentify.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.BtnIdentify.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnIdentify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnIdentify.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnIdentify.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnIdentify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnIdentify.FillColor = System.Drawing.Color.Maroon;
            this.BtnIdentify.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnIdentify.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIdentify.ForeColor = System.Drawing.Color.White;
            this.BtnIdentify.ImageSize = new System.Drawing.Size(118, 24);
            this.BtnIdentify.Location = new System.Drawing.Point(407, 188);
            this.BtnIdentify.Margin = new System.Windows.Forms.Padding(1);
            this.BtnIdentify.Name = "BtnIdentify";
            this.BtnIdentify.Size = new System.Drawing.Size(143, 30);
            this.BtnIdentify.TabIndex = 150;
            this.BtnIdentify.Text = "Connect Device";
            this.BtnIdentify.UseTransparentBackground = true;
            this.BtnIdentify.Click += new System.EventHandler(this.guna2GradientButton3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Scatter File";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Location = new System.Drawing.Point(117, 257);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 20);
            this.textBox1.TabIndex = 36;
            // 
            // BtnEMI1
            // 
            this.BtnEMI1.BackColor = System.Drawing.Color.Purple;
            this.BtnEMI1.ForeColor = System.Drawing.Color.White;
            this.BtnEMI1.Location = new System.Drawing.Point(451, 283);
            this.BtnEMI1.Name = "BtnEMI1";
            this.BtnEMI1.Size = new System.Drawing.Size(99, 25);
            this.BtnEMI1.TabIndex = 34;
            this.BtnEMI1.Text = "Browse";
            this.BtnEMI1.UseVisualStyleBackColor = false;
            this.BtnEMI1.Click += new System.EventHandler(this.BtnEmi_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.BackColor = System.Drawing.Color.Purple;
            this.BtnBrowse.Enabled = false;
            this.BtnBrowse.ForeColor = System.Drawing.Color.White;
            this.BtnBrowse.Location = new System.Drawing.Point(451, 314);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(99, 27);
            this.BtnBrowse.TabIndex = 35;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = false;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Custom Preloader";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Firmware Folder";
            // 
            // TxtEMI
            // 
            this.TxtEMI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtEMI.Location = new System.Drawing.Point(117, 286);
            this.TxtEMI.Name = "TxtEMI";
            this.TxtEMI.Size = new System.Drawing.Size(328, 20);
            this.TxtEMI.TabIndex = 30;
            // 
            // TxtIMGBin
            // 
            this.TxtIMGBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtIMGBin.Location = new System.Drawing.Point(117, 318);
            this.TxtIMGBin.Name = "TxtIMGBin";
            this.TxtIMGBin.Size = new System.Drawing.Size(328, 20);
            this.TxtIMGBin.TabIndex = 31;
            // 
            // CkList
            // 
            this.CkList.AutoSize = true;
            this.CkList.Location = new System.Drawing.Point(4, 11);
            this.CkList.Name = "CkList";
            this.CkList.Size = new System.Drawing.Size(15, 14);
            this.CkList.TabIndex = 10;
            this.CkList.UseVisualStyleBackColor = true;
            this.CkList.CheckedChanged += new System.EventHandler(this.CkList_CheckedChanged);
            // 
            // DataViewmtk
            // 
            this.DataViewmtk.AllowUserToAddRows = false;
            this.DataViewmtk.AllowUserToDeleteRows = false;
            this.DataViewmtk.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataViewmtk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewmtk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.part,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.DataViewmtk.Location = new System.Drawing.Point(-1, 6);
            this.DataViewmtk.Name = "DataViewmtk";
            this.DataViewmtk.RowHeadersVisible = false;
            this.DataViewmtk.RowTemplate.Height = 25;
            this.DataViewmtk.Size = new System.Drawing.Size(557, 240);
            this.DataViewmtk.TabIndex = 9;
            this.DataViewmtk.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataViewmtk_CellContentDoubleClick);
            // 
            // Column0
            // 
            this.Column0.HeaderText = "";
            this.Column0.Name = "Column0";
            this.Column0.Width = 20;
            // 
            // part
            // 
            this.part.HeaderText = "Partitions";
            this.part.Name = "part";
            this.part.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Offsets";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Sizes";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Filename";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Index";
            this.Column3.Name = "Column3";
            this.Column3.Width = 280;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(556, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Qualcomm";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.customprogressBar1);
            this.groupBox1.Controls.Add(this.flash);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.guna2GradientButton6);
            this.groupBox1.Controls.Add(this.guna2GradientButton5);
            this.groupBox1.Controls.Add(this.guna2GradientButton4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 379);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Firmware Flash";
            // 
            // customprogressBar1
            // 
            this.customprogressBar1.BackColor = System.Drawing.Color.RosyBrown;
            this.customprogressBar1.FillColor = System.Drawing.Color.Silver;
            this.customprogressBar1.Location = new System.Drawing.Point(0, 199);
            this.customprogressBar1.Name = "customprogressBar1";
            this.customprogressBar1.ProgressColor = System.Drawing.Color.Maroon;
            this.customprogressBar1.ProgressColor2 = System.Drawing.Color.Purple;
            this.customprogressBar1.Size = new System.Drawing.Size(538, 23);
            this.customprogressBar1.TabIndex = 161;
            this.customprogressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // flash
            // 
            this.flash.AutoSize = true;
            this.flash.Location = new System.Drawing.Point(9, 97);
            this.flash.Name = "flash";
            this.flash.Size = new System.Drawing.Size(56, 17);
            this.flash.TabIndex = 159;
            this.flash.Text = "flash";
            this.flash.UseVisualStyleBackColor = true;
            this.flash.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(488, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 17);
            this.checkBox1.TabIndex = 160;
            this.checkBox1.Text = "EMMC";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(428, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(44, 17);
            this.checkBox2.TabIndex = 159;
            this.checkBox2.Text = "UFS";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 157;
            this.label8.Text = "Storage";
            this.label8.Visible = false;
            // 
            // guna2GradientButton6
            // 
            this.guna2GradientButton6.Animated = true;
            this.guna2GradientButton6.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton6.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton6.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton6.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton6.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton6.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton6.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton6.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton6.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton6.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton6.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton6.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton6.Location = new System.Drawing.Point(446, 79);
            this.guna2GradientButton6.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton6.Name = "guna2GradientButton6";
            this.guna2GradientButton6.Size = new System.Drawing.Size(85, 20);
            this.guna2GradientButton6.TabIndex = 156;
            this.guna2GradientButton6.Text = "Choose";
            this.guna2GradientButton6.UseTransparentBackground = true;
            this.guna2GradientButton6.Click += new System.EventHandler(this.guna2GradientButton6_Click);
            // 
            // guna2GradientButton5
            // 
            this.guna2GradientButton5.Animated = true;
            this.guna2GradientButton5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton5.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton5.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton5.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton5.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton5.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton5.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton5.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton5.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton5.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton5.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton5.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton5.Location = new System.Drawing.Point(446, 53);
            this.guna2GradientButton5.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton5.Name = "guna2GradientButton5";
            this.guna2GradientButton5.Size = new System.Drawing.Size(85, 20);
            this.guna2GradientButton5.TabIndex = 155;
            this.guna2GradientButton5.Text = "Choose";
            this.guna2GradientButton5.UseTransparentBackground = true;
            this.guna2GradientButton5.Click += new System.EventHandler(this.guna2GradientButton5_Click);
            // 
            // guna2GradientButton4
            // 
            this.guna2GradientButton4.Animated = true;
            this.guna2GradientButton4.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton4.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton4.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton4.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton4.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton4.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton4.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton4.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton4.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton4.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton4.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton4.Location = new System.Drawing.Point(419, 125);
            this.guna2GradientButton4.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton4.Name = "guna2GradientButton4";
            this.guna2GradientButton4.Size = new System.Drawing.Size(112, 29);
            this.guna2GradientButton4.TabIndex = 154;
            this.guna2GradientButton4.Text = "FLASH";
            this.guna2GradientButton4.UseTransparentBackground = true;
            this.guna2GradientButton4.Click += new System.EventHandler(this.guna2GradientButton4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Firehose File";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Firmware Folder";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(118, 53);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(118, 79);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(314, 20);
            this.textBox3.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(556, 391);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ADB";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.guna2GradientButton7);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(553, 385);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Menu";
            // 
            // guna2GradientButton7
            // 
            this.guna2GradientButton7.Animated = true;
            this.guna2GradientButton7.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton7.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton7.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton7.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton7.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton7.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton7.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton7.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton7.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton7.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton7.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton7.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton7.Location = new System.Drawing.Point(4, 32);
            this.guna2GradientButton7.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton7.Name = "guna2GradientButton7";
            this.guna2GradientButton7.Size = new System.Drawing.Size(545, 36);
            this.guna2GradientButton7.TabIndex = 156;
            this.guna2GradientButton7.Text = "Firmware backup Restore";
            this.guna2GradientButton7.UseTransparentBackground = true;
            this.guna2GradientButton7.Click += new System.EventHandler(this.guna2GradientButton7_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Silver;
            this.tabPage5.Controls.Add(this.guna2GradientButton16);
            this.tabPage5.Controls.Add(this.dataGridView3);
            this.tabPage5.Controls.Add(this.guna2GradientButton15);
            this.tabPage5.Controls.Add(this.groupBox8);
            this.tabPage5.Controls.Add(this.guna2GradientButton14);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(556, 391);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Fastboot";
            // 
            // guna2GradientButton16
            // 
            this.guna2GradientButton16.Animated = true;
            this.guna2GradientButton16.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton16.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton16.BorderRadius = 3;
            this.guna2GradientButton16.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton16.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton16.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton16.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton16.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton16.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton16.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton16.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton16.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton16.FillColor = System.Drawing.Color.Purple;
            this.guna2GradientButton16.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton16.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButton16.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton16.ImageSize = new System.Drawing.Size(118, 20);
            this.guna2GradientButton16.Location = new System.Drawing.Point(318, 183);
            this.guna2GradientButton16.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton16.Name = "guna2GradientButton16";
            this.guna2GradientButton16.Size = new System.Drawing.Size(111, 32);
            this.guna2GradientButton16.TabIndex = 151;
            this.guna2GradientButton16.Text = "ERASE";
            this.guna2GradientButton16.UseTransparentBackground = true;
            this.guna2GradientButton16.Click += new System.EventHandler(this.guna2GradientButton16_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.headerCheckBox,
            this.label,
            this.filename,
            this.start_sector});
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView3.Location = new System.Drawing.Point(0, 219);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView3.Size = new System.Drawing.Size(553, 169);
            this.dataGridView3.TabIndex = 33;
            // 
            // headerCheckBox
            // 
            this.headerCheckBox.FillWeight = 71.06599F;
            this.headerCheckBox.HeaderText = "";
            this.headerCheckBox.MinimumWidth = 20;
            this.headerCheckBox.Name = "headerCheckBox";
            // 
            // label
            // 
            this.label.FillWeight = 104.8223F;
            this.label.HeaderText = "Partition";
            this.label.MinimumWidth = 70;
            this.label.Name = "label";
            // 
            // filename
            // 
            this.filename.FillWeight = 104.8223F;
            this.filename.HeaderText = "Size";
            this.filename.MinimumWidth = 70;
            this.filename.Name = "filename";
            // 
            // start_sector
            // 
            this.start_sector.FillWeight = 104.8223F;
            this.start_sector.HeaderText = "Start-Sector";
            this.start_sector.MinimumWidth = 90;
            this.start_sector.Name = "start_sector";
            // 
            // guna2GradientButton15
            // 
            this.guna2GradientButton15.Animated = true;
            this.guna2GradientButton15.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton15.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton15.BorderRadius = 3;
            this.guna2GradientButton15.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton15.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton15.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton15.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton15.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton15.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton15.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton15.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton15.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton15.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton15.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton15.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButton15.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton15.ImageSize = new System.Drawing.Size(118, 20);
            this.guna2GradientButton15.Location = new System.Drawing.Point(155, 183);
            this.guna2GradientButton15.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton15.Name = "guna2GradientButton15";
            this.guna2GradientButton15.Size = new System.Drawing.Size(123, 32);
            this.guna2GradientButton15.TabIndex = 150;
            this.guna2GradientButton15.Text = "FLASH";
            this.guna2GradientButton15.UseTransparentBackground = true;
            this.guna2GradientButton15.Click += new System.EventHandler(this.guna2GradientButton15_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.guna2GradientButton17);
            this.groupBox8.Controls.Add(this.mycheck35);
            this.groupBox8.Controls.Add(this.mycheck34);
            this.groupBox8.Controls.Add(this.mycheck33);
            this.groupBox8.Controls.Add(this.mycheck46);
            this.groupBox8.Controls.Add(this.mycheck30);
            this.groupBox8.Controls.Add(this.mycheck31);
            this.groupBox8.Controls.Add(this.mycheck32);
            this.groupBox8.Controls.Add(this.mycheck27);
            this.groupBox8.Controls.Add(this.mycheck36);
            this.groupBox8.Controls.Add(this.mycheck26);
            this.groupBox8.Controls.Add(this.mycheck37);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(544, 168);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            // 
            // guna2GradientButton17
            // 
            this.guna2GradientButton17.Animated = true;
            this.guna2GradientButton17.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton17.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton17.BorderRadius = 3;
            this.guna2GradientButton17.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2GradientButton17.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton17.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton17.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton17.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton17.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton17.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton17.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton17.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton17.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton17.FillColor2 = System.Drawing.Color.Purple;
            this.guna2GradientButton17.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton17.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton17.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton17.Location = new System.Drawing.Point(406, 125);
            this.guna2GradientButton17.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton17.Name = "guna2GradientButton17";
            this.guna2GradientButton17.Size = new System.Drawing.Size(111, 32);
            this.guna2GradientButton17.TabIndex = 149;
            this.guna2GradientButton17.Text = "DO JOB";
            this.guna2GradientButton17.UseTransparentBackground = true;
            this.guna2GradientButton17.Click += new System.EventHandler(this.guna2GradientButton17_Click);
            // 
            // mycheck35
            // 
            this.mycheck35.AutoSize = true;
            this.mycheck35.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck35.ForeColor = System.Drawing.Color.Black;
            this.mycheck35.Location = new System.Drawing.Point(344, 68);
            this.mycheck35.Name = "mycheck35";
            this.mycheck35.Size = new System.Drawing.Size(139, 17);
            this.mycheck35.TabIndex = 39;
            this.mycheck35.Text = "unlock bootloader 1";
            this.mycheck35.UseVisualStyleBackColor = true;
            // 
            // mycheck34
            // 
            this.mycheck34.AutoSize = true;
            this.mycheck34.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck34.ForeColor = System.Drawing.Color.Black;
            this.mycheck34.Location = new System.Drawing.Point(344, 43);
            this.mycheck34.Name = "mycheck34";
            this.mycheck34.Size = new System.Drawing.Size(139, 17);
            this.mycheck34.TabIndex = 38;
            this.mycheck34.Text = "unlock bootloader 2";
            this.mycheck34.UseVisualStyleBackColor = true;
            // 
            // mycheck33
            // 
            this.mycheck33.AutoSize = true;
            this.mycheck33.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck33.ForeColor = System.Drawing.Color.Black;
            this.mycheck33.Location = new System.Drawing.Point(344, 19);
            this.mycheck33.Name = "mycheck33";
            this.mycheck33.Size = new System.Drawing.Size(139, 17);
            this.mycheck33.TabIndex = 37;
            this.mycheck33.Text = "unlock bootloader 3";
            this.mycheck33.UseVisualStyleBackColor = true;
            // 
            // mycheck46
            // 
            this.mycheck46.AutoSize = true;
            this.mycheck46.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck46.ForeColor = System.Drawing.Color.Black;
            this.mycheck46.Location = new System.Drawing.Point(12, 91);
            this.mycheck46.Name = "mycheck46";
            this.mycheck46.Size = new System.Drawing.Size(121, 17);
            this.mycheck46.TabIndex = 35;
            this.mycheck46.Text = "reboot fastbootD";
            this.mycheck46.UseVisualStyleBackColor = true;
            // 
            // mycheck30
            // 
            this.mycheck30.AutoSize = true;
            this.mycheck30.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck30.ForeColor = System.Drawing.Color.Black;
            this.mycheck30.Location = new System.Drawing.Point(191, 65);
            this.mycheck30.Name = "mycheck30";
            this.mycheck30.Size = new System.Drawing.Size(97, 17);
            this.mycheck30.TabIndex = 34;
            this.mycheck30.Text = "reboot edl 3";
            this.mycheck30.UseVisualStyleBackColor = true;
            // 
            // mycheck31
            // 
            this.mycheck31.AutoSize = true;
            this.mycheck31.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck31.ForeColor = System.Drawing.Color.Black;
            this.mycheck31.Location = new System.Drawing.Point(191, 42);
            this.mycheck31.Name = "mycheck31";
            this.mycheck31.Size = new System.Drawing.Size(97, 17);
            this.mycheck31.TabIndex = 32;
            this.mycheck31.Text = "reboot edl 2";
            this.mycheck31.UseVisualStyleBackColor = true;
            // 
            // mycheck32
            // 
            this.mycheck32.AutoSize = true;
            this.mycheck32.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck32.ForeColor = System.Drawing.Color.Black;
            this.mycheck32.Location = new System.Drawing.Point(191, 19);
            this.mycheck32.Name = "mycheck32";
            this.mycheck32.Size = new System.Drawing.Size(97, 17);
            this.mycheck32.TabIndex = 31;
            this.mycheck32.Text = "reboot edl 1";
            this.mycheck32.UseVisualStyleBackColor = true;
            // 
            // mycheck27
            // 
            this.mycheck27.AutoSize = true;
            this.mycheck27.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck27.ForeColor = System.Drawing.Color.Black;
            this.mycheck27.Location = new System.Drawing.Point(191, 91);
            this.mycheck27.Name = "mycheck27";
            this.mycheck27.Size = new System.Drawing.Size(181, 17);
            this.mycheck27.TabIndex = 30;
            this.mycheck27.Text = "unlock bootloader critical";
            this.mycheck27.UseVisualStyleBackColor = true;
            // 
            // mycheck36
            // 
            this.mycheck36.AutoSize = true;
            this.mycheck36.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck36.ForeColor = System.Drawing.Color.Black;
            this.mycheck36.Location = new System.Drawing.Point(12, 68);
            this.mycheck36.Name = "mycheck36";
            this.mycheck36.Size = new System.Drawing.Size(103, 17);
            this.mycheck36.TabIndex = 29;
            this.mycheck36.Text = "reboot system";
            this.mycheck36.UseVisualStyleBackColor = true;
            // 
            // mycheck26
            // 
            this.mycheck26.AutoSize = true;
            this.mycheck26.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck26.ForeColor = System.Drawing.Color.Black;
            this.mycheck26.Location = new System.Drawing.Point(11, 42);
            this.mycheck26.Name = "mycheck26";
            this.mycheck26.Size = new System.Drawing.Size(79, 17);
            this.mycheck26.TabIndex = 27;
            this.mycheck26.Text = "Wipe data";
            this.mycheck26.UseVisualStyleBackColor = true;
            // 
            // mycheck37
            // 
            this.mycheck37.AutoSize = true;
            this.mycheck37.Checked = true;
            this.mycheck37.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mycheck37.ForeColor = System.Drawing.Color.Black;
            this.mycheck37.Location = new System.Drawing.Point(12, 19);
            this.mycheck37.Name = "mycheck37";
            this.mycheck37.Size = new System.Drawing.Size(79, 17);
            this.mycheck37.TabIndex = 26;
            this.mycheck37.TabStop = true;
            this.mycheck37.Text = "read info";
            this.mycheck37.UseVisualStyleBackColor = true;
            // 
            // guna2GradientButton14
            // 
            this.guna2GradientButton14.Animated = true;
            this.guna2GradientButton14.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientButton14.BorderThickness = 1;
            this.guna2GradientButton14.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton14.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton14.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton14.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton14.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton14.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton14.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton14.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton14.FillColor = System.Drawing.Color.Maroon;
            this.guna2GradientButton14.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientButton14.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton14.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton14.ImageSize = new System.Drawing.Size(118, 20);
            this.guna2GradientButton14.Location = new System.Drawing.Point(6, 183);
            this.guna2GradientButton14.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton14.Name = "guna2GradientButton14";
            this.guna2GradientButton14.Size = new System.Drawing.Size(126, 32);
            this.guna2GradientButton14.TabIndex = 149;
            this.guna2GradientButton14.Text = "READ GPT";
            this.guna2GradientButton14.UseTransparentBackground = true;
            this.guna2GradientButton14.Click += new System.EventHandler(this.guna2GradientButton14_Click);
            // 
            // p1
            // 
            this.p1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p1.Location = new System.Drawing.Point(0, 503);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(992, 23);
            this.p1.TabIndex = 9;
            this.p1.Value = 100;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 503);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor = System.Drawing.Color.Maroon;
            this.progressBar1.ProgressColor2 = System.Drawing.Color.Purple;
            this.progressBar1.Size = new System.Drawing.Size(992, 23);
            this.progressBar1.TabIndex = 151;
            this.progressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(889, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 26);
            this.button2.TabIndex = 152;
            this.button2.Text = "Join US";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(673, 55);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(224, 20);
            this.port.TabIndex = 153;
            this.port.Visible = false;
            this.port.TextChanged += new System.EventHandler(this.port_TextChanged);
            // 
            // timer5
            // 
            this.timer5.Interval = 1500;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(992, 526);
            this.Controls.Add(this.port);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ButtonSTOP);
            this.Controls.Add(this.log);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.CkBromReady);
            this.Controls.Add(this.CkAutoReboot);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ComboPort);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROM2box V3.5";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewmtk)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public ComboBox ComboPort;
        private Button ButtonSTOP;
        public CheckBox CkBromReady;
        private Panel panel1;
        public Label label_transferrate;
        private Label lb_transferrate;
        public Label label_writensize;
        private Label lb_writensize;
        public Label label_totalsize;
        private Label lb_totalsize;
        public RichTextBox log;
        public CheckBox CkAutoReboot;
        private TabControl tabControl1;
        private TabPage tabPage1;
        public Button BtnEMI1;
        public Button BtnBrowse;
        private Label label3;
        private Label label1;
        public TextBox TxtEMI;
        private TextBox TxtIMGBin;
        private CheckBox CkList;
        public DataGridView DataViewmtk;
        private DataGridViewCheckBoxColumn Column0;
        private DataGridViewTextBoxColumn part;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column3;
        public Button button1;
        private Label label5;
        public TextBox textBox1;
        public Guna.UI2.WinForms.Guna2GradientButton BtnIdentify;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton3;
        internal Label label_status;
        private ProgressBar p1;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar1;
        private Button button2;
        private TabPage tabPage3;
        private GroupBox groupBox1;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton4;
        private Label label2;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox3;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton6;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton5;
        internal Timer timer2;
        private System.ComponentModel.IContainer components;
        private TextBox port;
        private Timer timer5;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label8;
        private CheckBox flash;
        internal TextBox textBox22;
        private Guna.UI2.WinForms.Guna2ProgressBar customprogressBar1;
        private TabPage tabPage4;
        private GroupBox groupBox3;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton7;
        private TabPage tabPage5;
        private GroupBox groupBox8;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton16;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton15;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton14;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton17;
        private RadioButton mycheck35;
        private RadioButton mycheck34;
        private RadioButton mycheck33;
        private RadioButton mycheck46;
        private RadioButton mycheck30;
        private RadioButton mycheck31;
        private RadioButton mycheck32;
        private RadioButton mycheck27;
        private RadioButton mycheck36;
        private RadioButton mycheck26;
        private RadioButton mycheck37;
        internal DataGridView dataGridView3;
        private DataGridViewCheckBoxColumn headerCheckBox;
        private DataGridViewTextBoxColumn label;
        private DataGridViewTextBoxColumn filename;
        private DataGridViewTextBoxColumn start_sector;
        private OpenFileDialog openFileDialog1;
    }
}

