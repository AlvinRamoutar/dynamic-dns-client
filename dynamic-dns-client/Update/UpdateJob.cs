using Quartz;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

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
    /// Quartz.NET job for updating DNS records
    /// </summary>
    public class UpdateJob : IJob {

        #region Constructors
        public UpdateJob() { }
        #endregion

        #region Methods
        /// <summary>
        /// Executes job on schedule, start first with triggers ran later
        /// </summary>
        /// <param name="context">Object containing profile data</param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context) {

            // Retrieve profile from context
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            Profile profile = (Profile)dataMap.Get("profile");

            string publicIP = "";
            string profileIP = profile.IPAddress;
            bool IsUpdateNeeded = true;

            // IF user set profile to auto detect IP (use public IP as IP address)
            if (profile.AutoDetectIP) {
                publicIP = await PublicIPQuery(profile.IPAddress);
                // If the stored IP for that domain on radarS
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

            // Update/fight as needed
            if (IsUpdateNeeded) {
                // Perform HTTP request to domain registrar
                HttpResponseMessage response =
                    await RequestManager.Instance.Request(
                        HttpRegistrarString.Resolve(profile), "application/json");
                profile.LastResponse = response;
                MainForm.NewEntry(
                    string.Format("Ran update for {0}: Code({1}), Message: {2}",
                        profile.Name, profile.LastResponse.StatusCode, RetrieveHTTPResponseString(response)),
                    "UpdateJob", System.Drawing.Color.Black);

                // If job has any triggers associated with it
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

        /// <summary>
        /// Performs special http request to IPIfy only to grab current public IP of connected network
        /// </summary>
        /// <param name="currentIP">Current saved IP of profile</param>
        /// <returns>Current public IP</returns>
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

        /// <summary>
        /// Formats response content from http update request
        /// </summary>
        /// <param name="msg">Message object from http update request</param>
        /// <returns>Friendlier string with response content</returns>
        private string RetrieveHTTPResponseString(HttpResponseMessage msg) {
            string rawXML = msg.Content.ReadAsStringAsync().Result;
            string errors = "";

            // Parsing document, looking for error nodes.
            // Append to error string if any.
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

                // Return success if errors string is empty, else return errors
                return (errors == "") ? "SUCCESS" : errors;
            } catch (Exception) {
                // Perhaps content is not XML? Return as is.
                return rawXML;
            }
        }
        #endregion
    }
}
