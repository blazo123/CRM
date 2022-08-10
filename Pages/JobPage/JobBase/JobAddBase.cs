using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.JobPage.JobBase
{
    public class JobAddBase : ComponentBase
    {
        [Inject]
        public IJobService JobService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Job Job { get; set; } = new Job()
        {
            DateOfNextActivity = DateTime.Today
        };
        

        public async Task AddJob()
        {
            await JobService.AddJob(Job);
            NavigationToMainPage();
        }

        public void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/jobs", true);
        }
    }
}
