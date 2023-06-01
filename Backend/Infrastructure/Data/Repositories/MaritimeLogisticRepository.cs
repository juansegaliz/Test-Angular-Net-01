using Infrastructure.Data.DbContexts;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class MaritimeLogisticRepository : IMaritimeLogisticRepository
    {
        private readonly LogisticsContext _context;

        public MaritimeLogisticRepository(LogisticsContext context) 
        {
            _context = context;        
        }

        public async Task<bool> Create(MaritimeLogistic maritimeLogistic) 
        {
            await _context.MaritimeLogistics.AddAsync(maritimeLogistic);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> Update(MaritimeLogistic maritimeLogistic)
        {
            _context.Entry(maritimeLogistic).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task Delete(int id)
        {
            var maritimeLogistic = await _context.MaritimeLogistics.FindAsync(id);
            if (maritimeLogistic == null) return;
            _context.Entry(maritimeLogistic).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<MaritimeLogistic>> GetAll()
        {
            return await _context.MaritimeLogistics.ToListAsync();
        }

        public async Task<MaritimeLogistic?> Get(int id)
        {
            return await _context.MaritimeLogistics.FindAsync(id);
        }
    }
}
