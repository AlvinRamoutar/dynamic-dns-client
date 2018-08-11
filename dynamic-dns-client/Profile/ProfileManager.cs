using System;
using System.Collections.Generic;
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
    /// Manages reading/writing to profile data file
    /// </summary>
    class ProfileManager {

        #region Properties and Fields
        public static List<Profile> ProfileList { get; private set; }
        #endregion

        /// <summary>
        /// Initializes ProfileList object
        /// </summary>
        public static void Init() {
            ProfileList = new List<Profile>();
        }

        /// <summary>
        /// Calls ParseIn
        /// </summary>
        public static void Load() {
            ParseIn();
        }

        /// <summary>
        /// calls ParseOut
        /// </summary>
        public static void Save() {
            ParseOut();

        }

        /// <summary>
        /// Reads datafile containing managed profiles using XmlDocumen
        /// This XML file path is defined in settings
        /// </summary>
        private static void ParseIn() {

            // Try to load datafile from defined location in settings file
            // If the datafile fails to load in for some reason, a new one is
            //  made at designated location on application close
            XmlDocument xmlDoc = new XmlDocument();
            try {
                xmlDoc.Load(Properties.Settings.Default.ProfileDataFile);
            } catch (XmlException) {
                MainForm.NewEntry("Problem loading profile data from " + Properties.Settings.Default.ProfileDataFile +
                    ". Perhaps the file has been modified?", "ProfileManager", System.Drawing.Color.Red);
                return;
            } catch(System.IO.FileNotFoundException) {
                MainForm.NewEntry("Creating new file for Managed Profiles", "ProfileManager", System.Drawing.Color.Black);
                return;
            }

            // Temporary holders for profile data
            string pName = "";
            Registrar pRegistrar = Registrar.None;
            string pHost = "";
            string pDomain = "";
            string pDynDNSPassword = "";
            int pUpdatePeriod = -1;
            Time pUpdatePeriodType = Time.Seconds;
            string pIPAddress = "";
            bool pAutoDetectIP = false;
            List<Trigger> pTriggers = null;
            string pTriggerLoc = "";
            string pTriggerArgs = "";

            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("Profile");

            // Traverse XML for each profile and populate holders with data
            foreach (XmlNode p in nodes) {
                pName = p.SelectSingleNode("Name").InnerText;
                Registrar.TryParse(p.SelectSingleNode("Registrar").InnerText, out pRegistrar);
                pHost = p.SelectSingleNode("Host").InnerText;
                pDomain = p.SelectSingleNode("Domain").InnerText;
                pDynDNSPassword = p.SelectSingleNode("DynDNSPassword").InnerText;
                pUpdatePeriod = Convert.ToInt32(p.SelectSingleNode("UpdatePeriod").InnerText);
                Time.TryParse(p.SelectSingleNode("UpdatePeriodType").InnerText, out pUpdatePeriodType);
                pIPAddress = p.SelectSingleNode("IPAddress").InnerText;
                pAutoDetectIP = Convert.ToBoolean(p.SelectSingleNode("AutoDetectIP").InnerText);

                if (p.SelectSingleNode("Triggers").HasChildNodes) {
                    pTriggers = new List<Trigger>();

                    foreach (XmlNode tU in p.SelectSingleNode("Triggers").ChildNodes) {
                        foreach (XmlNode t in tU.ChildNodes) {
                            if (t.Name == "TriggerLoc")
                                pTriggerLoc = t.InnerText;
                            else if (t.Name == "TriggerArgs")
                                pTriggerArgs = t.InnerText;
                        }
                        pTriggers.Add(new Trigger(pTriggerLoc, pTriggerArgs));
                    }
                }
                // Create new profile (w. triggers or triggerless) using holder data
                if(pTriggers == null)
                    ProfileList.Add(new Profile(pName, pRegistrar, pHost, pDomain, pDynDNSPassword, 
                        pUpdatePeriod, pUpdatePeriodType, pIPAddress, pAutoDetectIP));
                else
                    ProfileList.Add(new Profile(pName, pRegistrar, pHost, pDomain, pDynDNSPassword, 
                        pUpdatePeriod, pUpdatePeriodType, pIPAddress, pAutoDetectIP, pTriggers));
                pTriggers = null;
            }

            MainForm.NewEntry("Successfully loaded profile data",
                "ProfileManager", System.Drawing.Color.Black);
        }

        /// <summary>
        /// Counts the number of children a particular node has
        /// Based on an implementation by Tommaso Belluzzo from Stack Overflow
        /// </summary>
        /// <param name="node"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Int32 CountChildren(XmlReader node, XmlNodeType type) {
            Int32 count = 0;
            Int32 currentDepth = node.Depth;
            Int32 validDepth = currentDepth + 1;

            while (node.Read() && (node.Depth != currentDepth)) {
                if ((node.NodeType == type) && (node.Depth == validDepth))
                    ++count;
            }
            return count;
        }

        /// <summary>
        /// Serializes data from profiles in ProfileList and writes to XML datafile
        /// </summary>
        private static void ParseOut() {

            XmlTextWriter writer = new XmlTextWriter(Properties.Settings.Default.ProfileDataFile, null);

            writer.WriteStartDocument();

            writer.WriteComment("Managed Profiles for dynamic-dns-client");
            writer.WriteComment("Alvin Ramoutar, Sheridan College (2018)");

            writer.WriteStartElement("ManagedProfiles");

            // Iterate through each profile
            foreach (Profile p in ProfileList) {
                writer.WriteStartElement("Profile", "");

                writer.WriteStartElement("Name", "");
                writer.WriteString(p.Name);
                writer.WriteEndElement();

                writer.WriteStartElement("Registrar", "");
                writer.WriteString(p.Registrar.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Host", "");
                writer.WriteString(p.Host);
                writer.WriteEndElement();

                writer.WriteStartElement("Domain", "");
                writer.WriteString(p.Domain);
                writer.WriteEndElement();

                writer.WriteStartElement("DynDNSPassword", "");
                writer.WriteString(p.DynDNSPassword);
                writer.WriteEndElement();

                writer.WriteStartElement("UpdatePeriod", "");
                writer.WriteString(p.UpdatePeriod.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("UpdatePeriodType", "");
                writer.WriteString(p.UpdatePeriodType.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("IPAddress", "");
                writer.WriteString(p.IPAddress);
                writer.WriteEndElement();

                writer.WriteStartElement("AutoDetectIP", "");
                writer.WriteString(p.AutoDetectIP.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Triggers", "");

                // Populate Triggers node only if profile has triggers
                if(p.Triggers != null)
                    foreach (Trigger t in p.Triggers) {
                        writer.WriteStartElement("Trigger", "");

                            writer.WriteStartElement("TriggerLoc", "");
                            writer.WriteString(t.TriggerLoc);
                            writer.WriteEndElement();

                            writer.WriteStartElement("TriggerArgs", "");
                            writer.WriteString(t.TriggerArgs);
                            writer.WriteEndElement();

                        writer.WriteEndElement();
                    }

                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteEndDocument();

            writer.Close();

            MainForm.NewEntry("Successfully written profile data to file", 
                "ProfileManager", System.Drawing.Color.Black);
        }
    }
}
