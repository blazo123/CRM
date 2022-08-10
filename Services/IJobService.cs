using CRM.Model;

namespace CRM.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobById(int jobId);
        Task<bool> AddJob(Job job);
        Task<bool> DeleteJob(int jobId);
        Task<bool> UpdateJob(Job job);
    }
}
