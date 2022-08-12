using CRM.Data;
using CRM.Model;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;
        public JobService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddJob(Job job)
        {
            if (job != null)
            {
                job.CreatedDate = DateTime.Now;
                _context.Add(job);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteJob(int jobId)
        {
            var job = await _context.Jobs.Where(x => x.Id == jobId).FirstOrDefaultAsync();
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            var jobs = await _context.Jobs.Include(c => c.Client).Include(u => u.User).ToListAsync();

            return jobs;
        }

        public async Task<Job> GetJobById(int jobId)
        {
            var job = await (_context.Jobs.Include(c => c.Client).Include(u => u.User).Where(x => x.Id == jobId).FirstOrDefaultAsync());

           return job;

        }

        public async Task<bool> UpdateJob(Job job)
        {
            var jobfromDB = _context.Jobs.Where(x => x.Id == job.Id).FirstOrDefault();

            if (jobfromDB != null)
            {

                jobfromDB.Subject = job.Subject;
                jobfromDB.User.Id = job.User.Id;
                jobfromDB.Client.Id = job.Client.Id;
                jobfromDB.Description = job.Description;
                jobfromDB.Type = job.Type;
                jobfromDB.SaleAmount = job.SaleAmount;
                jobfromDB.DateOfNextActivity = job.DateOfNextActivity;

               await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
