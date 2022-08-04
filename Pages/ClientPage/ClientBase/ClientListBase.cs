using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.Inherits
{
    public class ClientListBase : ComponentBase
    {
        [Inject]
        public IClientService ClientService { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AssignClient();
            //Clients = (await ClientService.GetClients()).ToList();
        }

        protected async Task Delete_ClickAsync(int id)
        {
           await ClientService.DeleteClient(id);
            await AssignClient();           
        }

        protected async Task AssignClient()
        {
           Clients = (await ClientService.GetClients()).ToList();
        }

    }
}
