namespace dynamic_dns_client {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Host = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_Domain = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lbl_DynDNSPass = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lbl_UpdateFrequency = new System.Windows.Forms.Label();
            this.lbl_IPAddress = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.cBox_UpdateFrequency = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cBox_TriggerOnUpdate = new System.Windows.Forms.CheckBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Discard = new System.Windows.Forms.Button();
            this.lBox_Triggers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(128, 20);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_Host
            // 
            this.lbl_Host.AutoSize = true;
            this.lbl_Host.Location = new System.Drawing.Point(128, 46);
            this.lbl_Host.Name = "lbl_Host";
            this.lbl_Host.Size = new System.Drawing.Size(29, 13);
            this.lbl_Host.TabIndex = 3;
            this.lbl_Host.Text = "Host";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // lbl_Domain
            // 
            this.lbl_Domain.AutoSize = true;
            this.lbl_Domain.Location = new System.Drawing.Point(128, 72);
            this.lbl_Domain.Name = "lbl_Domain";
            this.lbl_Domain.Size = new System.Drawing.Size(43, 13);
            this.lbl_Domain.TabIndex = 5;
            this.lbl_Domain.Text = "Domain";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            // 
            // lbl_DynDNSPass
            // 
            this.lbl_DynDNSPass.AutoSize = true;
            this.lbl_DynDNSPass.Location = new System.Drawing.Point(128, 98);
            this.lbl_DynDNSPass.Name = "lbl_DynDNSPass";
            this.lbl_DynDNSPass.Size = new System.Drawing.Size(123, 13);
            this.lbl_DynDNSPass.TabIndex = 7;
            this.lbl_DynDNSPass.Text = "Dynamic DNS Password";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(21, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
            // 
            // lbl_UpdateFrequency
            // 
            this.lbl_UpdateFrequency.AutoSize = true;
            this.lbl_UpdateFrequency.Location = new System.Drawing.Point(128, 126);
            this.lbl_UpdateFrequency.Name = "lbl_UpdateFrequency";
            this.lbl_UpdateFrequency.Size = new System.Drawing.Size(95, 13);
            this.lbl_UpdateFrequency.TabIndex = 11;
            this.lbl_UpdateFrequency.Text = "Update Frequency";
            // 
            // lbl_IPAddress
            // 
            this.lbl_IPAddress.AutoSize = true;
            this.lbl_IPAddress.Location = new System.Drawing.Point(296, 20);
            this.lbl_IPAddress.Name = "lbl_IPAddress";
            this.lbl_IPAddress.Size = new System.Drawing.Size(58, 13);
            this.lbl_IPAddress.TabIndex = 13;
            this.lbl_IPAddress.Text = "IP Address";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(189, 14);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 20);
            this.textBox12.TabIndex = 12;
            // 
            // cBox_UpdateFrequency
            // 
            this.cBox_UpdateFrequency.FormattingEnabled = true;
            this.cBox_UpdateFrequency.Location = new System.Drawing.Point(21, 118);
            this.cBox_UpdateFrequency.Name = "cBox_UpdateFrequency";
            this.cBox_UpdateFrequency.Size = new System.Drawing.Size(100, 21);
            this.cBox_UpdateFrequency.TabIndex = 24;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(189, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "Auto detect Public IP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cBox_TriggerOnUpdate
            // 
            this.cBox_TriggerOnUpdate.AutoSize = true;
            this.cBox_TriggerOnUpdate.Location = new System.Drawing.Point(189, 68);
            this.cBox_TriggerOnUpdate.Name = "cBox_TriggerOnUpdate";
            this.cBox_TriggerOnUpdate.Size = new System.Drawing.Size(112, 17);
            this.cBox_TriggerOnUpdate.TabIndex = 26;
            this.cBox_TriggerOnUpdate.Text = "Trigger on Update";
            this.cBox_TriggerOnUpdate.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(189, 150);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 27;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Discard
            // 
            this.btn_Discard.Location = new System.Drawing.Point(270, 150);
            this.btn_Discard.Name = "btn_Discard";
            this.btn_Discard.Size = new System.Drawing.Size(75, 23);
            this.btn_Discard.TabIndex = 28;
            this.btn_Discard.Text = "Discard";
            this.btn_Discard.UseVisualStyleBackColor = true;
            // 
            // lBox_Triggers
            // 
            this.lBox_Triggers.FormattingEnabled = true;
            this.lBox_Triggers.Location = new System.Drawing.Point(210, 91);
            this.lBox_Triggers.Name = "lBox_Triggers";
            this.lBox_Triggers.Size = new System.Drawing.Size(144, 43);
            this.lBox_Triggers.TabIndex = 29;
            // 
            // NewProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lBox_Triggers);
            this.Controls.Add(this.btn_Discard);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cBox_TriggerOnUpdate);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cBox_UpdateFrequency);
            this.Controls.Add(this.lbl_IPAddress);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.lbl_UpdateFrequency);
            this.Controls.Add(this.lbl_DynDNSPass);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.lbl_Domain);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lbl_Host);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.textBox1);
            this.Name = "NewProfileControl";
            this.Size = new System.Drawing.Size(374, 196);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Host;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbl_Domain;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbl_DynDNSPass;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lbl_UpdateFrequency;
        private System.Windows.Forms.Label lbl_IPAddress;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.ComboBox cBox_UpdateFrequency;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cBox_TriggerOnUpdate;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Discard;
        private System.Windows.Forms.ListBox lBox_Triggers;
    }
}
