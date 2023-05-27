
using Infrastructure.Data.Models;

namespace Infrastructure.Data.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<bool> Create(Warehouse warehouse);
        Task<Warehouse?> Get(int id);
        Task<IEnumerable<Warehouse>> GetAll();
        Task<bool> Update(Warehouse warehouse);
    }
}
