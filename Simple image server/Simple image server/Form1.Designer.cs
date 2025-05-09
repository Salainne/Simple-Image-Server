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
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDebugLevel = new System.Windows.Forms.ComboBox();
            this.chkRandomImageFromAllActiveListsWithName = new System.Windows.Forms.CheckBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnOpenSettingsfolder = new System.Windows.Forms.Button();
            this.btnSaveSettingsNow = new System.Windows.Forms.Button();
            this.DarkMode = new System.Windows.Forms.CheckBox();
            this.btnStartOnBoot = new System.Windows.Forms.Button();
            this.chkAutostart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllowremoteAccess = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnServertoggle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDuplicateList = new System.Windows.Forms.Button();
            this.btnDeleteSelectedList = new System.Windows.Forms.Button();
            this.btnMoveListDown = new System.Windows.Forms.Button();
            this.btnMoveListUp = new System.Windows.Forms.Button();
            this.grpListsettings = new System.Windows.Forms.GroupBox();
            this.txtListdescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkRandomImage = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
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
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.lbElementsInList = new System.Windows.Forms.ListBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpListsettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToHour)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbDebugLevel);
            this.groupBox1.Controls.Add(this.chkRandomImageFromAllActiveListsWithName);
            this.groupBox1.Controls.Add(this.cmbLanguage);
            this.groupBox1.Controls.Add(this.btnOpenSettingsfolder);
            this.groupBox1.Controls.Add(this.btnSaveSettingsNow);
            this.groupBox1.Controls.Add(this.DarkMode);
            this.groupBox1.Controls.Add(this.btnStartOnBoot);
            this.groupBox1.Controls.Add(this.chkAutostart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkAllowremoteAccess);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.btnServertoggle);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cmbDebugLevel
            // 
            this.cmbDebugLevel.FormattingEnabled = true;
            this.cmbDebugLevel.Items.AddRange(new object[] {
            resources.GetString("cmbDebugLevel.Items"),
            resources.GetString("cmbDebugLevel.Items1"),
            resources.GetString("cmbDebugLevel.Items2"),
            resources.GetString("cmbDebugLevel.Items3")});
            resources.ApplyResources(this.cmbDebugLevel, "cmbDebugLevel");
            this.cmbDebugLevel.Name = "cmbDebugLevel";
            // 
            // chkRandomImageFromAllActiveListsWithName
            // 
            resources.ApplyResources(this.chkRandomImageFromAllActiveListsWithName, "chkRandomImageFromAllActiveListsWithName");
            this.chkRandomImageFromAllActiveListsWithName.Name = "chkRandomImageFromAllActiveListsWithName";
            this.chkRandomImageFromAllActiveListsWithName.UseVisualStyleBackColor = true;
            this.chkRandomImageFromAllActiveListsWithName.CheckedChanged += new System.EventHandler(this.chkRandomImageFromAllActiveListsWithName_CheckedChanged);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1")});
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            // 
            // btnOpenSettingsfolder
            // 
            resources.ApplyResources(this.btnOpenSettingsfolder, "btnOpenSettingsfolder");
            this.btnOpenSettingsfolder.Name = "btnOpenSettingsfolder";
            this.btnOpenSettingsfolder.UseVisualStyleBackColor = true;
            this.btnOpenSettingsfolder.Click += new System.EventHandler(this.btnOpenSettingsfolder_Click);
            // 
            // btnSaveSettingsNow
            // 
            resources.ApplyResources(this.btnSaveSettingsNow, "btnSaveSettingsNow");
            this.btnSaveSettingsNow.Name = "btnSaveSettingsNow";
            this.btnSaveSettingsNow.UseVisualStyleBackColor = true;
            this.btnSaveSettingsNow.Click += new System.EventHandler(this.btnSaveSettingsNow_Click);
            // 
            // DarkMode
            // 
            resources.ApplyResources(this.DarkMode, "DarkMode");
            this.DarkMode.Name = "DarkMode";
            this.DarkMode.UseVisualStyleBackColor = true;
            this.DarkMode.CheckedChanged += new System.EventHandler(this.DarkMode_CheckedChanged);
            // 
            // btnStartOnBoot
            // 
            resources.ApplyResources(this.btnStartOnBoot, "btnStartOnBoot");
            this.btnStartOnBoot.Name = "btnStartOnBoot";
            this.btnStartOnBoot.UseVisualStyleBackColor = true;
            this.btnStartOnBoot.Click += new System.EventHandler(this.btnStartOnBoot_Click);
            // 
            // chkAutostart
            // 
            resources.ApplyResources(this.chkAutostart, "chkAutostart");
            this.chkAutostart.Name = "chkAutostart";
            this.chkAutostart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkAllowremoteAccess
            // 
            resources.ApplyResources(this.chkAllowremoteAccess, "chkAllowremoteAccess");
            this.chkAllowremoteAccess.Name = "chkAllowremoteAccess";
            this.chkAllowremoteAccess.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            resources.ApplyResources(this.txtPort, "txtPort");
            this.txtPort.Name = "txtPort";
            // 
            // btnServertoggle
            // 
            resources.ApplyResources(this.btnServertoggle, "btnServertoggle");
            this.btnServertoggle.Name = "btnServertoggle";
            this.btnServertoggle.UseVisualStyleBackColor = true;
            this.btnServertoggle.Click += new System.EventHandler(this.btnServertoggle_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnDuplicateList);
            this.groupBox2.Controls.Add(this.btnDeleteSelectedList);
            this.groupBox2.Controls.Add(this.btnMoveListDown);
            this.groupBox2.Controls.Add(this.btnMoveListUp);
            this.groupBox2.Controls.Add(this.grpListsettings);
            this.groupBox2.Controls.Add(this.lbLists);
            this.groupBox2.Controls.Add(this.btnAddNewList);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnDuplicateList
            // 
            resources.ApplyResources(this.btnDuplicateList, "btnDuplicateList");
            this.btnDuplicateList.Name = "btnDuplicateList";
            this.btnDuplicateList.UseVisualStyleBackColor = true;
            this.btnDuplicateList.Click += new System.EventHandler(this.btnDuplicateList_Click);
            // 
            // btnDeleteSelectedList
            // 
            resources.ApplyResources(this.btnDeleteSelectedList, "btnDeleteSelectedList");
            this.btnDeleteSelectedList.Name = "btnDeleteSelectedList";
            this.btnDeleteSelectedList.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedList.Click += new System.EventHandler(this.btnDeleteSelectedList_Click);
            // 
            // btnMoveListDown
            // 
            resources.ApplyResources(this.btnMoveListDown, "btnMoveListDown");
            this.btnMoveListDown.Name = "btnMoveListDown";
            this.btnMoveListDown.UseVisualStyleBackColor = true;
            this.btnMoveListDown.Click += new System.EventHandler(this.btnMoveListDown_Click);
            // 
            // btnMoveListUp
            // 
            resources.ApplyResources(this.btnMoveListUp, "btnMoveListUp");
            this.btnMoveListUp.Name = "btnMoveListUp";
            this.btnMoveListUp.UseVisualStyleBackColor = true;
            this.btnMoveListUp.Click += new System.EventHandler(this.btnMoveListUp_Click);
            // 
            // grpListsettings
            // 
            resources.ApplyResources(this.grpListsettings, "grpListsettings");
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
            this.grpListsettings.Name = "grpListsettings";
            this.grpListsettings.TabStop = false;
            // 
            // txtListdescription
            // 
            resources.ApplyResources(this.txtListdescription, "txtListdescription");
            this.txtListdescription.Name = "txtListdescription";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // chkRandomImage
            // 
            resources.ApplyResources(this.chkRandomImage, "chkRandomImage");
            this.chkRandomImage.Name = "chkRandomImage";
            this.chkRandomImage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // numMaxWidth
            // 
            resources.ApplyResources(this.numMaxWidth, "numMaxWidth");
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
            this.numMaxWidth.Value = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // numInterval
            // 
            resources.ApplyResources(this.numInterval, "numInterval");
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
            this.numInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtListname
            // 
            resources.ApplyResources(this.txtListname, "txtListname");
            this.txtListname.Name = "txtListname";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numFromMinute
            // 
            resources.ApplyResources(this.numFromMinute, "numFromMinute");
            this.numFromMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numFromMinute.Name = "numFromMinute";
            // 
            // numFromHour
            // 
            resources.ApplyResources(this.numFromHour, "numFromHour");
            this.numFromHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numFromHour.Name = "numFromHour";
            // 
            // numToMinute
            // 
            resources.ApplyResources(this.numToMinute, "numToMinute");
            this.numToMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numToMinute.Name = "numToMinute";
            this.numToMinute.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // numToHour
            // 
            resources.ApplyResources(this.numToHour, "numToHour");
            this.numToHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numToHour.Name = "numToHour";
            this.numToHour.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // chkListTuesday
            // 
            resources.ApplyResources(this.chkListTuesday, "chkListTuesday");
            this.chkListTuesday.Name = "chkListTuesday";
            this.chkListTuesday.UseVisualStyleBackColor = true;
            // 
            // chkListWednesday
            // 
            resources.ApplyResources(this.chkListWednesday, "chkListWednesday");
            this.chkListWednesday.Name = "chkListWednesday";
            this.chkListWednesday.UseVisualStyleBackColor = true;
            // 
            // chkListThursday
            // 
            resources.ApplyResources(this.chkListThursday, "chkListThursday");
            this.chkListThursday.Name = "chkListThursday";
            this.chkListThursday.UseVisualStyleBackColor = true;
            // 
            // chkListFriday
            // 
            resources.ApplyResources(this.chkListFriday, "chkListFriday");
            this.chkListFriday.Name = "chkListFriday";
            this.chkListFriday.UseVisualStyleBackColor = true;
            // 
            // chkListSaturday
            // 
            resources.ApplyResources(this.chkListSaturday, "chkListSaturday");
            this.chkListSaturday.Name = "chkListSaturday";
            this.chkListSaturday.UseVisualStyleBackColor = true;
            // 
            // chkListSunday
            // 
            resources.ApplyResources(this.chkListSunday, "chkListSunday");
            this.chkListSunday.Name = "chkListSunday";
            this.chkListSunday.UseVisualStyleBackColor = true;
            // 
            // chkListMonday
            // 
            resources.ApplyResources(this.chkListMonday, "chkListMonday");
            this.chkListMonday.Name = "chkListMonday";
            this.chkListMonday.UseVisualStyleBackColor = true;
            // 
            // chkListActive
            // 
            resources.ApplyResources(this.chkListActive, "chkListActive");
            this.chkListActive.Name = "chkListActive";
            this.chkListActive.UseVisualStyleBackColor = true;
            // 
            // lbLists
            // 
            this.lbLists.AllowDrop = true;
            resources.ApplyResources(this.lbLists, "lbLists");
            this.lbLists.FormattingEnabled = true;
            this.lbLists.Name = "lbLists";
            this.lbLists.SelectedIndexChanged += new System.EventHandler(this.lbLists_SelectedIndexChanged);
            this.lbLists.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbLists_DragDrop);
            this.lbLists.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbLists_DragEnter);
            this.lbLists.DragOver += new System.Windows.Forms.DragEventHandler(this.lbLists_DragOver);
            // 
            // btnAddNewList
            // 
            resources.ApplyResources(this.btnAddNewList, "btnAddNewList");
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnAddNewList_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.btnRemoveImage);
            this.groupBox3.Controls.Add(this.lbElementsInList);
            this.groupBox3.Controls.Add(this.btnAddToList);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // btnRemoveImage
            // 
            resources.ApplyResources(this.btnRemoveImage, "btnRemoveImage");
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // lbElementsInList
            // 
            resources.ApplyResources(this.lbElementsInList, "lbElementsInList");
            this.lbElementsInList.FormattingEnabled = true;
            this.lbElementsInList.Name = "lbElementsInList";
            this.lbElementsInList.SelectedIndexChanged += new System.EventHandler(this.lbElementsInList_SelectedIndexChanged);
            this.lbElementsInList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbElementsInList_MouseDown);
            // 
            // btnAddToList
            // 
            resources.ApplyResources(this.btnAddToList, "btnAddToList");
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.lbLog);
            this.groupBox4.Controls.Add(this.pbPreview);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // pbPreview
            // 
            resources.ApplyResources(this.pbPreview, "pbPreview");
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            // 
            // lbLog
            // 
            resources.ApplyResources(this.lbLog, "lbLog");
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Name = "lbLog";
            this.lbLog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbLog_MouseClick);
            this.lbLog.SelectedIndexChanged += new System.EventHandler(this.lbLog_SelectedIndexChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
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
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToHour)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnDuplicateList;
        private System.Windows.Forms.CheckBox chkRandomImageFromAllActiveListsWithName;
        private System.Windows.Forms.ComboBox cmbDebugLevel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbLog;
    }
}

