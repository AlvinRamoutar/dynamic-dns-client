namespace dynamic_dns_client {
    partial class TriggerModal {
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
            this.label1 = new System.Windows.Forms.Label();
            this.tBox_TriggerExecLoc = new System.Windows.Forms.TextBox();
            this.tBox_TriggerExecArgs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_BrowseTrigExec = new System.Windows.Forms.Button();
            this.btn_DiscardTrigger = new System.Windows.Forms.Button();
            this.btn_AddTrigger = new System.Windows.Forms.Button();
            this.openTriggerDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trigger Executable Location";
            // 
            // tBox_TriggerExecLoc
            // 
            this.tBox_TriggerExecLoc.Location = new System.Drawing.Point(15, 25);
            this.tBox_TriggerExecLoc.Name = "tBox_TriggerExecLoc";
            this.tBox_TriggerExecLoc.Size = new System.Drawing.Size(262, 20);
            this.tBox_TriggerExecLoc.TabIndex = 1;
            // 
            // tBox_TriggerExecArgs
            // 
            this.tBox_TriggerExecArgs.Location = new System.Drawing.Point(12, 74);
            this.tBox_TriggerExecArgs.Name = "tBox_TriggerExecArgs";
            this.tBox_TriggerExecArgs.Size = new System.Drawing.Size(309, 20);
            this.tBox_TriggerExecArgs.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arguments (optional)";
            // 
            // btn_BrowseTrigExec
            // 
            this.btn_BrowseTrigExec.Location = new System.Drawing.Point(284, 25);
            this.btn_BrowseTrigExec.Name = "btn_BrowseTrigExec";
            this.btn_BrowseTrigExec.Size = new System.Drawing.Size(37, 23);
            this.btn_BrowseTrigExec.TabIndex = 4;
            this.btn_BrowseTrigExec.Text = "...";
            this.btn_BrowseTrigExec.UseVisualStyleBackColor = true;
            this.btn_BrowseTrigExec.Click += new System.EventHandler(this.btn_BrowseTrigExec_Click);
            // 
            // btn_DiscardTrigger
            // 
            this.btn_DiscardTrigger.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_DiscardTrigger.Location = new System.Drawing.Point(246, 108);
            this.btn_DiscardTrigger.Name = "btn_DiscardTrigger";
            this.btn_DiscardTrigger.Size = new System.Drawing.Size(75, 23);
            this.btn_DiscardTrigger.TabIndex = 5;
            this.btn_DiscardTrigger.Text = "Discard";
            this.btn_DiscardTrigger.UseVisualStyleBackColor = true;
            // 
            // btn_AddTrigger
            // 
            this.btn_AddTrigger.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_AddTrigger.Location = new System.Drawing.Point(165, 108);
            this.btn_AddTrigger.Name = "btn_AddTrigger";
            this.btn_AddTrigger.Size = new System.Drawing.Size(75, 23);
            this.btn_AddTrigger.TabIndex = 6;
            this.btn_AddTrigger.Text = "Add";
            this.btn_AddTrigger.UseVisualStyleBackColor = true;
            // 
            // openTriggerDialog
            // 
            this.openTriggerDialog.Title = "Select executable to Trigger...";
            // 
            // TriggerModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 143);
            this.Controls.Add(this.btn_AddTrigger);
            this.Controls.Add(this.btn_DiscardTrigger);
            this.Controls.Add(this.btn_BrowseTrigExec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBox_TriggerExecArgs);
            this.Controls.Add(this.tBox_TriggerExecLoc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TriggerModal";
            this.Text = "New Trigger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TriggerModal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBox_TriggerExecLoc;
        private System.Windows.Forms.TextBox tBox_TriggerExecArgs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_BrowseTrigExec;
        private System.Windows.Forms.Button btn_DiscardTrigger;
        private System.Windows.Forms.Button btn_AddTrigger;
        private System.Windows.Forms.OpenFileDialog openTriggerDialog;
    }
}