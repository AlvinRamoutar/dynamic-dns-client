using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_dns_client {
    class Scheduler {

        private static Scheduler instance = null;
        private static readonly object padlock = new object();
        private static StdSchedulerFactory sf;
        public static IScheduler s;

        public enum Time {
            Hours, Minutes, Seconds
        }

        Scheduler() {
            Init();
        }


        private static async void Init() {
            NameValueCollection props = new NameValueCollection
                {{ "quartz.serializer.type", "binary" }};
            sf = new StdSchedulerFactory(props);
            s = await sf.GetScheduler();
            await s.Start();
        }


        public static Scheduler Instance {
            get {
                lock (padlock) {
                    if (instance == null) {
                        instance = new Scheduler();
                    }
                    return instance;
                }
            }
        }

        //https://www.quartz-scheduler.net/documentation/quartz-3.x/tutorial/using-quartz.html
        public static void AddJob(string name, string group, int period, Time type, object profile) {

            IDictionary<string, object> tmpDict = new Dictionary<string, object>();
            tmpDict.Add("profile", profile);
            JobDataMap jdmIncProfile = new JobDataMap(tmpDict);

            IJobDetail job = JobBuilder.Create<UpdateJob>()
                .WithIdentity(name, group)
                .SetJobData(jdmIncProfile)
            .Build();

            
            TriggerBuilder triggerBuild = TriggerBuilder.Create().WithIdentity(name + "_t", group);
            switch(type) {
                case Time.Hours:
                    triggerBuild.WithSimpleSchedule(x => x.WithIntervalInHours(period).RepeatForever());
                    break;
                case Time.Minutes:
                    triggerBuild.WithSimpleSchedule(x => x.WithIntervalInMinutes(period).RepeatForever());
                    break;
                case Time.Seconds:
                    triggerBuild.WithSimpleSchedule(x => x.WithIntervalInSeconds(period).WithRepeatCount(10));
                    break;
            }


            ITrigger builtTrigger = triggerBuild.StartNow().Build();
            s.ScheduleJob(job, builtTrigger);
        }
    }
}
