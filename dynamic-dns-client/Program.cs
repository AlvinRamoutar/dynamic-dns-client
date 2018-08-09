using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynamic_dns_client {
    static class Program {

        public static Scheduler Schedule;
        private static RequestManager _RequestManager;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            ProfileManager.Init();
            _RequestManager = RequestManager.Instance;
            Schedule = Scheduler.Instance;

            //Task t = Task.Factory.StartNew(async () => {
            //    string r = await _RequestManager.IPIfyRequest();
            //    MessageBox.Show(r);

            //});

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm());
        }
    }
}
