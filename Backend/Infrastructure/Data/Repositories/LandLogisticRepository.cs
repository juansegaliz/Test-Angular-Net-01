using Infrastructure.Data.DbContexts;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class LandLogisticRepository : ILandLogisticRepository
    {
        private readonly LogisticsContext _context;

        public LandLogisticRepository(LogisticsContext context) 
        {
            _context = context;        
        }

        public async Task<bool> Create(LandLogistic landLogistic) 
        {
            await _context.LandLogistics.AddAsync(landLogistic);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> Update(LandLogistic landLogistic)
        {
            _context.Entry(landLogistic).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task Delete(int id)
        {
            var landLogistic = await _context.LandLogistics.FindAsync(id);
            if (landLogistic == null) return;
            _context.Entry(landLogistic).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<LandLogistic>> GetAll()
        {
            return await _context.LandLogistics.ToListAsync();
        }

        public async Task<LandLogistic?> Get(int id)
        {
            return await _context.LandLogistics.FindAsync(id);
        }
    }
}
