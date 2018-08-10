using System.Collections.Generic;
using static dynamic_dns_client.Scheduler;

namespace dynamic_dns_client {

    public class Profile {

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
    }
}
