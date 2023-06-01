
using Infrastructure.Data.Models;

namespace Infrastructure.Data.Interfaces
{
    public interface ILandLogisticRepository
    {
        Task<bool> Create(LandLogistic landLogistic);
        Task Delete(int id);
        Task<LandLogistic?> Get(int id);
        Task<List<LandLogistic>> GetAll();
        Task<bool> Update(LandLogistic landLogistic);
    }
}
