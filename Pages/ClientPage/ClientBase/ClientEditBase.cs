using CRM.Model;

using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.Inherits
{
    public class ClientEditBase : ComponentBase
    {
        [Parameter]
        public string nip { get; set; }

        [Inject]
        public IClientService ClientService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Client Client { get; set; } = new Client();

        protected override async Task OnInitializedAsync()
        {
            Client = await ClientService.GetClientById(nip);
        }

        protected async void UpdateClient()
        {
            if (Client.NIP != null)
            {
                ClientService.UpdateClient(Client.NIP,Client);
                NavigationManager.NavigateTo("/clients",true);
            }
        }

        protected void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/clients");
        }

    }
}
