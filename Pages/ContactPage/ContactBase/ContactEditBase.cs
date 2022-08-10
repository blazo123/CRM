using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.ContactPage.ContactBase
{
    public class ContactEditBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string id { get; set; }
        public Contact Contact { get; set; } = new Contact();

        protected override async Task OnInitializedAsync()
        {
            Contact = await ContactService.GetContactById(id);
        }

        public async void UpdateContact()
        {
            await ContactService.UpdateContact(Contact);

            NavigationToMainPage();
        }

        public void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/contacts", true);
        }
    }
}
