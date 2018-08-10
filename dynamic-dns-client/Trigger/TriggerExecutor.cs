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

        public TriggerExecutor(Trigger t) {
            this._Trigger = t;
        }

        public void Execute() {
            Task t = new Task(() => {
                Process triggerTask = new Process();
                triggerTask.StartInfo.FileName = _Trigger.TriggerLoc;
                triggerTask.StartInfo.Arguments = _Trigger.TriggerLoc;
                triggerTask.Start();
            });
            t.Start();
        }

    }
}
