using System;
using System.Collections.Generic;
using Quartz;
using Quartz.Impl;

namespace AutofacDemo
{
    public class Quartz
    {
        public static void QuartzMain()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            IJobDetail job = JobBuilder.Create<DumbJob>()
                .WithIdentity("myJob", "group1")
                .UsingJobData("jobSays", "Hello World!")
                .UsingJobData("myFloatValue", 3.141f)
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(3)
                    .RepeatForever())
                .Build();
            sched.ScheduleJob(job, trigger);
        }
    }

    public class DumbJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            //string jobSays = dataMap.GetString("jobSays");
            //float myFloatValue = dataMap.GetFloat("myFloatValue");
            Console.WriteLine("Group: " + key.Group + "   Name:" + key.Name);
            IDictionary<string, object> dic = dataMap.WrappedMap;

            foreach (KeyValuePair<string, object> keyValuePair in dic)
            {
                Console.WriteLine("Keys:" + keyValuePair.Key + "   Values:" + keyValuePair.Value);
            }

            Console.WriteLine("");
            //Console.Error.WriteLine("Instance " + key + " of DumbJob says: " + jobSays + ", and val is: " + myFloatValue);
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}