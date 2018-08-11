using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_dns_client {
    class SimpleMailer {

        public SimpleMailer(string msg,string subj, string toAddr) {

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
            using (MailMessage message = new MailMessage(
                Properties.Settings.Default.OutgoingMailAddress, toAddr) {
                Subject = subj,
                Body = msg,
                IsBodyHtml = true
            }) {
                smtp.Send(message);
            }
        }

    }
}
