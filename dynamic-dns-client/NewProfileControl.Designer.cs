namespace dynamic_dns_client {

    /// <summary>
    /// Form designer for custom form control for Profiles
    /// Contains form controls specific for modifying Profiles
    /// </summary>
    partial class NewProfileControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tBox_Name = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Host = new System.Windows.Forms.Label();
            this.tBox_Host = new System.Windows.Forms.TextBox();
            this.lbl_Domain = new System.Windows.Forms.Label();
            this.tBox_Domain = new System.Windows.Forms.TextBox();
            this.lbl_DynDNSPass = new System.Windows.Forms.Label();
            this.tBox_DynDNSPassword = new System.Windows.Forms.TextBox();
            this.lbl_UpdateFrequency = new System.Windows.Forms.Label();
            this.lbl_IPAddress = new System.Windows.Forms.Label();
            this.tBox_IPAddress = new System.Windows.Forms.TextBox();
            this.comboBox_UpdatePeriod = new System.Windows.Forms.ComboBox();
            this.cBox_AutoDetectIP = new System.Windows.Forms.CheckBox();
            this.cBox_TriggerOnUpdate = new System.Windows.Forms.CheckBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Discard = new System.Windows.Forms.Button();
            this.lBox_Triggers = new System.Windows.Forms.ListBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.comboBox_Registrar = new System.Windows.Forms.ComboBox();
            this.lbl_Registrar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tBox_Name
            // 
            this.tBox_Name.Location = new System.Drawing.Point(10, 14);
            this.tBox_Name.Name = "tBox_Name";
            this.tBox_Name.Size = new System.Drawing.Size(167, 20);
            this.tBox_Name.TabIndex = 0;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(183, 17);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_Host
            // 
            this.lbl_Host.AutoSize = true;
            this.lbl_Host.Location = new System.Drawing.Point(183, 43);
            this.lbl_Host.Name = "lbl_Host";
            this.lbl_Host.Size = new System.Drawing.Size(29, 13);
            this.lbl_Host.TabIndex = 3;
            this.lbl_Host.Text = "Host";
            // 
            // tBox_Host
            // 
            this.tBox_Host.Location = new System.Drawing.Point(10, 40);
            this.tBox_Host.Name = "tBox_Host";
            this.tBox_Host.Size = new System.Drawing.Size(167, 20);
            this.tBox_Host.TabIndex = 2;
            // 
            // lbl_Domain
            // 
            this.lbl_Domain.AutoSize = true;
            this.lbl_Domain.Location = new System.Drawing.Point(400, 43);
            this.lbl_Domain.Name = "lbl_Domain";
            this.lbl_Domain.Size = new System.Drawing.Size(43, 13);
            this.lbl_Domain.TabIndex = 5;
            this.lbl_Domain.Text = "Domain";
            // 
            // tBox_Domain
            // 
            this.tBox_Domain.Location = new System.Drawing.Point(238, 40);
            this.tBox_Domain.Name = "tBox_Domain";
            this.tBox_Domain.Size = new System.Drawing.Size(156, 20);
            this.tBox_Domain.TabIndex = 4;
            // 
            // lbl_DynDNSPass
            // 
            this.lbl_DynDNSPass.AutoSize = true;
            this.lbl_DynDNSPass.Location = new System.Drawing.Point(7, 71);
            this.lbl_DynDNSPass.Name = "lbl_DynDNSPass";
            this.lbl_DynDNSPass.Size = new System.Drawing.Size(123, 13);
            this.lbl_DynDNSPass.TabIndex = 7;
            this.lbl_DynDNSPass.Text = "Dynamic DNS Password";
            // 
            // tBox_DynDNSPassword
            // 
            this.tBox_DynDNSPassword.Location = new System.Drawing.Point(10, 87);
            this.tBox_DynDNSPassword.Name = "tBox_DynDNSPassword";
            this.tBox_DynDNSPassword.Size = new System.Drawing.Size(156, 20);
            this.tBox_DynDNSPassword.TabIndex = 6;
            // 
            // lbl_UpdateFrequency
            // 
            this.lbl_UpdateFrequency.AutoSize = true;
            this.lbl_UpdateFrequency.Location = new System.Drawing.Point(354, 69);
            this.lbl_UpdateFrequency.Name = "lbl_UpdateFrequency";
            this.lbl_UpdateFrequency.Size = new System.Drawing.Size(95, 13);
            this.lbl_UpdateFrequency.TabIndex = 11;
            this.lbl_UpdateFrequency.Text = "Update Frequency";
            // 
            // lbl_IPAddress
            // 
            this.lbl_IPAddress.AutoSize = true;
            this.lbl_IPAddress.Location = new System.Drawing.Point(7, 113);
            this.lbl_IPAddress.Name = "lbl_IPAddress";
            this.lbl_IPAddress.Size = new System.Drawing.Size(58, 13);
            this.lbl_IPAddress.TabIndex = 13;
            this.lbl_IPAddress.Text = "IP Address";
            // 
            // tBox_IPAddress
            // 
            this.tBox_IPAddress.Location = new System.Drawing.Point(10, 127);
            this.tBox_IPAddress.Name = "tBox_IPAddress";
            this.tBox_IPAddress.Size = new System.Drawing.Size(156, 20);
            this.tBox_IPAddress.TabIndex = 12;
            // 
            // comboBox_UpdatePeriod
            // 
            this.comboBox_UpdatePeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UpdatePeriod.FormattingEnabled = true;
            this.comboBox_UpdatePeriod.Location = new System.Drawing.Point(238, 66);
            this.comboBox_UpdatePeriod.Name = "comboBox_UpdatePeriod";
            this.comboBox_UpdatePeriod.Size = new System.Drawing.Size(110, 21);
            this.comboBox_UpdatePeriod.TabIndex = 24;
            // 
            // cBox_AutoDetectIP
            // 
            this.cBox_AutoDetectIP.AutoSize = true;
            this.cBox_AutoDetectIP.Location = new System.Drawing.Point(10, 149);
            this.cBox_AutoDetectIP.Name = "cBox_AutoDetectIP";
            this.cBox_AutoDetectIP.Size = new System.Drawing.Size(126, 17);
            this.cBox_AutoDetectIP.TabIndex = 25;
            this.cBox_AutoDetectIP.Text = "Auto detect Public IP";
            this.cBox_AutoDetectIP.UseVisualStyleBackColor = true;
            this.cBox_AutoDetectIP.CheckedChanged += new System.EventHandler(this.cBox_AutoDetectIP_CheckedChanged);
            // 
            // cBox_TriggerOnUpdate
            // 
            this.cBox_TriggerOnUpdate.AutoSize = true;
            this.cBox_TriggerOnUpdate.Location = new System.Drawing.Point(203, 102);
            this.cBox_TriggerOnUpdate.Name = "cBox_TriggerOnUpdate";
            this.cBox_TriggerOnUpdate.Size = new System.Drawing.Size(150, 17);
            this.cBox_TriggerOnUpdate.TabIndex = 26;
            this.cBox_TriggerOnUpdate.Text = "Custom Trigger on Update";
            this.cBox_TriggerOnUpdate.UseVisualStyleBackColor = true;
            this.cBox_TriggerOnUpdate.CheckedChanged += new System.EventHandler(this.cBox_TriggerOnUpdate_CheckedChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(299, 181);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 27;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Discard
            // 
            this.btn_Discard.Location = new System.Drawing.Point(378, 181);
            this.btn_Discard.Name = "btn_Discard";
            this.btn_Discard.Size = new System.Drawing.Size(75, 23);
            this.btn_Discard.TabIndex = 28;
            this.btn_Discard.Text = "Discard";
            this.btn_Discard.UseVisualStyleBackColor = true;
            this.btn_Discard.Click += new System.EventHandler(this.btn_Discard_Click);
            // 
            // lBox_Triggers
            // 
            this.lBox_Triggers.Enabled = false;
            this.lBox_Triggers.FormattingEnabled = true;
            this.lBox_Triggers.Items.AddRange(new object[] {
            "Add New Trigger..."});
            this.lBox_Triggers.Location = new System.Drawing.Point(203, 119);
            this.lBox_Triggers.Name = "lBox_Triggers";
            this.lBox_Triggers.Size = new System.Drawing.Size(246, 56);
            this.lBox_Triggers.TabIndex = 29;
            this.lBox_Triggers.DoubleClick += new System.EventHandler(this.lBox_Triggers_DoubleClick);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(3, 181);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 30;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Visible = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // comboBox_Registrar
            // 
            this.comboBox_Registrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Registrar.FormattingEnabled = true;
            this.comboBox_Registrar.Location = new System.Drawing.Point(238, 14);
            this.comboBox_Registrar.Name = "comboBox_Registrar";
            this.comboBox_Registrar.Size = new System.Drawing.Size(156, 21);
            this.comboBox_Registrar.TabIndex = 31;
            // 
            // lbl_Registrar
            // 
            this.lbl_Registrar.AutoSize = true;
            this.lbl_Registrar.Location = new System.Drawing.Point(400, 17);
            this.lbl_Registrar.Name = "lbl_Registrar";
            this.lbl_Registrar.Size = new System.Drawing.Size(49, 13);
            this.lbl_Registrar.TabIndex = 32;
            this.lbl_Registrar.Text = "Registrar";
            // 
            // NewProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_Registrar);
            this.Controls.Add(this.comboBox_Registrar);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.lBox_Triggers);
            this.Controls.Add(this.btn_Discard);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cBox_TriggerOnUpdate);
            this.Controls.Add(this.cBox_AutoDetectIP);
            this.Controls.Add(this.comboBox_UpdatePeriod);
            this.Controls.Add(this.lbl_IPAddress);
            this.Controls.Add(this.tBox_IPAddress);
            this.Controls.Add(this.lbl_UpdateFrequency);
            this.Controls.Add(this.lbl_DynDNSPass);
            this.Controls.Add(this.tBox_DynDNSPassword);
            this.Controls.Add(this.lbl_Domain);
            this.Controls.Add(this.tBox_Domain);
            this.Controls.Add(this.lbl_Host);
            this.Controls.Add(this.tBox_Host);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.tBox_Name);
            this.Name = "NewProfileControl";
            this.Size = new System.Drawing.Size(456, 207);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBox_Name;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Host;
        private System.Windows.Forms.TextBox tBox_Host;
        private System.Windows.Forms.Label lbl_Domain;
        private System.Windows.Forms.TextBox tBox_Domain;
        private System.Windows.Forms.Label lbl_DynDNSPass;
        private System.Windows.Forms.TextBox tBox_DynDNSPassword;
        private System.Windows.Forms.Label lbl_UpdateFrequency;
        private System.Windows.Forms.Label lbl_IPAddress;
        private System.Windows.Forms.TextBox tBox_IPAddress;
        private System.Windows.Forms.ComboBox comboBox_UpdatePeriod;
        private System.Windows.Forms.CheckBox cBox_AutoDetectIP;
        private System.Windows.Forms.CheckBox cBox_TriggerOnUpdate;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Discard;
        private System.Windows.Forms.ListBox lBox_Triggers;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ComboBox comboBox_Registrar;
        private System.Windows.Forms.Label lbl_Registrar;
    }
}
