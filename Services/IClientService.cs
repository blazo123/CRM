using CRM.Model;

namespace CRM.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(string nip);

        Task<bool> AddClient(Client client);
        Task<bool> UpdateClient(string nip,Client client);

        Task<bool> DeleteClient(int id);
    }
}
