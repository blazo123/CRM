
using CRM.Data;
using CRM.Model;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services
{
    public class ClientService : IClientService
    {

        private readonly AppDbContext _context;

        //var baseAdress = "https://localhost:7254";
        public ClientService( AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientById(string nip)
        {
            //return await _httpClient.GetFromJsonAsync<Client>($"api/client/{nip}");

            return await _context.Clients.FirstOrDefaultAsync(x => x.NIP == nip);
        }

        public async Task<IEnumerable<Client>> GetClients()
        {

            //return await _httpClient.GetFromJsonAsync<Client[]>("api/client");
            var clients = await _context.Clients.ToListAsync();
            return clients;
        }

        public async void AddClient(Client client)
        {
                _context.Add(client);
               await _context.SaveChangesAsync();
        }

        public async void UpdateClient(string nip,Client client)
        {
            //await _httpClient.PutAsJsonAsync($"api/client/{client.NIP}",client);
            var result = await _context.Clients.FirstOrDefaultAsync(x => x.NIP == nip);

            result.NIP = client.NIP;
            result.REGON = client.REGON;
            result.Name = client.Name;
            result.StreetName = client.StreetName;
            result.PostCode = client.PostCode;
            result.ApartmentNumber = client.ApartmentNumber;
            result.City = client.City;
            result.Country = client.Country;
            result.StreetName = client?.StreetName;
            result.StreetNumber = client?.StreetNumber;
            result.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();                      
        }

        public async Task<bool> DeleteClient(int id)
        {

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
