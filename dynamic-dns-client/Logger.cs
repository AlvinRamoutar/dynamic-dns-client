using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_dns_client {
    class Logger {

        private static Logger instance = null;
        private static readonly object padlock = new object();
        private System.Windows.Forms.RichTextBox LogBox;

        public static Logger Instance {
            get {
                lock (padlock) {
                    if (instance == null) {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }

        public void Init(System.Windows.Forms.RichTextBox logBox) {
            LogBox = logBox;
        }

        public void NewEntry(string message, string source, Color color) {
            string msgText = string.Format("[{0}][{1}]{2}", 
                DateTime.Now.ToLocalTime().ToShortTimeString().ToString(), source, message);
            LogBox.ScrollToCaret();
            LogBox.SelectionColor = color;
            LogBox.AppendText(msgText);
            LogBox.AppendText("\r\n");
        }
    }
}
