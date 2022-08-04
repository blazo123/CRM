using CRM.Data;
using CRM.Model;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services
{
    public class ContactService : IContactService
    {
        private AppDbContext _context;

        public ContactService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<bool> AddContact(Contact contact)
        {
            contact.CreatedDate = DateTime.Now;
            if (contact != null)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            var contact = _context.Contacts.Where(x => x.Id == contactId).FirstOrDefault();
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Contact> GetContactById(string id)
        {
            var concact = await _context.Contacts.Where(x => x.Id == int.Parse(id)).FirstOrDefaultAsync();
            return concact;
        }

        public async Task<Contact> GetContactByName(string name)
        {
            var result = await _context.Contacts.Where(x => x.Name == name).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var contacts = await _context.Contacts
                                          .Include(x => x.Client)                
                                          .ToListAsync();
            return contacts;
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            var contactFromDB = _context.Contacts.Where(x => x.Id == contact.Id).FirstOrDefault();
            if (contactFromDB != null)
            {
                contactFromDB.Email = contact.Email;
                contactFromDB.PhoneNumber = contact.PhoneNumber;
                contactFromDB.Name = contact.Name;
                contactFromDB.ClientId = contact.ClientId;
                contactFromDB.UpdateDate = DateTime.Now;
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
