
using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.Inherits
{
    public class ClientDeleteBase : ComponentBase
    {
        [Parameter]
        public string nip { get; set; }

        [Inject]
        public IClientService ClientService { get; set; }
        public Client Client { get; set; } = new Client();
        [Inject]
        public NavigationManager NavigationManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Client = (await ClientService.GetClientById(nip));
        }


        public async void DeleteClient(int id)
        {
            ClientService.DeleteClient(id);

            NavigationManager.NavigateTo("/clients",true);
        }

        protected void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/clients");
        }
    }
}
