using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.JobPage.JobBase
{
    public class JobEditBase : ComponentBase
    {
        [Inject]
        IJobService JobService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string id { get; set; }
        [Parameter]
        public Job Job { get; set; } = new Job();

        protected override async Task OnInitializedAsync()
        {
            Job = await JobService.GetJobById(int.Parse(id));
        }

        protected async Task UpdateJob()
        {
            await JobService.UpdateJob(Job);
            NavigationToMainPage();
        }

        protected void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/jobs", true);
        }
    }
}
