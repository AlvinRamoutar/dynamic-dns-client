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
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();

            Logger.Instance.Init(richTBox_LogBox);
            Logger.Instance.NewEntry("Dynamic DNS Client", "Info", Color.Blue);
            Logger.Instance.NewEntry("Alvin Ramoutar, 2018", "Info", Color.Blue);
            Logger.Instance.NewEntry("=================", "Info", Color.Blue);

            if (ProfileManager.ProfileList.Count != 0) {
                foreach (Profile p in ProfileManager.ProfileList) {

                    Scheduler.AddJob(p.Name, p.Name + "_Group", p.UpdatePeriod, p.UpdatePeriodType, p);
                }
            }
            
            /*
            RequestManager rM = RequestManager.Instance;
            Task t = Task.Factory.StartNew(async () => {

                string r = await rM.IPIfyRequest();
                MessageBox.Show(r);

            });
            */

            /*
            ProfileManager.ProfileList.Add(new Profile("N", Registrar.Namecheap, "a", "a", "s", 2, Scheduler.Time.Seconds, "sd", false));

            List<Profile.Trigger> tmpTrigList = new List<Profile.Trigger>();
            tmpTrigList.Add(new Profile.Trigger("loc", "args"));

            ProfileManager.ProfileList.Add(new Profile("N", Registrar.Namecheap, "a", "a", "s", 2, Scheduler.Time.Seconds, "sd", false, tmpTrigList));

            ProfileManager.Save();
            */

            ProfileManager.Load();

            //Scheduler.AddJob("TName", "TGroup", 10, Scheduler.Time.Seconds, ProfileManager.ProfileList[0]);

        }

        /// <summary>
        /// Terminates application by calling Dispose on all managers
        ///  (implementing IDisposable).
        /// Also saves active ProfileList to xml in location defined in settings.
        /// </summary>
        /// <param name="sender">Exit Menu Strip Item</param>
        /// <param name="e">Click</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
            Scheduler.Instance.Dispose();
            RequestManager.Instance.Dispose();
            ProfileManager.Save();
            Logger.Instance.NewEntry("Terminating application", "HomeForm", Color.DarkGray);
        }


        /// <summary>
        /// Launches Options tab page with settings to alter functionality of client.
        /// </summary>
        /// <param name="sender">Options Menu Strip Item</param>
        /// <param name="e">Click</param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {

        }


        /// <summary>
        /// Creates a new tab page for creating a new profile.
        /// Creating a new profile also schedules an update task.
        /// </summary>
        /// <param name="sender">Add New Profile Menu Strip Item</param>
        /// <param name="e">Click</param>
        private void addNewProfileToolStripMenuItem_Click(object sender, EventArgs e) {
            TabPage newTab = new TabPage("New Profile");
            NewProfileControl npc = new NewProfileControl();
            newTab.Controls.Add(npc);

            npc.Location = new Point(0, 0);
            npc.Name = "newProfileControl";
            npc.Size = new Size(456, 207);
            npc.TabIndex = 0;

            this.tabControl.TabPages.Add(newTab);
            this.tabControl.SelectedIndex = this.tabControl.TabPages.Count - 1;
        }

        private void modifyProfileToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            PopulateModifyProfilesDropdown();
        }

        private void PopulateModifyProfilesDropdown() {
            TSMIComboBox_Profiles.Items.Clear();
            TSMIComboBox_Profiles.Items.Add("Select a profile...");
            foreach (Profile p in ProfileManager.ProfileList) {
                TSMIComboBox_Profiles.Items.Add(p);
            }
            TSMIComboBox_Profiles.SelectedIndex = 0;
        }

        private void TSMIComboBox_Profiles_SelectedIndexChanged(object sender, EventArgs e) {
            if (TSMIComboBox_Profiles.SelectedIndex != 0) {
                Profile p = (Profile)TSMIComboBox_Profiles.SelectedItem;

                TabPage newTab = new TabPage(p.Name);
                NewProfileControl npc = new NewProfileControl(p);
                newTab.Controls.Add(npc);

                npc.Location = new Point(0, 0);
                npc.Name = "newProfileControl";
                npc.Size = new Size(456, 207);
                npc.TabIndex = 0;

                this.tabControl.TabPages.Add(newTab);
                this.tabControl.SelectedIndex = this.tabControl.TabPages.Count - 1;
            }
        }
    }
}
