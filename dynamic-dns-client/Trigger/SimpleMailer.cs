using System.Net;
using System.Net.Mail;

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
    /// Basic implementation of System.Net.Mail as a trigger to notify 
    ///  recipients on domain updates/changes
    /// </summary>
    class SimpleMailer {

        /// <summary>
        /// Constructor of SimpleMailer
        /// Creates an SMTP client object specifically for gmail's SMTP server,
        ///  constructs a message, and sends it.
        /// </summary>
        /// <param name="msg">Message Body</param>
        /// <param name="subj">Subject</param>
        /// <param name="toAddr">Recepient</param>
        public SimpleMailer(string msg,string subj, string toAddr) {
            try {
                // Create SmtpClient based on gmail
                // Credentials taken directly from Settings file
                SmtpClient smtp = new SmtpClient {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(
                        Properties.Settings.Default.OutgoingMailAddress,
                        Properties.Settings.Default.OutgoingMailPassword),
                    Timeout = 20000
                };
                // Creates message based on provided arguments and sends message
                using (MailMessage message = new MailMessage(
                    Properties.Settings.Default.OutgoingMailAddress, toAddr) {
                    Subject = subj,
                    Body = msg,
                    IsBodyHtml = true
                }) {
                    smtp.Send(message);
                }
            } catch(System.Exception e) {
                MainForm.NewEntry(
                    string.Format("Could not send notification e-mail. Error: {0}", e.Message),
                    "SimpleMailer", System.Drawing.Color.Red);
            }
        }

    }
}
