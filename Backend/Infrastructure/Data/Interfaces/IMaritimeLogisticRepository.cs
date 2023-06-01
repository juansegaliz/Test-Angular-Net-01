
using Infrastructure.Data.Models;

namespace Infrastructure.Data.Interfaces
{
    public interface IMaritimeLogisticRepository
    {
        Task<bool> Create(MaritimeLogistic maritimeLogistic);
        Task Delete(int id);
        Task<MaritimeLogistic?> Get(int id);
        Task<List<MaritimeLogistic>> GetAll();
        Task<bool> Update(MaritimeLogistic maritimeLogistic);
    }
}
