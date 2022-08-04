using CRM.Helpers;
using CRM.Model;
using CRM.Services;
using Microsoft.AspNetCore.Components;

namespace CRM.Pages.ContactPage.ContactBase
{
    public class ContactListBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }
        public IEnumerable<Contact> Contacts {get; set;}
        public ConfirmBase DeleteConfirmation { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await AssignClient();
        }

        protected async void Delete_Click(int id)
        {
            //intToDelete = id;
            //DeleteConfirmation.Show();

            await ContactService.DeleteContact(id);
            await AssignClient();
        }

        protected async Task AssignClient()
        {
            Contacts = (await ContactService.GetContacts()).ToList();
        }
    }
}
