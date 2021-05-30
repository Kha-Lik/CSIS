using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Impl.Repositories
{
    public class CosmeticRepository : IRepository<Cosmetic>
    {
        private readonly CsisDbContext _dbContext;

        public CosmeticRepository(CsisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cosmetic>> GetAllAsync()
        {
            return await _dbContext.Cosmetics.AsNoTracking().ToListAsync();
        }
        
        public async Task<Cosmetic> GetByIdAsync(int id)
        {
            return await _dbContext.Cosmetics.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Cosmetic entity)
        {
            await _dbContext.Cosmetics.AddAsync(entity);
        }

        public void Delete(Cosmetic entity)
        {
            _dbContext.Cosmetics.Remove(entity);
        }

        public void Edit(Cosmetic entity)
        {
            _dbContext.Cosmetics.Update(entity);
        }
    }
}