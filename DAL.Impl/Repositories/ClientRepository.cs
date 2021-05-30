using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Impl.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly CsisDbContext _context;

        public ClientRepository(CsisDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.Include(c => c.Purchases).AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.Include(c => c.Purchases).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
        }

        public void Delete(Client entity)
        {
            _context.Clients.Remove(entity);
        }

        public void Edit(Client entity)
        {
            _context.Clients.Update(entity);
        }
    }
}