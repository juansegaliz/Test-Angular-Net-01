using Infrastructure.Data.DbContexts;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly LogisticsContext _context;

        public WarehouseRepository(LogisticsContext context) 
        {
            _context = context;        
        }

        public async Task<bool> Create(Warehouse warehouse) 
        {
            await _context.Warehouses.AddAsync(warehouse);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> Update(Warehouse warehouse)
        {
            _context.Entry(warehouse).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task Delete(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null) return;
            _context.Entry(warehouse).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Warehouse>> GetAll()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse?> Get(int id)
        {
            return await _context.Warehouses.FindAsync(id);
        }

        public async Task<Warehouse?> GetByName(string name)
        {
            return await _context.Warehouses.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
