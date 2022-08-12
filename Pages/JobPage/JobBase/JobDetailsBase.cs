using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.JobPage.JobBase
{
    public class JobDetailsBase : ComponentBase
    {
        [Inject]
        public IJobService JobService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public Job Job { get; set; } = new Job();

        protected override async Task OnInitializedAsync()
        {
            Job = await JobService.GetJobById(int.Parse(Id))
;       }

        public async Task Delete_Click(int id)
        {
            await JobService.DeleteJob(id);
        }
    }
}
