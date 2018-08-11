using System;
using System.Collections.Generic;
using System.Drawing;
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

    #region Delegate Definitions
    delegate void UpdateLogBoxDelegate(string msg, Color color);
    delegate void UpdateStatusLabelDelegate(string msg);
    #endregion

    /// <summary>
    /// Handlers & code-behind for MainForm Form
    /// Primary form of application
    /// </summary>
    public partial class MainForm : Form {

        #region Properties and Fields
        public static MainForm _instance = null;
        public static MainForm Instance {
            get {
                // Locking for thread safety
                lock (padlock) {
                    if (_instance == null) {
                        _instance = new MainForm();
                        _instance.Init();
                    }
                    return _instance;
                }
            }
        }

        private static readonly object padlock = new object();
        private static List<Tuple<string, string, Color>> logTQueue = new List<Tuple<string, string, Color>>();
        #endregion

        #region Constructors
        MainForm() {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes particular form elements
        /// </summary>
        public void Init() {
            // Set window title
            this.Text = Properties.Settings.Default.AppName;

            // Update logBox with queued logs
            foreach (Tuple<string, string, Color> t in logTQueue.ToArray())
                NewEntry(t.Item1, t.Item2, t.Item3);

            NewEntry("=================", "Info", Color.Blue);
            NewEntry("Dynamic DNS Client", "Info", Color.Blue);
            NewEntry("Alvin Ramoutar, 2018", "Info", Color.Blue);
            NewEntry("=================", "Info", Color.Blue);

            ProfileManager.Load();

            // Populate scheduler with existing jobs from loaded data file
            if (ProfileManager.ProfileList.Count != 0) {
                foreach (Profile p in ProfileManager.ProfileList) {
                    Scheduler.AddJob(p.Name, p.Name + "_Group", p.UpdatePeriod, p.UpdatePeriodType, p);
                    MainForm.NewEntry(
                        string.Format("Added schedule job for '{0}'", p.Name), "MainForm", Color.Black);
                }
            }
        }


        /// <summary>
        /// Creates a new tab page for creating a new profile.
        /// Populate tab page with custom user control, NewProfileControl
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
        
        /// <summary>
        /// Update modify profile comboBox on combobox open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyProfileToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            PopulateModifyProfilesDropdown();
        }

        /// <summary>
        /// Populate modify profile comboBox with entires from ProfileList
        /// </summary>
        private void PopulateModifyProfilesDropdown() {
            TSMIComboBox_Profiles.Items.Clear();
            TSMIComboBox_Profiles.Items.Add("Select a profile...");
            foreach (Profile p in ProfileManager.ProfileList) {
                TSMIComboBox_Profiles.Items.Add(p);
            }
            TSMIComboBox_Profiles.SelectedIndex = 0;
        }

        /// <summary>
        /// Used for comboBox dropdown tool strip item to create a new tab page for
        ///  adding/modifying profiles
        /// </summary>
        /// <param name="sender">Tool Strip Item</param>
        /// <param name="e">Click</param>
        private void TSMIComboBox_Profiles_SelectedIndexChanged(object sender, EventArgs e) {
            if (TSMIComboBox_Profiles.SelectedIndex != 0) {
                Profile p = (Profile)TSMIComboBox_Profiles.SelectedItem;

                // Create new tab page with a new profile control
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

        /// <summary>
        /// Creates a new log entry
        /// If the logBox hasn't been initialized, append to log queue, which is promptly
        ///  dealt with on initialization of logBox
        /// </summary>
        /// <param name="message">Log message only</param>
        /// <param name="source">Source (class) of message</param>
        /// <param name="color">Color of message text</param>
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

        /// <summary>
        /// Updates the logBox (rich text box) on Log tab page
        /// Enlightens user on background tasks happening (e.g. Updates)
        /// Implementing thread-safe access using InvokeRequired and delegates
        /// </summary>
        /// <param name="msg">Log message</param>
        /// <param name="color">Color of log message</param>
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


        /// <summary>
        /// Updates the status label at bottom of MainForm
        /// Purpose of label is to show the last logged entry, even when not on Log tab page
        /// Implementing thread-safe access using InvokeRequired and delegates
        /// </summary>
        /// <param name="msg">Log message</param>
        public void UpdateStatusLbl(string msg) {
            if (this.lbl_Status.InvokeRequired) {
                UpdateStatusLabelDelegate degate = new UpdateStatusLabelDelegate(UpdateStatusLbl);
                this.Invoke(degate, new object[] { msg });
            }
            else {
                this.lbl_Status.Text = msg;
            }
        }


        /// <summary>
        /// Launches a help/readme resource for project
        /// </summary>
        /// <param name="sender">Help menu strip item</param>
        /// <param name="e">Click</param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("This would open a webpage to this projects' GitHub repository. " +
                "Only available after 2018/08/17.", "Help Prompt");
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
        #endregion
    }
}
