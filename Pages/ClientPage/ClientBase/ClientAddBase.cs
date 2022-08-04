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
        public void AddClient()
        {
            Client.CreatedDate = DateTime.Now;
            ClientService.AddClient(Client);

            NavigationManager.NavigateTo("/clients", true);
        }
        protected void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/clients");
        }
    }
}
