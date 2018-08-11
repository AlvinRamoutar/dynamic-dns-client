using System;
using System.Collections.Generic;
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
    /// Handlers & code-behind for custom form control for Profiles
    /// Contains form controls specific for modifying Profiles
    /// </summary>
    public partial class NewProfileControl : UserControl {

        #region Properties and Fields
        private Profile _Profile {get; set;}
        private bool IsNewProfile = true;

        internal const string NEW_TRIGGER_TEXT = "Add New Trigger...";
        #endregion

        #region Constructors
        public NewProfileControl() {
            InitializeComponent();
            LoadComboBoxes();
            IsNewProfile = true;
        }

        /// <summary>
        /// Pre-populates form elements with informatiom from supplied Profile object
        /// </summary>
        /// <param name="profile">Existing profile</param>
        public NewProfileControl(object profile) {
            InitializeComponent();
            _Profile = (Profile)profile;
            LoadComboBoxes();

            IsNewProfile = false;
            this.btn_Delete.Visible = true;

            this.tBox_Name.Text = _Profile.Name;
            this.comboBox_Registrar.SelectedValue = _Profile.Registrar;
            this.tBox_Host.Text = _Profile.Host;
            this.tBox_Domain.Text = _Profile.Domain;
            this.comboBox_UpdatePeriod.SelectedItem =
                 _Profile.UpdatePeriod + " " + _Profile.UpdatePeriodType.ToString();
            this.tBox_DynDNSPassword.Text = _Profile.DynDNSPassword;
            this.tBox_IPAddress.Text = _Profile.IPAddress;
            this.cBox_AutoDetectIP.Checked = _Profile.AutoDetectIP;

            this.lBox_Triggers.Items.Remove(NEW_TRIGGER_TEXT);
            if(_Profile.Triggers != null)
                foreach (Trigger t in _Profile.Triggers)
                    lBox_Triggers.Items.Insert(
                        (lBox_Triggers.Items.Count > 0) ? lBox_Triggers.Items.Count - 1 : 0, t);
            this.lBox_Triggers.Items.Add(NEW_TRIGGER_TEXT);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads combo boxes with static values
        /// </summary>
        private void LoadComboBoxes() {
            // Registrar Combo Box
            Array enums = Enum.GetValues(typeof(Registrar));
            foreach (object e in enums) {
                if(e.ToString() != "None")
                    this.comboBox_Registrar.Items.Add(e);
            }
            this.comboBox_Registrar.SelectedIndex = 0;

            // UpdateFrequency Combo Box
            this.comboBox_UpdatePeriod.Items.Add("1 Minutes");
            this.comboBox_UpdatePeriod.Items.Add("15 Minutes");
            this.comboBox_UpdatePeriod.Items.Add("30 Minutes");
            this.comboBox_UpdatePeriod.Items.Add("1 Hours");
            this.comboBox_UpdatePeriod.Items.Add("12 Hours");
            this.comboBox_UpdatePeriod.SelectedIndex = 0;
        }

        /// <summary>
        /// Handler for AutoDetectIP checkbox
        /// </summary>
        /// <param name="sender">cBox_AutoDetectIP</param>
        /// <param name="e">CheckedChanged</param>
        private void cBox_AutoDetectIP_CheckedChanged(object sender, EventArgs e) {
            if (cBox_AutoDetectIP.Checked)
                this.tBox_IPAddress.Enabled = false;
            else
                this.tBox_IPAddress.Enabled = true;
        }

        /// <summary>
        /// Handler for TriggerOnUpdate checkbox
        /// </summary>
        /// <param name="sender">cBox_TriggerOnUpdate</param>
        /// <param name="e">CheckedChanged</param>
        private void cBox_TriggerOnUpdate_CheckedChanged(object sender, EventArgs e) {
            if (cBox_TriggerOnUpdate.Checked)
                this.lBox_Triggers.Enabled = true;
            else
                this.lBox_Triggers.Enabled = false;
        }

        /// <summary>
        /// Handler for double click on new trigger text
        /// This would only be possible if TriggerOnUpdate is checked
        /// Listbox holding triggers for particular profile
        /// </summary>
        /// <param name="sender">lBox_Triggers</param>
        /// <param name="e">Double click</param>
        private void lBox_Triggers_DoubleClick(object sender, EventArgs e) {
            // If an item is selected in the listbox
            if (lBox_Triggers.SelectedItem != null)
                // If the item is the placeholder 'new trigger text'
                if (lBox_Triggers.SelectedItem.ToString() == NEW_TRIGGER_TEXT) {
                    TriggerModal tm = new TriggerModal();

                    if (tm.ShowDialog() == DialogResult.OK) {
                        Trigger t = new Trigger(tm.TriggerExecLoc, tm.TriggerExecArgs);
                        this.lBox_Triggers.Items.Insert(this.lBox_Triggers.Items.Count - 1, t);
                    }
                }
                // If the item is an actual trigger, pre-populate trigger modal
                else if(lBox_Triggers.SelectedItem != null) {
                    Trigger t = (Trigger)lBox_Triggers.SelectedItem;
                    TriggerModal tm = new TriggerModal(t);

                    if (tm.ShowDialog() == DialogResult.OK) {
                        int index = this.lBox_Triggers.SelectedIndex;
                        this.lBox_Triggers.Items.Remove(this.lBox_Triggers.SelectedItem);
                        t = new Trigger(tm.TriggerExecLoc, tm.TriggerExecArgs);
                        this.lBox_Triggers.Items.Insert(index, t);
                    }
                }
        }

        /// <summary>
        /// Grabs information from form elements to create a new profile
        /// At the same time, schedule this new profile as an update job
        /// </summary>
        /// <param name="sender">Save button</param>
        /// <param name="e">Click</param>
        private void btn_Save_Click(object sender, EventArgs e) {
            int tUF = 0;

            Registrar tR = Registrar.None;
            Enum.TryParse(this.comboBox_Registrar.Text, out tR);

            // Parse comboBox time value to both an UpdatePeriod and UpdatePeriodType
            Time tT = Time.Seconds;
            string[] timeParts = this.comboBox_UpdatePeriod.SelectedItem.ToString().Split(' ');
            Enum.TryParse(timeParts[1], out tT);
            tUF = Convert.ToInt32(timeParts[0]);

            int TSMIIndex = ProfileManager.ProfileList.IndexOf(_Profile);

            // If profile has no triggers
            if (lBox_Triggers.Items.Count == 1 || !this.cBox_TriggerOnUpdate.Checked) {
                _Profile = new Profile(this.tBox_Name.Text,
                    tR,
                    tBox_Host.Text,
                    tBox_Domain.Text,
                    tBox_DynDNSPassword.Text,
                    tUF,
                    tT,
                    tBox_IPAddress.Text,
                    cBox_AutoDetectIP.Checked
                    );
            // If profile has trigger(s)
            } else if (this.cBox_TriggerOnUpdate.Checked) {
                List<Trigger> ts = new List<Trigger>();
                lBox_Triggers.Items.Remove(NEW_TRIGGER_TEXT);
                foreach (Trigger t in lBox_Triggers.Items)
                    ts.Add(t);

                _Profile = new Profile(this.tBox_Name.Text,
                    tR,
                    tBox_Host.Text,
                    tBox_Domain.Text,
                    tBox_DynDNSPassword.Text,
                    tUF,
                    tT,
                    tBox_IPAddress.Text,
                    cBox_AutoDetectIP.Checked,
                    ts
                    );
            }

            // Add new profile to profile collection
            TabPage currentPage = (TabPage)this.Parent;
            if (IsNewProfile) {
                ProfileManager.ProfileList.Add(_Profile);
            } else {
                ProfileManager.ProfileList.RemoveAt(TSMIIndex);
                ProfileManager.ProfileList.Insert(TSMIIndex, _Profile);
            }

            // Replace existing profile, or create a new one
            Scheduler.ReplaceJob(_Profile);

            // Closes current tab
            currentPage.Dispose();
        }

        /// <summary>
        /// Closes current profile modification tab, discarding any changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Discard_Click(object sender, EventArgs e) {
            TabPage currentPage = (TabPage)this.Parent;
            currentPage.Dispose();
        }

        /// <summary>
        /// Deletes opened profile (has to exist first) from both profile collection
        ///  and scheduler (also deletes triggers on job deletion)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e) {
            Scheduler.DeleteJob(_Profile);
            ProfileManager.ProfileList.Remove(_Profile);
            btn_Discard_Click(sender, e);
        }
        #endregion
    }
}
