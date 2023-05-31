using Infrastructure.Data.DbContexts;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PortRepository : IPortRepository
    {
        private readonly LogisticsContext _context;

        public PortRepository(LogisticsContext context) 
        {
            _context = context;        
        }

        public async Task<bool> Create(Port port) 
        {
            await _context.Ports.AddAsync(port);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> Update(Port port)
        {
            _context.Entry(port).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task Delete(int id)
        {
            var port = await _context.Ports.FindAsync(id);
            if (port == null) return;
            _context.Entry(port).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Port>> GetAll()
        {
            return await _context.Ports.ToListAsync();
        }

        public async Task<Port?> Get(int id)
        {
            return await _context.Ports.FindAsync(id);
        }

        public async Task<Port?> GetByName(string name)
        {
            return await _context.Ports.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
