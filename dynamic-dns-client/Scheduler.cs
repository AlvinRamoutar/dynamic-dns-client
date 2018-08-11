using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

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
    /// Time parts, used for UpdatePeriodType
    /// </summary>
    public enum Time {
        Hours, Minutes, Seconds
    }

    /// <summary>
    /// Singleton for managing the Quartz.NET scheduler
    /// https://www.quartz-scheduler.net/
    /// </summary>
    class Scheduler : IDisposable {

        #region Properties and Fields
        private static Scheduler instance = null;

        public static Scheduler Instance {
            get {
                // Locking for thread safety
                lock (padlock) {
                    if (instance == null) {
                        instance = new Scheduler();
                    }
                    return instance;
                }
            }
        }

        // 
        private static readonly object padlock = new object();
        private static StdSchedulerFactory sf;
        public static IScheduler s;
        #endregion

        #region Constructors
        Scheduler() {
            Init();
        }
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new SchedulerFactory, which is used to create a new Scheduler
        /// </summary>
        private static async void Init() {
            NameValueCollection props = new NameValueCollection
                {{ "quartz.serializer.type", "binary" }};
            sf = new StdSchedulerFactory(props);
            s = await sf.GetScheduler();
            await s.Start();
        }

        /// <summary>
        /// Adds new job to current Quartz scheduler
        /// Job executes at @period with @type units (e.g. 5 Seconds)
        /// 5 is the period, Seconds is the unit
        /// </summary>
        /// <param name="name">Name of job (same as profile)</param>
        /// <param name="group">Name of group (name of profile + '_Group')</param>
        /// <param name="period">Run Frequency</param>
        /// <param name="type">Run Frequency Type</param>
        /// <param name="profile">Profile</param>
        public static void AddJob(string name, string group, int period, Time type, object profile) {

            // Creating a custom JobDataMap to pass Profile to IJobdetail
            IDictionary<string, object> tmpDict = new Dictionary<string, object>();
            tmpDict.Add("profile", profile);
            JobDataMap jdmIncProfile = new JobDataMap(tmpDict);

            // Creating job object
            IJobDetail job = JobBuilder.Create<UpdateJob>()
                .WithIdentity(name, group)
                .SetJobData(jdmIncProfile)
            .Build();

            // Building trigger, which runs for a duration of @period @type
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


            ITrigger builtTrigger = triggerBuild.Build();
            s.ScheduleJob(job, builtTrigger);
        }

        /// <summary>
        /// Replaces job matching supplied profile (by name and group)
        /// Creates new job based on supplied profile
        /// </summary>
        /// <param name="profile">New profile, which replaces its old counterpart</param>
        public static void ReplaceJob(Profile profile) {
            s.DeleteJob(new JobKey(profile.Name, profile.Name + "_Group"));
            AddJob(profile.Name, profile.Name + "_Group", profile.UpdatePeriod, profile.UpdatePeriodType, profile);
            MainForm.NewEntry(
                string.Format("Updating job {0}", profile.Name), "Scheduler", System.Drawing.Color.Orange);
        }

        /// <summary>
        /// Deletes a specific job matching supplied profile (by name and group) from scheduler
        /// </summary>
        /// <param name="profile">Profile of job to delete</param>
        public static void DeleteJob(Profile profile) {
            s.DeleteJob(new JobKey(profile.Name, profile.Name + "_Group"));
            MainForm.NewEntry(
                string.Format("Deleting job {0}", profile.Name), "Scheduler", System.Drawing.Color.Orange);
        }

        /// <summary>
        /// Disposes of scheduler via graceful shutdown
        /// </summary>
        public void Dispose() {
            MainForm.NewEntry("Shutting down scheduler", "Scheduler", System.Drawing.Color.DarkGray);
            s.Shutdown();
            s.Clear();
        }

        #endregion
    }
}
