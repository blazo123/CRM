using CRM.Model;

namespace CRM.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(string nip);

        void AddClient(Client client);
        void UpdateClient(string nip,Client client);

        Task<bool> DeleteClient(int id);
    }
}
