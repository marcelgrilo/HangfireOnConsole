using System.Threading.Tasks;

namespace Jobs
{
    public interface IJob
    {
         Task Run();
         void Schedule(string jobId, string cron);
    }
}