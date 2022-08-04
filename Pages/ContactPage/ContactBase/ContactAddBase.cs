using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.ContactPage.ContactBase
{
    public class ContactAddBase : ComponentBase 
    {
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Contact Contact { get; set; } = new Contact();

        public async Task AddContact()
        {
            await ContactService.AddContact(Contact);
            NavigationToMainPage();
        }

        public void NavigationToMainPage()
        {
            NavigationManager.NavigateTo("/contacts", true);
        }
    }
}
