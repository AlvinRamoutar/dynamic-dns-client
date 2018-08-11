using System;
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

    /// <summary>
    /// Starting class for the application
    /// </summary>
    static class Program {

        public static Scheduler Schedule;
        private static RequestManager _RequestManager;

        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main() {

            // Loads profile data from save file specified in settings
            ProfileManager.Init();

            // Initializes singletons
            _RequestManager = RequestManager.Instance;
            Schedule = Scheduler.Instance;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.Instance);
        }
    }
}
