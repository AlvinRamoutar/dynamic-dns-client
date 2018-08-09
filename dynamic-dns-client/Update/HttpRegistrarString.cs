using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_dns_client {

    public enum Registrar {
        Namecheap,
        None
    }

    class HttpRegistrarString {

        public static string Resolve(Profile p) {

            switch (p.Registrar) {
                case Registrar.Namecheap:
                    string regStr = string.Format(Properties.Settings.Default.Namecheap_HttpString,
                        p.Host, p.Domain, p.DynDNSPassword, p.IPAddress);
                    return regStr;
                default:
                    return null;
            }

        }
    }
}
