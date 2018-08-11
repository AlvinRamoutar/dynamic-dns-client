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


    delegate void UpdateLogBoxDelegate(string msg, Color color);
    delegate void UpdateStatusLabelDelegate(string msg);

    public partial class MainForm : Form {

        public static MainForm _instance = null;
        private static readonly object padlock = new object();
        private static List<Tuple<string, string, Color>> logTQueue = new List<Tuple<string, string, Color>>();

        public static MainForm Instance {
            get {
                lock (padlock) {
                    if (_instance == null) {
                        _instance = new MainForm();
                        _instance.Init();
                    }
                    return _instance;
                }
            }
        }

        MainForm() {
            InitializeComponent();
        }


        public void Init() {
            // Update logBox with queued logs
            foreach (Tuple<string, string, Color> t in logTQueue.ToArray())
                NewEntry(t.Item1, t.Item2, t.Item3);

            NewEntry("=================", "Info", Color.Blue);
            NewEntry("Dynamic DNS Client", "Info", Color.Blue);
            NewEntry("Alvin Ramoutar, 2018", "Info", Color.Blue);
            NewEntry("=================", "Info", Color.Blue);

            ProfileManager.Load();

            if (ProfileManager.ProfileList.Count != 0) {
                foreach (Profile p in ProfileManager.ProfileList) {
                    Scheduler.AddJob(p.Name, p.Name + "_Group", p.UpdatePeriod, p.UpdatePeriodType, p);
                    MainForm.NewEntry(
                        string.Format("Added schedule job for '{0}'", p.Name), "MainForm", Color.Black);
                }
            }
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
            MainForm.NewEntry("Terminating application", "HomeForm", Color.DarkGray);
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


        public static void NewEntry(string message, string source, Color color) {
            string msgText = string.Format("[{0}][{1}] {2}",
                DateTime.Now.ToLocalTime().ToShortTimeString().ToString(), source, message);

            if (_instance == null) {
                logTQueue.Add(Tuple.Create(message, source, color));
            } else {
                _instance.UpdateLogBox(msgText, color);
                _instance.UpdateStatusLbl(msgText);
            }
        }


        public void UpdateLogBox(string msg, Color color) {
            if(this.richTBox_LogBox.InvokeRequired) {
                UpdateLogBoxDelegate degate = new UpdateLogBoxDelegate(UpdateLogBox);
                this.Invoke(degate, new object[] { msg, color });
            } else {
                this.richTBox_LogBox.ScrollToCaret();
                this.richTBox_LogBox.SelectionColor = color;
                this.richTBox_LogBox.AppendText(msg);
                this.richTBox_LogBox.AppendText("\r\n");
            }
        }


        public void UpdateStatusLbl(string msg) {
            if (this.lbl_Status.InvokeRequired) {
                UpdateStatusLabelDelegate degate = new UpdateStatusLabelDelegate(UpdateStatusLbl);
                this.Invoke(degate, new object[] { msg });
            }
            else {
                this.lbl_Status.Text = msg;
            }
        }



        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("This would open a webpage to this projects' GitHub repository. " +
                "Only available after 2018/08/17.", "Help Prompt");
        }
    }
}
