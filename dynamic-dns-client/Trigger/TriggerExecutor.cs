using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_dns_client {

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

    class TriggerExecutor {

        private Trigger _Trigger;
        private Profile _Profile;

        public TriggerExecutor(Trigger t, Profile p) {
            this._Trigger = t;
            this._Profile = p;
        }

        public void Execute() {
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

        public void ExecuteMailer() {
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

            new SimpleMailer(body, 
                string.Format("{0} Update ({1})", _Profile.Name, _Profile.Domain), 
                _Trigger.TriggerArgs);

            MainForm.NewEntry
                (string.Format("Notification sent to [{0}]",
                    _Trigger.TriggerArgs),
                "TriggerExecutor", System.Drawing.Color.Orange);
        }

    }
}
