﻿namespace dynamic_dns_client {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIComboBox_Profiles = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.tab_Log = new System.Windows.Forms.TabPage();
            this.richTBox_LogBox = new System.Windows.Forms.RichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tab_Log.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProfileToolStripMenuItem,
            this.modifyProfileToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // addNewProfileToolStripMenuItem
            // 
            this.addNewProfileToolStripMenuItem.Name = "addNewProfileToolStripMenuItem";
            this.addNewProfileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addNewProfileToolStripMenuItem.Text = "Add New Profile";
            this.addNewProfileToolStripMenuItem.Click += new System.EventHandler(this.addNewProfileToolStripMenuItem_Click);
            // 
            // modifyProfileToolStripMenuItem
            // 
            this.modifyProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIComboBox_Profiles});
            this.modifyProfileToolStripMenuItem.Name = "modifyProfileToolStripMenuItem";
            this.modifyProfileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.modifyProfileToolStripMenuItem.Text = "Modify Profile";
            this.modifyProfileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.modifyProfileToolStripMenuItem_DropDownOpening);
            // 
            // TSMIComboBox_Profiles
            // 
            this.TSMIComboBox_Profiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TSMIComboBox_Profiles.Items.AddRange(new object[] {
            "Select a profile..."});
            this.TSMIComboBox_Profiles.Name = "TSMIComboBox_Profiles";
            this.TSMIComboBox_Profiles.Size = new System.Drawing.Size(152, 23);
            this.TSMIComboBox_Profiles.SelectedIndexChanged += new System.EventHandler(this.TSMIComboBox_Profiles_SelectedIndexChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(5, 263);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 13);
            this.lbl_Status.TabIndex = 3;
            // 
            // tab_Log
            // 
            this.tab_Log.Controls.Add(this.richTBox_LogBox);
            this.tab_Log.Location = new System.Drawing.Point(4, 22);
            this.tab_Log.Name = "tab_Log";
            this.tab_Log.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Log.Size = new System.Drawing.Size(456, 207);
            this.tab_Log.TabIndex = 0;
            this.tab_Log.Text = "Log";
            this.tab_Log.UseVisualStyleBackColor = true;
            // 
            // richTBox_LogBox
            // 
            this.richTBox_LogBox.BackColor = System.Drawing.Color.White;
            this.richTBox_LogBox.Location = new System.Drawing.Point(0, 0);
            this.richTBox_LogBox.Name = "richTBox_LogBox";
            this.richTBox_LogBox.ReadOnly = true;
            this.richTBox_LogBox.Size = new System.Drawing.Size(456, 207);
            this.richTBox_LogBox.TabIndex = 0;
            this.richTBox_LogBox.Text = "";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_Log);
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(464, 233);
            this.tabControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "HomeForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab_Log.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.TabPage tab_Log;
        public System.Windows.Forms.RichTextBox richTBox_LogBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripComboBox TSMIComboBox_Profiles;
    }
}

