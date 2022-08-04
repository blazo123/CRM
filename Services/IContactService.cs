using CRM.Model;

namespace CRM.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContactById(string id);
        Task<Contact> GetContactByName(string name);
        Task<bool> AddContact(Contact contact);
        Task<bool> DeleteContact(int contactId);
        Task<bool> UpdateContact(Contact contact);

    }
}
