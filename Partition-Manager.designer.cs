namespace Partition_Manager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2head = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelform = new System.Windows.Forms.Panel();
            this.Guna2CircleMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Guna2CircleClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton4 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.TextBox();
            this.guna2Button11 = new Guna.UI2.WinForms.Guna2Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtlog = new System.Windows.Forms.RichTextBox();
            this.guna2CustomGradientPanelFooter = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2GradientButton5 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.speed = new System.Windows.Forms.Label();
            this.lb_transferrate = new System.Windows.Forms.Label();
            this.sector = new System.Windows.Forms.Label();
            this.lb_writensize = new System.Windows.Forms.Label();
            this.textBox25 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox28 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_totalsize = new System.Windows.Forms.Label();
            this.totalsize = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.headerCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Partition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Block = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guna2GradientButton4 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelform.SuspendLayout();
            this.guna2CustomGradientPanelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2head
            // 
            this.guna2head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.guna2head.Controls.Add(this.pictureBox1);
            this.guna2head.Controls.Add(this.panelform);
            this.guna2head.Controls.Add(this.label1);
            this.guna2head.Controls.Add(this.checkBox2);
            this.guna2head.Controls.Add(this.comboBox2);
            this.guna2head.Controls.Add(this.guna2Button11);
            this.guna2head.Controls.Add(this.checkBox1);
            this.guna2head.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2head.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2head.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2head.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2head.Location = new System.Drawing.Point(1, 0);
            this.guna2head.Name = "guna2head";
            this.guna2head.Size = new System.Drawing.Size(859, 31);
            this.guna2head.TabIndex = 144;
            this.guna2head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2head_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::mtkclient.Properties.Resources._lock;
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 247;
            this.pictureBox1.TabStop = false;
            // 
            // panelform
            // 
            this.panelform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelform.Controls.Add(this.Guna2CircleMinimize);
            this.panelform.Controls.Add(this.Guna2CircleClose);
            this.panelform.Controls.Add(this.guna2CircleButton4);
            this.panelform.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelform.Location = new System.Drawing.Point(792, 0);
            this.panelform.Name = "panelform";
            this.panelform.Size = new System.Drawing.Size(67, 31);
            this.panelform.TabIndex = 246;
            // 
            // Guna2CircleMinimize
            // 
            this.Guna2CircleMinimize.Animated = true;
            this.Guna2CircleMinimize.BackColor = System.Drawing.Color.Transparent;
            this.Guna2CircleMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Guna2CircleMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Guna2CircleMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Guna2CircleMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Guna2CircleMinimize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(191)))), ((int)(((byte)(79)))));
            this.Guna2CircleMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Guna2CircleMinimize.ForeColor = System.Drawing.Color.White;
            this.Guna2CircleMinimize.Location = new System.Drawing.Point(10, 10);
            this.Guna2CircleMinimize.Name = "Guna2CircleMinimize";
            this.Guna2CircleMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Guna2CircleMinimize.Size = new System.Drawing.Size(10, 10);
            this.Guna2CircleMinimize.TabIndex = 162;
            this.Guna2CircleMinimize.Text = "Guna2CircleMinimize";
            this.Guna2CircleMinimize.UseTransparentBackground = true;
            this.Guna2CircleMinimize.Click += new System.EventHandler(this.Guna2CircleMinimize_Click);
            // 
            // Guna2CircleClose
            // 
            this.Guna2CircleClose.Animated = true;
            this.Guna2CircleClose.BackColor = System.Drawing.Color.Transparent;
            this.Guna2CircleClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Guna2CircleClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Guna2CircleClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Guna2CircleClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Guna2CircleClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(95)))));
            this.Guna2CircleClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Guna2CircleClose.ForeColor = System.Drawing.Color.White;
            this.Guna2CircleClose.Location = new System.Drawing.Point(46, 10);
            this.Guna2CircleClose.Name = "Guna2CircleClose";
            this.Guna2CircleClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Guna2CircleClose.Size = new System.Drawing.Size(10, 10);
            this.Guna2CircleClose.TabIndex = 160;
            this.Guna2CircleClose.Text = "Guna2CircleClose";
            this.Guna2CircleClose.UseTransparentBackground = true;
            this.Guna2CircleClose.Click += new System.EventHandler(this.Guna2CircleClose_Click);
            // 
            // guna2CircleButton4
            // 
            this.guna2CircleButton4.Animated = true;
            this.guna2CircleButton4.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(197)))), ((int)(((byte)(84)))));
            this.guna2CircleButton4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton4.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton4.Location = new System.Drawing.Point(28, 10);
            this.guna2CircleButton4.Name = "guna2CircleButton4";
            this.guna2CircleButton4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton4.Size = new System.Drawing.Size(10, 10);
            this.guna2CircleButton4.TabIndex = 161;
            this.guna2CircleButton4.Text = "guna2CircleButton4";
            this.guna2CircleButton4.UseTransparentBackground = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ROM2Box by ROMProvider.COM";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(1048, 8);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(47, 17);
            this.checkBox2.TabIndex = 132;
            this.checkBox2.Text = "UFS";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox2.ForeColor = System.Drawing.Color.White;
            this.comboBox2.Location = new System.Drawing.Point(163, 10);
            this.comboBox2.Multiline = true;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 20);
            this.comboBox2.TabIndex = 54;
            // 
            // guna2Button11
            // 
            this.guna2Button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button11.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button11.ForeColor = System.Drawing.Color.White;
            this.guna2Button11.Location = new System.Drawing.Point(869, 6);
            this.guna2Button11.Name = "guna2Button11";
            this.guna2Button11.Size = new System.Drawing.Size(113, 19);
            this.guna2Button11.TabIndex = 49;
            this.guna2Button11.Text = "Storage Config";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(987, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 17);
            this.checkBox1.TabIndex = 131;
            this.checkBox1.Text = "EMMC";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // txtlog
            // 
            this.txtlog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.txtlog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtlog.Font = new System.Drawing.Font("Segoe UI", 9.6F);
            this.txtlog.ForeColor = System.Drawing.SystemColors.Info;
            this.txtlog.Location = new System.Drawing.Point(6, 9);
            this.txtlog.Name = "txtlog";
            this.txtlog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtlog.Size = new System.Drawing.Size(315, 406);
            this.txtlog.TabIndex = 145;
            this.txtlog.Text = "Log";
            this.txtlog.WordWrap = false;
            // 
            // guna2CustomGradientPanelFooter
            // 
            this.guna2CustomGradientPanelFooter.Controls.Add(this.guna2GradientButton5);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.speed);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.lb_transferrate);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.sector);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.lb_writensize);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.textBox25);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.textBox28);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.label_totalsize);
            this.guna2CustomGradientPanelFooter.Controls.Add(this.totalsize);
            this.guna2CustomGradientPanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2CustomGradientPanelFooter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2CustomGradientPanelFooter.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2CustomGradientPanelFooter.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2CustomGradientPanelFooter.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2CustomGradientPanelFooter.ForeColor = System.Drawing.Color.White;
            this.guna2CustomGradientPanelFooter.Location = new System.Drawing.Point(0, 477);
            this.guna2CustomGradientPanelFooter.Name = "guna2CustomGradientPanelFooter";
            this.guna2CustomGradientPanelFooter.Size = new System.Drawing.Size(860, 24);
            this.guna2CustomGradientPanelFooter.TabIndex = 146;
            // 
            // guna2GradientButton5
            // 
            this.guna2GradientButton5.Animated = true;
            this.guna2GradientButton5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton5.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton5.BorderThickness = 1;
            this.guna2GradientButton5.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton5.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton5.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton5.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton5.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton5.FillColor2 = System.Drawing.Color.MediumSlateBlue;
            this.guna2GradientButton5.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton5.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton5.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton5.Location = new System.Drawing.Point(788, 1);
            this.guna2GradientButton5.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton5.Name = "guna2GradientButton5";
            this.guna2GradientButton5.Size = new System.Drawing.Size(72, 21);
            this.guna2GradientButton5.TabIndex = 291;
            this.guna2GradientButton5.Text = "About";
            this.guna2GradientButton5.UseTransparentBackground = true;
            this.guna2GradientButton5.Click += new System.EventHandler(this.guna2GradientButton5_Click);
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.speed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.speed.Location = new System.Drawing.Point(486, 5);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(72, 13);
            this.speed.TabIndex = 0;
            this.speed.Text = "0.00 MB/s   ";
            // 
            // lb_transferrate
            // 
            this.lb_transferrate.AutoSize = true;
            this.lb_transferrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_transferrate.Location = new System.Drawing.Point(396, 5);
            this.lb_transferrate.Name = "lb_transferrate";
            this.lb_transferrate.Size = new System.Drawing.Size(81, 13);
            this.lb_transferrate.TabIndex = 0;
            this.lb_transferrate.Text = "Transfer Rate : ";
            // 
            // sector
            // 
            this.sector.AutoSize = true;
            this.sector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sector.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.sector.Location = new System.Drawing.Point(276, 5);
            this.sector.Name = "sector";
            this.sector.Size = new System.Drawing.Size(99, 13);
            this.sector.TabIndex = 0;
            this.sector.Text = "0.00 Bytes           ";
            // 
            // lb_writensize
            // 
            this.lb_writensize.AutoSize = true;
            this.lb_writensize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_writensize.Location = new System.Drawing.Point(199, 5);
            this.lb_writensize.Name = "lb_writensize";
            this.lb_writensize.Size = new System.Drawing.Size(70, 13);
            this.lb_writensize.TabIndex = 0;
            this.lb_writensize.Text = "Writen Size : ";
            // 
            // textBox25
            // 
            this.textBox25.Animated = true;
            this.textBox25.BorderColor = System.Drawing.Color.Black;
            this.textBox25.BorderThickness = 0;
            this.textBox25.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox25.DefaultText = "";
            this.textBox25.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox25.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox25.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox25.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox25.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox25.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox25.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox25.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox25.IconLeft = ((System.Drawing.Image)(resources.GetObject("textBox25.IconLeft")));
            this.textBox25.Location = new System.Drawing.Point(644, 3);
            this.textBox25.Name = "textBox25";
            this.textBox25.PasswordChar = '\0';
            this.textBox25.PlaceholderText = "";
            this.textBox25.SelectedText = "";
            this.textBox25.Size = new System.Drawing.Size(140, 18);
            this.textBox25.TabIndex = 130;
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox28
            // 
            this.textBox28.Animated = true;
            this.textBox28.BorderColor = System.Drawing.Color.Black;
            this.textBox28.BorderThickness = 0;
            this.textBox28.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox28.DefaultText = "";
            this.textBox28.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox28.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox28.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox28.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox28.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox28.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox28.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox28.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox28.Location = new System.Drawing.Point(871, 5);
            this.textBox28.Name = "textBox28";
            this.textBox28.PasswordChar = '\0';
            this.textBox28.PlaceholderText = "";
            this.textBox28.SelectedText = "";
            this.textBox28.Size = new System.Drawing.Size(289, 13);
            this.textBox28.TabIndex = 131;
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_totalsize
            // 
            this.label_totalsize.AutoSize = true;
            this.label_totalsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_totalsize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalsize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label_totalsize.Location = new System.Drawing.Point(81, 5);
            this.label_totalsize.Name = "label_totalsize";
            this.label_totalsize.Size = new System.Drawing.Size(66, 13);
            this.label_totalsize.TabIndex = 0;
            this.label_totalsize.Text = "0.00 Bytes";
            // 
            // totalsize
            // 
            this.totalsize.AutoSize = true;
            this.totalsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalsize.Location = new System.Drawing.Point(12, 5);
            this.totalsize.Name = "totalsize";
            this.totalsize.Size = new System.Drawing.Size(63, 13);
            this.totalsize.TabIndex = 0;
            this.totalsize.Text = "Total Size : ";
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.headerCheckBox,
            this.Partition,
            this.Filename,
            this.Block});
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView3.Location = new System.Drawing.Point(4, 104);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView3.Size = new System.Drawing.Size(521, 367);
            this.dataGridView3.TabIndex = 147;
            this.dataGridView3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellDoubleClick);
            // 
            // headerCheckBox
            // 
            this.headerCheckBox.FillWeight = 56.50751F;
            this.headerCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.headerCheckBox.HeaderText = "";
            this.headerCheckBox.MinimumWidth = 20;
            this.headerCheckBox.Name = "headerCheckBox";
            // 
            // Partition
            // 
            this.Partition.FillWeight = 104.8528F;
            this.Partition.HeaderText = "Partition";
            this.Partition.Name = "Partition";
            // 
            // Filename
            // 
            this.Filename.FillWeight = 104.8528F;
            this.Filename.HeaderText = "Filename";
            this.Filename.Name = "Filename";
            // 
            // Block
            // 
            this.Block.FillWeight = 104.8528F;
            this.Block.HeaderText = "Block";
            this.Block.Name = "Block";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Location = new System.Drawing.Point(36, 109);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(12, 11);
            this.checkBox3.TabIndex = 286;
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.groupBox1.Controls.Add(this.guna2GradientButton4);
            this.groupBox1.Controls.Add(this.guna2GradientButton2);
            this.groupBox1.Controls.Add(this.guna2GradientButton1);
            this.groupBox1.Controls.Add(this.guna2GradientButton3);
            this.groupBox1.Location = new System.Drawing.Point(4, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 66);
            this.groupBox1.TabIndex = 287;
            this.groupBox1.TabStop = false;
            // 
            // guna2GradientButton4
            // 
            this.guna2GradientButton4.Animated = true;
            this.guna2GradientButton4.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton4.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton4.BorderThickness = 1;
            this.guna2GradientButton4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton4.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton4.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton4.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton4.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton4.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2GradientButton4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButton4.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton4.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton4.Location = new System.Drawing.Point(395, 17);
            this.guna2GradientButton4.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton4.Name = "guna2GradientButton4";
            this.guna2GradientButton4.Size = new System.Drawing.Size(122, 32);
            this.guna2GradientButton4.TabIndex = 292;
            this.guna2GradientButton4.Text = "Read ALL";
            this.guna2GradientButton4.UseTransparentBackground = true;
            this.guna2GradientButton4.Click += new System.EventHandler(this.guna2GradientButton4_Click);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.Animated = true;
            this.guna2GradientButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BorderThickness = 1;
            this.guna2GradientButton2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton2.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton2.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.MediumSlateBlue;
            this.guna2GradientButton2.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton2.Location = new System.Drawing.Point(264, 17);
            this.guna2GradientButton2.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(125, 32);
            this.guna2GradientButton2.TabIndex = 291;
            this.guna2GradientButton2.Text = "Flash  Partition";
            this.guna2GradientButton2.UseTransparentBackground = true;
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderThickness = 1;
            this.guna2GradientButton1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton1.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton1.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Cyan;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.MediumOrchid;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton1.Location = new System.Drawing.Point(127, 17);
            this.guna2GradientButton1.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(130, 32);
            this.guna2GradientButton1.TabIndex = 290;
            this.guna2GradientButton1.Text = "Read Partition";
            this.guna2GradientButton1.UseTransparentBackground = true;
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // guna2GradientButton3
            // 
            this.guna2GradientButton3.Animated = true;
            this.guna2GradientButton3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.BorderThickness = 1;
            this.guna2GradientButton3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2GradientButton3.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton3.CustomImages.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton3.FillColor = System.Drawing.Color.DarkOrange;
            this.guna2GradientButton3.FillColor2 = System.Drawing.Color.MediumOrchid;
            this.guna2GradientButton3.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton3.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton3.ImageSize = new System.Drawing.Size(118, 24);
            this.guna2GradientButton3.Location = new System.Drawing.Point(6, 17);
            this.guna2GradientButton3.Margin = new System.Windows.Forms.Padding(1);
            this.guna2GradientButton3.Name = "guna2GradientButton3";
            this.guna2GradientButton3.Size = new System.Drawing.Size(114, 32);
            this.guna2GradientButton3.TabIndex = 289;
            this.guna2GradientButton3.Text = "Read GPT";
            this.guna2GradientButton3.UseTransparentBackground = true;
            this.guna2GradientButton3.Click += new System.EventHandler(this.guna2GradientButton3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.txtlog);
            this.groupBox2.Location = new System.Drawing.Point(531, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 439);
            this.groupBox2.TabIndex = 288;
            this.groupBox2.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.progressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(70)))));
            this.progressBar1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.progressBar1.BorderThickness = 1;
            this.progressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.progressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.progressBar1.Location = new System.Drawing.Point(6, 421);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.progressBar1.ProgressColor2 = System.Drawing.Color.Purple;
            this.progressBar1.ShowText = true;
            this.progressBar1.Size = new System.Drawing.Size(315, 12);
            this.progressBar1.TabIndex = 289;
            this.progressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(860, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.guna2CustomGradientPanelFooter);
            this.Controls.Add(this.guna2head);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADB Partition-Manager";
            this.guna2head.ResumeLayout(false);
            this.guna2head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelform.ResumeLayout(false);
            this.guna2CustomGradientPanelFooter.ResumeLayout(false);
            this.guna2CustomGradientPanelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2head;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Panel panelform;
        internal Guna.UI2.WinForms.Guna2CircleButton Guna2CircleMinimize;
        internal Guna.UI2.WinForms.Guna2CircleButton Guna2CircleClose;
        internal Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton4;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox comboBox2;
        private Guna.UI2.WinForms.Guna2Button guna2Button11;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.RichTextBox txtlog;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanelFooter;
        public System.Windows.Forms.Label speed;
        private System.Windows.Forms.Label lb_transferrate;
        public System.Windows.Forms.Label sector;
        private System.Windows.Forms.Label lb_writensize;
        private Guna.UI2.WinForms.Guna2TextBox textBox25;
        private Guna.UI2.WinForms.Guna2TextBox textBox28;
        public System.Windows.Forms.Label label_totalsize;
        private System.Windows.Forms.Label totalsize;
        internal System.Windows.Forms.DataGridView dataGridView3;
        internal System.Windows.Forms.CheckBox checkBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton3;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton4;
        internal Guna.UI2.WinForms.Guna2ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn headerCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Block;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton5;
    }
}

