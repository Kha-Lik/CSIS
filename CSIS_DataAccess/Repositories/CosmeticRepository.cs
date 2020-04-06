using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
{
    public class CosmeticRepository : ICosmeticRepository
    {
        private readonly DbSet<CosmeticEntity> _dbSet;

        public CosmeticRepository(CsisDbContext dbContext)
        {
            _dbSet = dbContext.Set<CosmeticEntity>();
        }
        
        public IEnumerable<CosmeticEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public CosmeticEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(CosmeticEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(CosmeticEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(CosmeticEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}