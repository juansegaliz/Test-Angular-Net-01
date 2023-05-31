using Infrastructure.Data.DbContexts;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly LogisticsContext _context;

        public ProductTypeRepository(LogisticsContext context) 
        {
            _context = context;        
        }

        public async Task<bool> Create(ProductType productType) 
        {
            await _context.ProductTypes.AddAsync(productType);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> Update(ProductType productType)
        {
            _context.Entry(productType).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task Delete(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null) return;
            _context.Entry(productType).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductType>> GetAll()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType?> Get(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }

        public async Task<ProductType?> GetByName(string name)
        {
            return await _context.ProductTypes.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
