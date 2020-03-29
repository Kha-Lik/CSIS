using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
{
    public class CosmeticUsedSlowlyRepository : ICosmeticUsedSlowlyRepository
    {
        private readonly DbSet<CosmeticUsedSlowlyEnity> _dbSet;

        public CosmeticUsedSlowlyRepository(CsisDbContext dbContext)
        {
            _dbSet = dbContext.Set<CosmeticUsedSlowlyEnity>();
        }
        
        public IEnumerable<CosmeticUsedSlowlyEnity> GetAll()
        {
            return _dbSet.ToList();
        }

        public CosmeticUsedSlowlyEnity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(CosmeticUsedSlowlyEnity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(CosmeticUsedSlowlyEnity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(CosmeticUsedSlowlyEnity entity)
        {
            _dbSet.Update(entity);
        }
    }
}