using System.Diagnostics;
using System.Threading.Tasks;

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
    /// Trigger structre comprising of its location, and arguments (if any)
    /// </summary>
    public struct Trigger {
        public string TriggerLoc;
        public string TriggerArgs;

        public Trigger(string _triggerLoc, string _triggerArgs) {
            TriggerLoc = _triggerLoc;
            TriggerArgs = _triggerArgs;
        }

        public override string ToString() {
            return TriggerLoc;
        }
    }

    /// <summary>
    /// Executes a particular trigger using System.Diagnostics.Process
    /// Also contains logic for creating an e-mail trigger
    /// </summary>
    class TriggerExecutor {

        #region Properties and Fields
        private Trigger _Trigger;
        private Profile _Profile;
        #endregion

        #region Constructors
        public TriggerExecutor(Trigger t, Profile p) {
            this._Trigger = t;
            this._Profile = p;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Executes a particular trigger using System.Diagnostics.Process
        /// Process object is created using:
        /// - Trigger location (should be a full path to an executable)
        /// - Trigger arguments (if any, optional)
        /// To specify an e-mail trigger:
        /// - Trigger location = 'email'
        /// - Trigger args is the notifier's e-mail
        /// </summary>
        public void Execute() {
            // Execute process in new thread as to not halt executing thread
            Task t = new Task(() => {
                try {
                    if (_Trigger.TriggerLoc == "email") {
                        ExecuteMailer();
                    }
                    else {
                        Process triggerTask = new Process();
                        triggerTask.StartInfo.FileName = _Trigger.TriggerLoc;
                        triggerTask.StartInfo.Arguments = _Trigger.TriggerLoc;
                        triggerTask.Start();
                    }
                } catch(System.ComponentModel.Win32Exception w32e) {
                    MainForm.NewEntry(
                        string.Format("Could not execute trigger: [{0}]. Error: [{1}]",
                            _Trigger.TriggerLoc, w32e.Message),
                        "TriggerExecutor", System.Drawing.Color.Red);
                }
            });
            t.Start();
        }

        /// <summary>
        /// Executes a mailer trigger using SimpleMailer
        /// To specify an e-mail trigger:
        /// - Trigger location = 'email'
        /// - Trigger args is the notifier's e-mail
        /// Account used for outgoing e-mails is identified in settings
        /// </summary>
        public void ExecuteMailer() {

            // Format HTML of message body
            string body = string.Format(
                "<p>Hello,<p>" +
                "<p>Your domain <strong>{0}</strong> has undergone a DNS record update.</p><br>" +
                "<p>Profile: <strong>{1}</strong></p>" +
                "<p>Host: <strong>{2}</strong></p>" +
                "<p>Domain: <strong>{3}</strong></p>" +
                "<p>IP: <strong>{4}</strong></p><br>" +
                "<p>Regards,</p>" +
                "<p>{5}</p>",
                _Profile.Domain,
                _Profile.Name,
                _Profile.Host,
                _Profile.Domain,
                _Profile.IPAddress,
                Properties.Settings.Default.AppName);

            // Mail on construction of SimpleMailer object
            new SimpleMailer(body, 
                string.Format("{0} Update ({1})", _Profile.Name, _Profile.Domain), 
                _Trigger.TriggerArgs);

            MainForm.NewEntry
                (string.Format("Notification sent to [{0}]",
                    _Trigger.TriggerArgs),
                "TriggerExecutor", System.Drawing.Color.Orange);
        }
        #endregion
    }
}
