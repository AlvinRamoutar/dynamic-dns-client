using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynamic_dns_client {

    public partial class TriggerModal : Form {

        internal string TriggerExecLoc { get; set; }
        internal string TriggerExecArgs { get; set; }

        public TriggerModal() {
            InitializeComponent();
        }

        public TriggerModal(Trigger t) {
            InitializeComponent();
            TriggerExecLoc = t.TriggerLoc;
            TriggerExecArgs = t.TriggerArgs;
        }

        private void TriggerModal_FormClosing(object sender, FormClosingEventArgs e) {
            TriggerExecLoc = this.tBox_TriggerExecLoc.Text;
            TriggerExecArgs = this.tBox_TriggerExecArgs.Text;
        }

        private void btn_BrowseTrigExec_Click(object sender, EventArgs e) {
            if(this.openTriggerDialog.ShowDialog() == DialogResult.OK) {
                this.tBox_TriggerExecLoc.Text = this.openTriggerDialog.FileName;
            }
        }
    }
}
