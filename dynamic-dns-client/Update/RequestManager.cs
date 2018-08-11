using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

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
    /// Singleton for handling HTTP update requests
    /// </summary>
    sealed class RequestManager : IDisposable{

        #region Properties and Fields
        private static RequestManager instance = null;
        public static RequestManager Instance {
            get {
                // Locking for thread-safety
                lock (padlock) {
                    if (instance == null) {
                        instance = new RequestManager();
                    }
                    return instance;
                }
            }
        }

        private static readonly object padlock = new object();
        private static HttpClient requester;
        #endregion

        #region Constructors
        RequestManager() {
            requester = new HttpClient();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs an asynchronous HTTP update request to supplied resource at 
        /// @reqStr with MIME type of @header
        /// </summary>
        /// <param name="reqStr">Web resource URL</param>
        /// <param name="header">MIME type</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Request(string reqStr, string header) {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, reqStr);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(header));

            HttpResponseMessage response = await requester.SendAsync(
                request, System.Threading.CancellationToken.None);

            return response;
        }

        /// <summary>
        /// Performs an asynchronous HTTP request to IPIfy for public IP of network which
        ///  node running this application is connected to
        /// </summary>
        /// <returns>Public IP address</returns>
        public async Task<string> IPIfyRequest() {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.ipify.org");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await requester.SendAsync(
                request, System.Threading.CancellationToken.None);

            // Examine response, if success status code, then return the content of the response, which
            //  is plaintext containing the public IP (e.g. '127.0.0.1' literally).
            // Else, return an error message
            if (response.IsSuccessStatusCode) {
                var fresponse = response.Content.ReadAsStringAsync();
                return fresponse.Result;
            }
            else {
                return string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        /// <summary>
        /// Dispose of RequestManager, which closes HttpClient
        /// </summary>
        public void Dispose() {
            MainForm.NewEntry("Halting all update requests", "RequestManager", Color.DarkGray);
            requester.Dispose();
        }
        #endregion
    }
}
