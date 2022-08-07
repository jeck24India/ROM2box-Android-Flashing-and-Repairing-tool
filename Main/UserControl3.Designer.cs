namespace Main
{
    partial class UserControl3
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button41 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox1);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.textBox3);
            this.groupBox8.Controls.Add(this.textBox4);
            this.groupBox8.Controls.Add(this.button41);
            this.groupBox8.Controls.Add(this.button42);
            this.groupBox8.Font = new System.Drawing.Font("Gabriola", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(8, 11);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(696, 382);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Flash Full Pac Firmware via EDL/SPRD USB COM";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.groupBox1.Location = new System.Drawing.Point(4, 255);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(686, 122);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pac Extractor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gabriola", 14.2F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(13, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(601, 70);
            this.label5.TabIndex = 13;
            this.label5.Text = "it\'s Simple use above filed to Select Pac File, Then type any Number in Port Sect" +
    "ion Click Flash, done, \r\nCollect Extracted Pac In bin/ImageFiles Folder";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label2.Location = new System.Drawing.Point(316, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "USB Port";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 199);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(685, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Open Device Manager to Check USB Port and Enter Correct USB Port (only Number) in" +
    " Port Field Then Click Flash";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(18, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(577, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Pac file Connect Your Switched Off Phone to Computer By Pressing Volume up" +
    " + down key";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(398, 54);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(163, 45);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Enter Port Number Only";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(4, 104);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(686, 45);
            this.textBox4.TabIndex = 2;
            // 
            // button41
            // 
            this.button41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button41.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button41.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button41.Image = global::Main.Properties.Resources.flash_15;
            this.button41.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button41.Location = new System.Drawing.Point(574, 54);
            this.button41.Margin = new System.Windows.Forms.Padding(2);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(116, 45);
            this.button41.TabIndex = 1;
            this.button41.Text = "   FLASH";
            this.button41.UseVisualStyleBackColor = false;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // button42
            // 
            this.button42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button42.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.button42.Location = new System.Drawing.Point(4, 54);
            this.button42.Margin = new System.Windows.Forms.Padding(2);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(251, 45);
            this.button42.TabIndex = 0;
            this.button42.Text = "Select file";
            this.button42.UseVisualStyleBackColor = false;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            // 
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox8);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(734, 567);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
    }
}
