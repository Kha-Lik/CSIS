using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Impl.Repositories
{
    public class PurchaseRepository : IRepository<Purchase>
    {
        private readonly CsisDbContext _context;

        public PurchaseRepository(CsisDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await _context.Purchases
                .Include(p => p.Client)
                .Include(p => p.Cosmetic)
                .ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return await _context.Purchases
                .Include(p => p.Client)
                .Include(p => p.Cosmetic)
                .FirstAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Purchase entity)
        {
            await _context.Purchases.AddAsync(entity);
        }

        public void Delete(Purchase entity)
        {
            _context.Purchases.Remove(entity);
        }

        public void Edit(Purchase entity)
        {
            _context.Purchases.Update(entity);
        }
    }
}