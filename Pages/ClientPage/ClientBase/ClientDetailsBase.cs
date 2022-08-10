using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;


namespace CRM.Pages.Inherits
{
    public class ClientDetailsBase : ComponentBase
    {
        [Parameter]
        public string nip { get; set; }

        [Inject]
        public IClientService ClientService { get; set; }
        public Client Client { get; set; } = new Client();

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Client = await ClientService.GetClientById(nip);
        }

        public async Task DeleteClient(int id)
        {
            await ClientService.DeleteClient(id);

            NavigationManager.NavigateTo("/clients", true);
        }
    }
}
