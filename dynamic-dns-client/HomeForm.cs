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
    public partial class HomeForm : Form {

        public HomeForm() {
            InitializeComponent();

            Logger.Instance.Init(richTBox_LogBox);
            Logger.Instance.NewEntry("TestMsg", "HomeForm", Color.Orange);
            Logger.Instance.NewEntry("TestMsg", "HomeForm", Color.Purple);


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
    }
}
