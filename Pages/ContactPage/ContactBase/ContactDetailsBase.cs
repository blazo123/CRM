using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.ContactPage.ContactBase
{
    public class ContactDetailsBase : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        [Parameter]
        public Contact Contact{ get; set; } = new Contact();
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contact = await ContactService.GetContactById(id);
        }

        protected async void Delete_Click(int id)
        {

            await ContactService.DeleteContact(id);
            NavigationManager.NavigateTo("/contacts", true);
        }


    }
}
