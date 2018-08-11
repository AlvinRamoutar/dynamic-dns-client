using System;
using System.Windows.Forms;

/// <summary>
/// Author: Alvin Ramoutar (991454918)
/// Date:   2018/08/13
/// Desc:   A Dynamic DNS Client for registrars which provide a web service
///         for updates via HTTP. Also features triggers.
///         For debugging this solution, please refer to the readme
/// </summary>
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.Instance);
        }
    }
}
