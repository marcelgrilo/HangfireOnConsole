using System;
using Hangfire;
using Hangfire.MemoryStorage;
using Jobs;

namespace HangfireOnConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // configuring db via console.
            GlobalConfiguration.Configuration.UseMemoryStorage();

            // starting a new server.
            using(var server = new BackgroundJobServer())
            {
                Console.WriteLine("starting hangfire job server");
                // scheduling a job
                new Job().Schedule("test", Cron.Minutely());
                //enqueueing multiple jobs.
                for (int i = 0; i < 100; i++)
                {
                    BackgroundJob.Enqueue<Job>(job=>job.Run());
                }

                Console.ReadKey();
            }
        }
    }
}
