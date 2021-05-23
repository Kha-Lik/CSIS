using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Impl.Repositories
{
    public class ConsignmentRepository : IRepository<Consignment>
    {
        private readonly CsisDbContext _context;

        public ConsignmentRepository(CsisDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consignment>> GetAllAsync()
        {
            return await _context.Consignments
                .Include(c => c.Cosmetic)
                .ToListAsync();
        }

        public async Task<Consignment> GetByIdAsync(int id)
        {
            return await _context.Consignments
                .Include(c => c.Cosmetic)
                .FirstAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Consignment entity)
        {
            await _context.Consignments.AddAsync(entity);
        }

        public void Delete(Consignment entity)
        {
            _context.Consignments.Remove(entity);
        }

        public void Edit(Consignment entity)
        {
            _context.Consignments.Update(entity);
        }
    }
}