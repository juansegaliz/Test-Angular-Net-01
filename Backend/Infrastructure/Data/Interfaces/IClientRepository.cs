
using Infrastructure.Data.Models;

namespace Infrastructure.Data.Interfaces
{
    public interface IClientRepository
    {
        Task<bool> Create(Client client);
        Task Delete(int id);
        Task<Client?> Get(int id);
        Task<List<Client>> GetAll();
        Task<Client?> GetByName(string name);
        Task<bool> Update(Client client);
    }
}
