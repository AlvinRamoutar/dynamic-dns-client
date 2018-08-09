using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_dns_client {

    public class UpdateJob : IJob {

        public UpdateJob() { }

        public async Task Execute(IJobExecutionContext context) {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            Profile profile = (Profile)dataMap.Get("profile");

            string reqStr = "";
            string IPAddr = profile.IPAddress;

            if (profile.AutoDetectIP) {
                IPAddr = await RequestManager.Instance.IPIfyRequest();
                profile.IPAddress = IPAddr;
                reqStr = HttpRegistrarString.Resolve(profile);
            } else {
                reqStr = HttpRegistrarString.Resolve(profile);
            }

            HttpResponseMessage response = 
                await RequestManager.Instance.Request(reqStr, "application/json");

            profile.LastResponse = response;
            profile.LastUpdated = DateTime.UtcNow;
        }
    }
}
