using System.Collections.Generic;

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
    /// Profile object containing domain-specific information
    /// Data required by profile object is available to domain owners
    /// </summary>
    public class Profile {

        #region Properties and Fields
        internal string Name { get; set; }
        internal Registrar Registrar { get; set; }
        internal string Host { get; set; }
        internal string Domain { get; set; }
        internal string DynDNSPassword { get; set; }
        internal int UpdatePeriod { get; set; }
        internal Time UpdatePeriodType { get; set; }
        internal string IPAddress { get; set; }
        internal bool AutoDetectIP { get; set; }

        internal System.Net.Http.HttpResponseMessage LastResponse { get; set; }
        internal System.DateTime LastUpdated { get; set; }

        internal List<Trigger> Triggers { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a profile without any triggers
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_registrar"></param>
        /// <param name="_host"></param>
        /// <param name="_domain"></param>
        /// <param name="_dyndnspassword"></param>
        /// <param name="_updatePeriod"></param>
        /// <param name="_updatePeriodType"></param>
        /// <param name="_IPAddress"></param>
        /// <param name="_autoDetectIP"></param>
        public Profile(string _name, Registrar _registrar, string _host, string _domain, 
            string _dyndnspassword, int _updatePeriod, Time _updatePeriodType,
            string _IPAddress, bool _autoDetectIP) {

            this.Name = _name;
            this.Registrar = _registrar;
            this.Host = _host;
            this.Domain = _domain;
            this.DynDNSPassword = _dyndnspassword;
            this.UpdatePeriod = _updatePeriod;
            this.UpdatePeriodType = _updatePeriodType;
            this.IPAddress = _IPAddress;
            this.AutoDetectIP = _autoDetectIP;
        }

        /// <summary>
        /// Constructs a profile with triggers
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_registrar"></param>
        /// <param name="_host"></param>
        /// <param name="_domain"></param>
        /// <param name="_dyndnspassword"></param>
        /// <param name="_updatePeriod"></param>
        /// <param name="_updatePeriodType"></param>
        /// <param name="_IPAddress"></param>
        /// <param name="_autoDetectIP"></param>
        /// <param name="_triggers"></param>
        public Profile(string _name, Registrar _registrar, string _host, string _domain, 
            string _dyndnspassword, int _updatePeriod, Time _updatePeriodType, string _IPAddress, 
            bool _autoDetectIP, List<Trigger> _triggers) {

            this.Name = _name;
            this.Registrar = _registrar;
            this.Host = _host;
            this.Domain = _domain;
            this.DynDNSPassword = _dyndnspassword;
            this.UpdatePeriod = _updatePeriod;
            this.UpdatePeriodType = _updatePeriodType;
            this.IPAddress = _IPAddress;
            this.AutoDetectIP = _autoDetectIP;

            if(this.Triggers != null)
                this.Triggers.Clear();
            this.Triggers = new List<Trigger>();
            this.Triggers.AddRange(_triggers);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Evaluates equality between two profiles using all of its properties,
        ///  with the exception of Triggers
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            Profile profileObj = obj as Profile;
            if (profileObj == null)
                return false;

            if (this.Name == profileObj.Name &&
                this.Registrar == profileObj.Registrar &&
                this.Host == profileObj.Host &&
                this.Domain == profileObj.Domain &&
                this.DynDNSPassword == profileObj.DynDNSPassword &&
                this.UpdatePeriod == profileObj.UpdatePeriod &&
                this.UpdatePeriodType == profileObj.UpdatePeriodType &&
                this.IPAddress == profileObj.IPAddress &&
                this.AutoDetectIP == profileObj.AutoDetectIP)
                return true;
            else
                return false;
        }


        public override int GetHashCode() {
            return this.GetHashCode();
        }


        public override string ToString() {
            return this.Name;
        }
        #endregion
    }
}
