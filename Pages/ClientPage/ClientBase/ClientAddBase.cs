using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace CRM.Pages.Inherits
{

    public class ClientAddBase : ComponentBase
    {
        [Inject]
        public IClientService ClientService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Client Client { get; set; } = new Client();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
            
        }
        public async Task AddClient()
        {
            Client.CreatedDate = DateTime.Now;
            await ClientService.AddClient(Client);

            NavigationToMainPage();
        }
        protected void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/clients",true);
        }
    }
}
