using System;
using System.Threading.Tasks;
using Hangfire;

namespace Jobs
{
    public class Job : IJob
    {
        // pacote Hangfire.MaximumconCurrentExecutions
        [MaximumConcurrentExecutions(3,1,1)]
        public async Task Run()
        {
            Console.WriteLine("ping");
            await Task.Delay(500);
            Console.WriteLine("pong");
            await Task.Delay(500);
        }
        public void Schedule(string jobId, string cron)
        {
            RecurringJob.AddOrUpdate<Job>(jobId, job => job.Run(), cron, TimeZoneInfo.Local, "default");
        }
    }
}