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
    /// Enum for different domain Registrars supported by application.
    /// </summary>
    public enum Registrar {
        None,
        Namecheap
    }

    /// <summary>
    /// Toolkit for resolving the request string for a particular registrar.
    /// Skeleton of request string is stored in settings file for particular registrars,
    ///  with name '$REGISTRAR_HttpString'
    /// </summary>
    class HttpRegistrarString {

        /// <summary>
        /// Creates a request URL string for a registrar's particular API for DNS updates via HTTP
        /// </summary>
        /// <param name="p">Profile to create request URL for</param>
        /// <returns>Request URL string</returns>
        public static string Resolve(Profile p) {
            switch (p.Registrar) {
                case Registrar.Namecheap:
                    string reqStr = string.Format(Properties.Settings.Default.Namecheap_HttpString,
                        p.Host, p.Domain, p.DynDNSPassword, p.IPAddress);
                    return reqStr;
                default:
                    return null;
            }

        }
    }
}
