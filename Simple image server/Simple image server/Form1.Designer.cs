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
            this.btnSaveSettingsNow = new System.Windows.Forms.Button();
            this.DarkMode = new System.Windows.Forms.CheckBox();
            this.btnStartOnBoot = new System.Windows.Forms.Button();
            this.chkAutostart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllowremoteAccess = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnServertoggle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpListsettings = new System.Windows.Forms.GroupBox();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtListname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numFromMinute = new System.Windows.Forms.NumericUpDown();
            this.numFromHour = new System.Windows.Forms.NumericUpDown();
            this.numToMinute = new System.Windows.Forms.NumericUpDown();
            this.numToHour = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkListTuesday = new System.Windows.Forms.CheckBox();
            this.chkListWednesday = new System.Windows.Forms.CheckBox();
            this.chkListThursday = new System.Windows.Forms.CheckBox();
            this.chkListFriday = new System.Windows.Forms.CheckBox();
            this.chkListSaturday = new System.Windows.Forms.CheckBox();
            this.chkListSunday = new System.Windows.Forms.CheckBox();
            this.chkListMonday = new System.Windows.Forms.CheckBox();
            this.chkListActive = new System.Windows.Forms.CheckBox();
            this.lbLists = new System.Windows.Forms.ListBox();
            this.btnAddNewList = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbElementsInList = new System.Windows.Forms.ListBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenSettingsfolder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chkRandomImage = new System.Windows.Forms.CheckBox();
            this.btnMoveListUp = new System.Windows.Forms.Button();
            this.btnMoveListDown = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtListdescription = new System.Windows.Forms.TextBox();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnDeleteSelectedList = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpListsettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToHour)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 1272);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2095, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(159, 25);
            this.toolStripStatusLabel1.Text = "Server not running";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnOpenSettingsfolder);
            this.groupBox1.Controls.Add(this.btnSaveSettingsNow);
            this.groupBox1.Controls.Add(this.DarkMode);
            this.groupBox1.Controls.Add(this.btnStartOnBoot);
            this.groupBox1.Controls.Add(this.chkAutostart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkAllowremoteAccess);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.btnServertoggle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2071, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnSaveSettingsNow
            // 
            this.btnSaveSettingsNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettingsNow.Location = new System.Drawing.Point(1557, 25);
            this.btnSaveSettingsNow.Name = "btnSaveSettingsNow";
            this.btnSaveSettingsNow.Size = new System.Drawing.Size(160, 52);
            this.btnSaveSettingsNow.TabIndex = 8;
            this.btnSaveSettingsNow.Text = "Save settings now";
            this.btnSaveSettingsNow.UseVisualStyleBackColor = true;
            this.btnSaveSettingsNow.Click += new System.EventHandler(this.btnSaveSettingsNow_Click);
            // 
            // DarkMode
            // 
            this.DarkMode.AutoSize = true;
            this.DarkMode.Location = new System.Drawing.Point(748, 37);
            this.DarkMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DarkMode.Name = "DarkMode";
            this.DarkMode.Size = new System.Drawing.Size(113, 24);
            this.DarkMode.TabIndex = 7;
            this.DarkMode.Text = "Dark mode";
            this.DarkMode.UseVisualStyleBackColor = true;
            this.DarkMode.CheckedChanged += new System.EventHandler(this.DarkMode_CheckedChanged);
            // 
            // btnStartOnBoot
            // 
            this.btnStartOnBoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartOnBoot.Location = new System.Drawing.Point(1723, 25);
            this.btnStartOnBoot.Name = "btnStartOnBoot";
            this.btnStartOnBoot.Size = new System.Drawing.Size(204, 52);
            this.btnStartOnBoot.TabIndex = 6;
            this.btnStartOnBoot.Text = "button1";
            this.btnStartOnBoot.UseVisualStyleBackColor = true;
            this.btnStartOnBoot.Click += new System.EventHandler(this.btnStartOnBoot_Click);
            // 
            // chkAutostart
            // 
            this.chkAutostart.AutoSize = true;
            this.chkAutostart.Location = new System.Drawing.Point(382, 40);
            this.chkAutostart.Name = "chkAutostart";
            this.chkAutostart.Size = new System.Drawing.Size(357, 24);
            this.chkAutostart.TabIndex = 5;
            this.chkAutostart.Text = "Autostart server (Will minimize to tray on start)";
            this.chkAutostart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // chkAllowremoteAccess
            // 
            this.chkAllowremoteAccess.AutoSize = true;
            this.chkAllowremoteAccess.Location = new System.Drawing.Point(20, 40);
            this.chkAllowremoteAccess.Name = "chkAllowremoteAccess";
            this.chkAllowremoteAccess.Size = new System.Drawing.Size(176, 24);
            this.chkAllowremoteAccess.TabIndex = 3;
            this.chkAllowremoteAccess.Text = "Allow remoteaccess";
            this.chkAllowremoteAccess.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(267, 37);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 26);
            this.txtPort.TabIndex = 2;
            // 
            // btnServertoggle
            // 
            this.btnServertoggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServertoggle.Location = new System.Drawing.Point(1933, 25);
            this.btnServertoggle.Name = "btnServertoggle";
            this.btnServertoggle.Size = new System.Drawing.Size(124, 52);
            this.btnServertoggle.TabIndex = 1;
            this.btnServertoggle.Text = "Start Server";
            this.btnServertoggle.UseVisualStyleBackColor = true;
            this.btnServertoggle.Click += new System.EventHandler(this.btnServertoggle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnDeleteSelectedList);
            this.groupBox2.Controls.Add(this.btnMoveListDown);
            this.groupBox2.Controls.Add(this.btnMoveListUp);
            this.groupBox2.Controls.Add(this.grpListsettings);
            this.groupBox2.Controls.Add(this.lbLists);
            this.groupBox2.Controls.Add(this.btnAddNewList);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 1147);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lists";
            // 
            // grpListsettings
            // 
            this.grpListsettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListsettings.Controls.Add(this.txtListdescription);
            this.grpListsettings.Controls.Add(this.label9);
            this.grpListsettings.Controls.Add(this.chkRandomImage);
            this.grpListsettings.Controls.Add(this.label8);
            this.grpListsettings.Controls.Add(this.numMaxWidth);
            this.grpListsettings.Controls.Add(this.label7);
            this.grpListsettings.Controls.Add(this.numInterval);
            this.grpListsettings.Controls.Add(this.label6);
            this.grpListsettings.Controls.Add(this.txtListname);
            this.grpListsettings.Controls.Add(this.label5);
            this.grpListsettings.Controls.Add(this.label4);
            this.grpListsettings.Controls.Add(this.numFromMinute);
            this.grpListsettings.Controls.Add(this.numFromHour);
            this.grpListsettings.Controls.Add(this.numToMinute);
            this.grpListsettings.Controls.Add(this.numToHour);
            this.grpListsettings.Controls.Add(this.label3);
            this.grpListsettings.Controls.Add(this.label2);
            this.grpListsettings.Controls.Add(this.chkListTuesday);
            this.grpListsettings.Controls.Add(this.chkListWednesday);
            this.grpListsettings.Controls.Add(this.chkListThursday);
            this.grpListsettings.Controls.Add(this.chkListFriday);
            this.grpListsettings.Controls.Add(this.chkListSaturday);
            this.grpListsettings.Controls.Add(this.chkListSunday);
            this.grpListsettings.Controls.Add(this.chkListMonday);
            this.grpListsettings.Controls.Add(this.chkListActive);
            this.grpListsettings.Location = new System.Drawing.Point(20, 574);
            this.grpListsettings.Name = "grpListsettings";
            this.grpListsettings.Size = new System.Drawing.Size(554, 508);
            this.grpListsettings.TabIndex = 2;
            this.grpListsettings.TabStop = false;
            this.grpListsettings.Text = "List settings";
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(11, 335);
            this.numInterval.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(94, 26);
            this.numInterval.TabIndex = 20;
            this.numInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(340, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Interval (seconds each list shows same image):";
            // 
            // txtListname
            // 
            this.txtListname.Location = new System.Drawing.Point(105, 55);
            this.txtListname.Name = "txtListname";
            this.txtListname.Size = new System.Drawing.Size(443, 26);
            this.txtListname.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Listname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "-";
            // 
            // numFromMinute
            // 
            this.numFromMinute.Location = new System.Drawing.Point(76, 273);
            this.numFromMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numFromMinute.Name = "numFromMinute";
            this.numFromMinute.Size = new System.Drawing.Size(60, 26);
            this.numFromMinute.TabIndex = 15;
            // 
            // numFromHour
            // 
            this.numFromHour.Location = new System.Drawing.Point(10, 273);
            this.numFromHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numFromHour.Name = "numFromHour";
            this.numFromHour.Size = new System.Drawing.Size(60, 26);
            this.numFromHour.TabIndex = 14;
            // 
            // numToMinute
            // 
            this.numToMinute.Location = new System.Drawing.Point(228, 273);
            this.numToMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numToMinute.Name = "numToMinute";
            this.numToMinute.Size = new System.Drawing.Size(60, 26);
            this.numToMinute.TabIndex = 13;
            this.numToMinute.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // numToHour
            // 
            this.numToHour.Location = new System.Drawing.Point(162, 273);
            this.numToHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numToHour.Name = "numToHour";
            this.numToHour.Size = new System.Drawing.Size(60, 26);
            this.numToHour.TabIndex = 12;
            this.numToHour.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Active weekdays:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Active timeperiod:";
            // 
            // chkListTuesday
            // 
            this.chkListTuesday.AutoSize = true;
            this.chkListTuesday.Location = new System.Drawing.Point(109, 184);
            this.chkListTuesday.Name = "chkListTuesday";
            this.chkListTuesday.Size = new System.Drawing.Size(95, 24);
            this.chkListTuesday.TabIndex = 7;
            this.chkListTuesday.Text = "Tuesday";
            this.chkListTuesday.UseVisualStyleBackColor = true;
            // 
            // chkListWednesday
            // 
            this.chkListWednesday.AutoSize = true;
            this.chkListWednesday.Location = new System.Drawing.Point(211, 184);
            this.chkListWednesday.Name = "chkListWednesday";
            this.chkListWednesday.Size = new System.Drawing.Size(119, 24);
            this.chkListWednesday.TabIndex = 6;
            this.chkListWednesday.Text = "Wednesday";
            this.chkListWednesday.UseVisualStyleBackColor = true;
            // 
            // chkListThursday
            // 
            this.chkListThursday.AutoSize = true;
            this.chkListThursday.Location = new System.Drawing.Point(338, 184);
            this.chkListThursday.Name = "chkListThursday";
            this.chkListThursday.Size = new System.Drawing.Size(100, 24);
            this.chkListThursday.TabIndex = 5;
            this.chkListThursday.Text = "Thursday";
            this.chkListThursday.UseVisualStyleBackColor = true;
            // 
            // chkListFriday
            // 
            this.chkListFriday.AutoSize = true;
            this.chkListFriday.Location = new System.Drawing.Point(447, 184);
            this.chkListFriday.Name = "chkListFriday";
            this.chkListFriday.Size = new System.Drawing.Size(78, 24);
            this.chkListFriday.TabIndex = 4;
            this.chkListFriday.Text = "Friday";
            this.chkListFriday.UseVisualStyleBackColor = true;
            // 
            // chkListSaturday
            // 
            this.chkListSaturday.AutoSize = true;
            this.chkListSaturday.Location = new System.Drawing.Point(6, 214);
            this.chkListSaturday.Name = "chkListSaturday";
            this.chkListSaturday.Size = new System.Drawing.Size(99, 24);
            this.chkListSaturday.TabIndex = 3;
            this.chkListSaturday.Text = "Saturday";
            this.chkListSaturday.UseVisualStyleBackColor = true;
            // 
            // chkListSunday
            // 
            this.chkListSunday.AutoSize = true;
            this.chkListSunday.Location = new System.Drawing.Point(109, 214);
            this.chkListSunday.Name = "chkListSunday";
            this.chkListSunday.Size = new System.Drawing.Size(89, 24);
            this.chkListSunday.TabIndex = 2;
            this.chkListSunday.Text = "Sunday";
            this.chkListSunday.UseVisualStyleBackColor = true;
            // 
            // chkListMonday
            // 
            this.chkListMonday.AutoSize = true;
            this.chkListMonday.Location = new System.Drawing.Point(6, 184);
            this.chkListMonday.Name = "chkListMonday";
            this.chkListMonday.Size = new System.Drawing.Size(91, 24);
            this.chkListMonday.TabIndex = 1;
            this.chkListMonday.Text = "Monday";
            this.chkListMonday.UseVisualStyleBackColor = true;
            // 
            // chkListActive
            // 
            this.chkListActive.AutoSize = true;
            this.chkListActive.Location = new System.Drawing.Point(6, 25);
            this.chkListActive.Name = "chkListActive";
            this.chkListActive.Size = new System.Drawing.Size(78, 24);
            this.chkListActive.TabIndex = 0;
            this.chkListActive.Text = "Active";
            this.chkListActive.UseVisualStyleBackColor = true;
            // 
            // lbLists
            // 
            this.lbLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLists.FormattingEnabled = true;
            this.lbLists.ItemHeight = 20;
            this.lbLists.Location = new System.Drawing.Point(20, 25);
            this.lbLists.Name = "lbLists";
            this.lbLists.Size = new System.Drawing.Size(525, 524);
            this.lbLists.TabIndex = 1;
            this.lbLists.SelectedIndexChanged += new System.EventHandler(this.lbLists_SelectedIndexChanged);
            // 
            // btnAddNewList
            // 
            this.btnAddNewList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewList.Location = new System.Drawing.Point(450, 1087);
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.Size = new System.Drawing.Size(124, 35);
            this.btnAddNewList.TabIndex = 0;
            this.btnAddNewList.Text = "Add new list";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnAddNewList_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnRemoveImage);
            this.groupBox3.Controls.Add(this.lbElementsInList);
            this.groupBox3.Controls.Add(this.btnAddToList);
            this.groupBox3.Location = new System.Drawing.Point(610, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 1147);
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
            this.lbElementsInList.ItemHeight = 20;
            this.lbElementsInList.Location = new System.Drawing.Point(6, 25);
            this.lbElementsInList.Name = "lbElementsInList";
            this.lbElementsInList.Size = new System.Drawing.Size(517, 1044);
            this.lbElementsInList.TabIndex = 1;
            this.lbElementsInList.SelectedIndexChanged += new System.EventHandler(this.lbElementsInList_SelectedIndexChanged);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToList.Location = new System.Drawing.Point(448, 1087);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 35);
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
            this.groupBox4.Location = new System.Drawing.Point(1144, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(937, 1147);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log output";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.Location = new System.Drawing.Point(6, 574);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(919, 567);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 3;
            this.pbPreview.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(6, 25);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(918, 541);
            this.txtLog.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOpenSettingsfolder
            // 
            this.btnOpenSettingsfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSettingsfolder.Location = new System.Drawing.Point(1385, 25);
            this.btnOpenSettingsfolder.Name = "btnOpenSettingsfolder";
            this.btnOpenSettingsfolder.Size = new System.Drawing.Size(166, 52);
            this.btnOpenSettingsfolder.TabIndex = 9;
            this.btnOpenSettingsfolder.Text = "Open settings folder";
            this.btnOpenSettingsfolder.UseVisualStyleBackColor = true;
            this.btnOpenSettingsfolder.Click += new System.EventHandler(this.btnOpenSettingsfolder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Processing settings:";
            // 
            // numMaxWidth
            // 
            this.numMaxWidth.Location = new System.Drawing.Point(105, 401);
            this.numMaxWidth.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numMaxWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxWidth.Name = "numMaxWidth";
            this.numMaxWidth.Size = new System.Drawing.Size(80, 26);
            this.numMaxWidth.TabIndex = 22;
            this.numMaxWidth.Value = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Max width:";
            // 
            // chkRandomImage
            // 
            this.chkRandomImage.AutoSize = true;
            this.chkRandomImage.Location = new System.Drawing.Point(18, 433);
            this.chkRandomImage.Name = "chkRandomImage";
            this.chkRandomImage.Size = new System.Drawing.Size(247, 24);
            this.chkRandomImage.TabIndex = 24;
            this.chkRandomImage.Text = "Deliver random image from list";
            this.chkRandomImage.UseVisualStyleBackColor = true;
            // 
            // btnMoveListUp
            // 
            this.btnMoveListUp.Location = new System.Drawing.Point(551, 302);
            this.btnMoveListUp.Name = "btnMoveListUp";
            this.btnMoveListUp.Size = new System.Drawing.Size(34, 41);
            this.btnMoveListUp.TabIndex = 3;
            this.btnMoveListUp.Text = "↑";
            this.btnMoveListUp.UseVisualStyleBackColor = true;
            this.btnMoveListUp.Click += new System.EventHandler(this.btnMoveListUp_Click);
            // 
            // btnMoveListDown
            // 
            this.btnMoveListDown.Location = new System.Drawing.Point(552, 349);
            this.btnMoveListDown.Name = "btnMoveListDown";
            this.btnMoveListDown.Size = new System.Drawing.Size(34, 40);
            this.btnMoveListDown.TabIndex = 4;
            this.btnMoveListDown.Text = "↓";
            this.btnMoveListDown.UseVisualStyleBackColor = true;
            this.btnMoveListDown.Click += new System.EventHandler(this.btnMoveListDown_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Description:";
            // 
            // txtListdescription
            // 
            this.txtListdescription.Location = new System.Drawing.Point(105, 90);
            this.txtListdescription.Name = "txtListdescription";
            this.txtListdescription.Size = new System.Drawing.Size(443, 26);
            this.txtListdescription.TabIndex = 26;
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Location = new System.Drawing.Point(6, 1087);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(125, 32);
            this.btnRemoveImage.TabIndex = 2;
            this.btnRemoveImage.Text = "Remove image";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnDeleteSelectedList
            // 
            this.btnDeleteSelectedList.Location = new System.Drawing.Point(20, 1092);
            this.btnDeleteSelectedList.Name = "btnDeleteSelectedList";
            this.btnDeleteSelectedList.Size = new System.Drawing.Size(124, 35);
            this.btnDeleteSelectedList.TabIndex = 5;
            this.btnDeleteSelectedList.Text = "Delete list";
            this.btnDeleteSelectedList.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedList.Click += new System.EventHandler(this.btnDeleteSelectedList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2095, 1304);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1670, 1111);
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
            this.grpListsettings.ResumeLayout(false);
            this.grpListsettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToHour)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).EndInit();
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
        private System.Windows.Forms.GroupBox grpListsettings;
        private System.Windows.Forms.CheckBox chkListActive;
        private System.Windows.Forms.CheckBox chkListTuesday;
        private System.Windows.Forms.CheckBox chkListWednesday;
        private System.Windows.Forms.CheckBox chkListThursday;
        private System.Windows.Forms.CheckBox chkListFriday;
        private System.Windows.Forms.CheckBox chkListSaturday;
        private System.Windows.Forms.CheckBox chkListSunday;
        private System.Windows.Forms.CheckBox chkListMonday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numFromMinute;
        private System.Windows.Forms.NumericUpDown numFromHour;
        private System.Windows.Forms.NumericUpDown numToMinute;
        private System.Windows.Forms.NumericUpDown numToHour;
        private System.Windows.Forms.TextBox txtListname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveSettingsNow;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenSettingsfolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numMaxWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkRandomImage;
        private System.Windows.Forms.Button btnMoveListDown;
        private System.Windows.Forms.Button btnMoveListUp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtListdescription;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.Button btnDeleteSelectedList;
    }
}

