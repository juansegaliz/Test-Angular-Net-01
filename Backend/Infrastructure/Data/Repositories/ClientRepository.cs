using Infrastructure.Data.DbContexts;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LogisticsContext _context;

        public ClientRepository(LogisticsContext context) 
        {
            _context = context;        
        }

        public async Task<bool> Create(Client client) 
        {
            await _context.Clients.AddAsync(client);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return;
            _context.Entry(client).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> Get(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client?> GetByName(string name)
        {
            return await _context.Clients.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
