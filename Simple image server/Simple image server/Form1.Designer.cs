namespace Simple_image_server
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartOnBoot = new System.Windows.Forms.Button();
            this.chkAutostart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllowremoteAccess = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnServertoggle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbLists = new System.Windows.Forms.ListBox();
            this.btnAddNewList = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbElementsInList = new System.Windows.Forms.ListBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DarkMode = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Simple image server";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 762);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1534, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(105, 17);
            this.toolStripStatusLabel1.Text = "Server not running";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DarkMode);
            this.groupBox1.Controls.Add(this.btnStartOnBoot);
            this.groupBox1.Controls.Add(this.chkAutostart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkAllowremoteAccess);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.btnServertoggle);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(1518, 58);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnStartOnBoot
            // 
            this.btnStartOnBoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartOnBoot.Location = new System.Drawing.Point(1286, 16);
            this.btnStartOnBoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartOnBoot.Name = "btnStartOnBoot";
            this.btnStartOnBoot.Size = new System.Drawing.Size(136, 34);
            this.btnStartOnBoot.TabIndex = 6;
            this.btnStartOnBoot.Text = "button1";
            this.btnStartOnBoot.UseVisualStyleBackColor = true;
            this.btnStartOnBoot.Click += new System.EventHandler(this.btnStartOnBoot_Click);
            // 
            // chkAutostart
            // 
            this.chkAutostart.AutoSize = true;
            this.chkAutostart.Location = new System.Drawing.Point(255, 26);
            this.chkAutostart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAutostart.Name = "chkAutostart";
            this.chkAutostart.Size = new System.Drawing.Size(238, 17);
            this.chkAutostart.TabIndex = 5;
            this.chkAutostart.Text = "Autostart server (Will minimize to tray on start)";
            this.chkAutostart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // chkAllowremoteAccess
            // 
            this.chkAllowremoteAccess.AutoSize = true;
            this.chkAllowremoteAccess.Location = new System.Drawing.Point(13, 26);
            this.chkAllowremoteAccess.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAllowremoteAccess.Name = "chkAllowremoteAccess";
            this.chkAllowremoteAccess.Size = new System.Drawing.Size(120, 17);
            this.chkAllowremoteAccess.TabIndex = 3;
            this.chkAllowremoteAccess.Text = "Allow remoteaccess";
            this.chkAllowremoteAccess.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(178, 24);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(68, 20);
            this.txtPort.TabIndex = 2;
            // 
            // btnServertoggle
            // 
            this.btnServertoggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServertoggle.Location = new System.Drawing.Point(1426, 16);
            this.btnServertoggle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnServertoggle.Name = "btnServertoggle";
            this.btnServertoggle.Size = new System.Drawing.Size(83, 34);
            this.btnServertoggle.TabIndex = 1;
            this.btnServertoggle.Text = "Start Server";
            this.btnServertoggle.UseVisualStyleBackColor = true;
            this.btnServertoggle.Click += new System.EventHandler(this.btnServertoggle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lbLists);
            this.groupBox2.Controls.Add(this.btnAddNewList);
            this.groupBox2.Location = new System.Drawing.Point(8, 70);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(395, 682);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lists";
            // 
            // lbLists
            // 
            this.lbLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLists.FormattingEnabled = true;
            this.lbLists.Location = new System.Drawing.Point(13, 16);
            this.lbLists.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbLists.Name = "lbLists";
            this.lbLists.Size = new System.Drawing.Size(371, 628);
            this.lbLists.TabIndex = 1;
            this.lbLists.SelectedIndexChanged += new System.EventHandler(this.lbLists_SelectedIndexChanged);
            // 
            // btnAddNewList
            // 
            this.btnAddNewList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewList.Location = new System.Drawing.Point(301, 655);
            this.btnAddNewList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.Size = new System.Drawing.Size(83, 23);
            this.btnAddNewList.TabIndex = 0;
            this.btnAddNewList.Text = "Add new list";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnAddNewList_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lbElementsInList);
            this.groupBox3.Controls.Add(this.btnAddToList);
            this.groupBox3.Location = new System.Drawing.Point(407, 70);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(353, 682);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Elements in list";
            // 
            // lbElementsInList
            // 
            this.lbElementsInList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbElementsInList.FormattingEnabled = true;
            this.lbElementsInList.Location = new System.Drawing.Point(4, 16);
            this.lbElementsInList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbElementsInList.Name = "lbElementsInList";
            this.lbElementsInList.Size = new System.Drawing.Size(346, 628);
            this.lbElementsInList.TabIndex = 1;
            this.lbElementsInList.SelectedIndexChanged += new System.EventHandler(this.lbElementsInList_SelectedIndexChanged);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToList.Location = new System.Drawing.Point(299, 659);
            this.btnAddToList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(50, 19);
            this.btnAddToList.TabIndex = 0;
            this.btnAddToList.Text = "Add";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.pbPreview);
            this.groupBox4.Controls.Add(this.txtLog);
            this.groupBox4.Location = new System.Drawing.Point(763, 70);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(762, 682);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log output";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.Location = new System.Drawing.Point(4, 373);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(750, 305);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 3;
            this.pbPreview.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(4, 16);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(751, 354);
            this.txtLog.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DarkMode
            // 
            this.DarkMode.AutoSize = true;
            this.DarkMode.Location = new System.Drawing.Point(499, 24);
            this.DarkMode.Name = "DarkMode";
            this.DarkMode.Size = new System.Drawing.Size(78, 17);
            this.DarkMode.TabIndex = 7;
            this.DarkMode.Text = "Dark mode";
            this.DarkMode.UseVisualStyleBackColor = true;
            this.DarkMode.CheckedChanged += new System.EventHandler(this.DarkMode_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 784);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Simple image server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAllowremoteAccess;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnServertoggle;
        private System.Windows.Forms.CheckBox chkAutostart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbLists;
        private System.Windows.Forms.Button btnAddNewList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.ListBox lbElementsInList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnStartOnBoot;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.CheckBox DarkMode;
    }
}

