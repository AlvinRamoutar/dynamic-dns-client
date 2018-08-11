using Newtonsoft.Json.Linq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace dynamic_dns_client {

    public class UpdateJob : IJob {

        public UpdateJob() { }

        public async Task Execute(IJobExecutionContext context) {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            Profile profile = (Profile)dataMap.Get("profile");

            string publicIP = "";
            string profileIP = profile.IPAddress;
            bool IsUpdateNeeded = true;

            if (profile.AutoDetectIP) {
                publicIP = await PublicIPQuery(profile.IPAddress);
                if (profileIP == publicIP) {
                    MainForm.NewEntry(
                        string.Format("No update needed for {0}: Code({1}), Message: {2}",
                            profile.Name, profile.LastResponse.StatusCode, profile.LastResponse.Content),
                        "UpdateJob", System.Drawing.Color.Black);
                    IsUpdateNeeded = false;
                } else {
                    profile.IPAddress = publicIP;
                }
            }

            if (IsUpdateNeeded) {
                HttpResponseMessage response =
                    await RequestManager.Instance.Request(
                        HttpRegistrarString.Resolve(profile), "application/json");
                MainForm.NewEntry(HttpRegistrarString.Resolve(profile), "prof", System.Drawing.Color.Black);
                profile.LastResponse = response;
                MainForm.NewEntry(
                    string.Format("Ran update for {0}: Code({1}), Message: {2}",
                        profile.Name, profile.LastResponse.StatusCode, RetrieveHTTPResponseString(response)),
                    "UpdateJob", System.Drawing.Color.Black);

                if (profile.Triggers != null) {
                    foreach (Trigger t in profile.Triggers) {
                        MainForm.NewEntry(string.Format("Executing trigger [{0}] for profile [{1}]",
                            t.TriggerLoc, profile.Name), "UpdateJob", System.Drawing.Color.Black);
                        new TriggerExecutor(t, profile).Execute();
                    }
                }
            }

            profile.LastUpdated = DateTime.UtcNow;
        }


        private async Task<string> PublicIPQuery(string currentIP) {
            string IPAddr = currentIP;
            IPAddr = await RequestManager.Instance.IPIfyRequest();
            
            if(currentIP != IPAddr) {
                MainForm.NewEntry(
                    string.Format("Your public IP has changed. Previous: [{0}], Current: [{1}]",
                        IPAddr, currentIP),
                    "UpdateJob", System.Drawing.Color.Orange);
            }

            return IPAddr;
        }

        private string RetrieveHTTPResponseString(HttpResponseMessage msg) {
            string rawXML = msg.Content.ReadAsStringAsync().Result;
            string errors = "";

            // Parsing document, looking for error nodes.
            XmlDocument xmlDoc = new XmlDocument();
            try {
                xmlDoc.LoadXml(rawXML);
                if(xmlDoc.GetElementsByTagName("errors").Count != 0) { 
                    foreach (XmlNode errRoot in 
                        xmlDoc.SelectSingleNode("interface-response").SelectSingleNode("errors").ChildNodes) {
                        bool firstErrorReached = false;
                        foreach (XmlNode err in errRoot.ChildNodes) {
                            errors += (firstErrorReached) ? ", " + err.InnerText : err.InnerText;
                            firstErrorReached = true;
                        }
                    }
                }
                return (errors == "") ? "SUCCESS" : errors;
            } catch (Exception) {
                // Perhaps content is not XML? Return as is.
                return rawXML;
            }
        }
    }
}
