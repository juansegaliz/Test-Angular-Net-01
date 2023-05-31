
using Infrastructure.Data.Models;

namespace Infrastructure.Data.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<bool> Create(ProductType warehouse);
        Task Delete(int id);
        Task<ProductType?> Get(int id);
        Task<List<ProductType>> GetAll();
        Task<ProductType?> GetByName(string name);
        Task<bool> Update(ProductType warehouse);
    }
}
