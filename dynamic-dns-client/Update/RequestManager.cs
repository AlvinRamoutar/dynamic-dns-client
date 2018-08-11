using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_dns_client {
    sealed class RequestManager : IDisposable{

        private static RequestManager instance = null;
        private static readonly object padlock = new object();
        private static HttpClient requester;


        RequestManager() {
            requester = new HttpClient();
        }


        public static RequestManager Instance {
            get {
                lock (padlock) {
                    if (instance == null) {
                        instance = new RequestManager();
                    }
                    return instance;
                }
            }
        }


        public async Task<HttpResponseMessage> Request(string reqStr, string header) {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, reqStr);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(header));

            HttpResponseMessage response = await requester.SendAsync(
                request, System.Threading.CancellationToken.None);

            return response;
        }


        /*
         * POssibly redundant
         * 
        public async Task<string> Request(string reqStr, string urlParams, string header) {
            requester.BaseAddress = new Uri(reqStr);

            // Add an Accept header for JSON format.
            requester.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(header));


            HttpResponseMessage response = requester.GetAsync(urlParams).Result;
            if (response.IsSuccessStatusCode) {
                var fresponse = response.Content.ReadAsStringAsync();
                return fresponse.Result;
            }
            else {
                return string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        */


        public async Task<string> IPIfyRequest() {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.ipify.org");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await requester.SendAsync(
                request, System.Threading.CancellationToken.None);

            if (response.IsSuccessStatusCode) {
                var fresponse = response.Content.ReadAsStringAsync();
                return fresponse.Result;
            }
            else {
                return string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void Dispose() {
            MainForm.NewEntry("Halting all update requests", "RequestManager", Color.DarkGray);
            requester.Dispose();
        }
    }
}
