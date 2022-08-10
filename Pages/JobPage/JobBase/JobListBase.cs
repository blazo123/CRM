using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.JobPage.JobBase
{
    public class JobListBase : ComponentBase
    {
        [Inject]
        public IJobService JobService { get; set; }
        [Parameter]
        public IEnumerable<Job> Jobs { get; set; }

        protected override async Task OnInitializedAsync()
        {
           await AssignClients();
        }

        protected async Task Delete_Click(int id)
        {
            await JobService.DeleteJob(id);
            await AssignClients();
        }

        public async Task AssignClients()
        {
            Jobs = (await JobService.GetAllJobs()).ToList();
        }
    }
}
