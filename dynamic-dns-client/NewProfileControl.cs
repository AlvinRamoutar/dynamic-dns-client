using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynamic_dns_client {
    public partial class NewProfileControl : UserControl {

        private Profile _Profile {get; set;}
        private bool IsNewProfile = true;

        internal const string NEW_TRIGGER_TEXT = "Add New Trigger...";

        public NewProfileControl() {
            InitializeComponent();
            LoadComboBoxes();
            IsNewProfile = true;
        }

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


        private void cBox_AutoDetectIP_CheckedChanged(object sender, EventArgs e) {
            if (cBox_AutoDetectIP.Checked)
                this.tBox_IPAddress.Enabled = false;
            else
                this.tBox_IPAddress.Enabled = true;
        }

        private void cBox_TriggerOnUpdate_CheckedChanged(object sender, EventArgs e) {
            if (cBox_TriggerOnUpdate.Checked)
                this.lBox_Triggers.Enabled = true;
            else
                this.lBox_Triggers.Enabled = false;
        }

        private void lBox_Triggers_DoubleClick(object sender, EventArgs e) {
            if (lBox_Triggers.SelectedItem != null)
                if (lBox_Triggers.SelectedItem.ToString() == NEW_TRIGGER_TEXT) {
                    TriggerModal tm = new TriggerModal();

                    if (tm.ShowDialog() == DialogResult.OK) {
                        Trigger t = new Trigger(tm.TriggerExecLoc, tm.TriggerExecArgs);
                        //TriggerExecutor trigEx = new TriggerExecutor(t, _Profile);
                        this.lBox_Triggers.Items.Insert(this.lBox_Triggers.Items.Count - 1, t);
                    }
                } else if(lBox_Triggers.SelectedItem != null) {
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


        private void btn_Save_Click(object sender, EventArgs e) {
            int tUF = 0;

            Registrar tR = Registrar.None;
            Enum.TryParse(this.comboBox_Registrar.Text, out tR);

            Time tT = Time.Seconds;
            string[] timeParts = this.comboBox_UpdatePeriod.SelectedItem.ToString().Split(' ');
            Enum.TryParse(timeParts[1], out tT);
            tUF = Convert.ToInt32(timeParts[0]);

            int TSMIIndex = ProfileManager.ProfileList.IndexOf(_Profile);

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

            TabPage currentPage = (TabPage)this.Parent;
            if (IsNewProfile) {
                ProfileManager.ProfileList.Add(_Profile);
            } else {
                ProfileManager.ProfileList.RemoveAt(TSMIIndex);
                ProfileManager.ProfileList.Insert(TSMIIndex, _Profile);
            }

            Scheduler.ReplaceJob(_Profile);
            currentPage.Dispose();
        }

        private void btn_Discard_Click(object sender, EventArgs e) {
            TabPage currentPage = (TabPage)this.Parent;
            currentPage.Dispose();
        }

        private void btn_Delete_Click(object sender, EventArgs e) {
            Scheduler.DeleteJob(_Profile);
            ProfileManager.ProfileList.Remove(_Profile);
            btn_Discard_Click(sender, e);
        }
    }
}
