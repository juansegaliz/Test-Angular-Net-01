
using Infrastructure.Data.Models;

namespace Infrastructure.Data.Interfaces
{
    public interface IPortRepository
    {
        Task<bool> Create(Port port);
        Task Delete(int id);
        Task<Port?> Get(int id);
        Task<List<Port>> GetAll();
        Task<Port?> GetByName(string name);
        Task<bool> Update(Port port);
    }
}
