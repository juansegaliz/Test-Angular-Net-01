
using Infrastructure.Data.Models;

namespace Infrastructure.Data.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<bool> Create(Warehouse warehouse);
        Task Delete(int id);
        Task<Warehouse?> Get(int id);
        Task<List<Warehouse>> GetAll();
        Task<Warehouse?> GetByName(string name);
        Task<bool> Update(Warehouse warehouse);
    }
}
