using System;
using System.Windows.Forms;

/// <summary>
/// Author: Alvin Ramoutar (991454918)
/// Date:   2018/08/13
/// Desc:   A Dynamic DNS Client for registrars which provide a web service
///         for updates via HTTP.
///         Intended for those running hosted applications on a network
///         with dynamic addressing (Public IP changes now and then).
/// </summary>
namespace dynamic_dns_client {

    /// <summary>
    /// Handlers & code-behind for TriggerModal Form
    /// Small modal form which accepts trigger file location and arguments
    /// </summary>
    public partial class TriggerModal : Form {

        #region Properties and Fields
        internal string TriggerExecLoc { get; set; }
        internal string TriggerExecArgs { get; set; }
        #endregion

        #region Constructors
        public TriggerModal() {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the created modal with data from previous trigger
        /// </summary>
        /// <param name="t">Supplied trigger</param>
        public TriggerModal(Trigger t) {
            InitializeComponent();
            TriggerExecLoc = t.TriggerLoc;
            this.tBox_TriggerExecLoc.Text = TriggerExecLoc;
            TriggerExecArgs = t.TriggerArgs;
            this.tBox_TriggerExecArgs.Text = TriggerExecArgs;
        }
        #endregion

        /// <summary>
        /// Save form data to properties on form save
        /// </summary>
        /// <param name="sender">Form</param>
        /// <param name="e">Closing</param>
        private void TriggerModal_FormClosing(object sender, FormClosingEventArgs e) {
            TriggerExecLoc = this.tBox_TriggerExecLoc.Text;
            TriggerExecArgs = this.tBox_TriggerExecArgs.Text;
        }

        /// <summary>
        /// Launch OpenFileBrowser on click of elipses to right of Trigger Location field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BrowseTrigExec_Click(object sender, EventArgs e) {
            if(this.openTriggerDialog.ShowDialog() == DialogResult.OK) {
                this.tBox_TriggerExecLoc.Text = this.openTriggerDialog.FileName;
            }
        }
    }
}
