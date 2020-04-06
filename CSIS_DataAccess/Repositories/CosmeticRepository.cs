using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
{
    public class CosmeticRepository : ICosmeticRepository
    {
        private readonly CsisDbContext _dbSet;

        public CosmeticRepository(CsisDbContext dbContext)
        {
            _dbSet = dbContext;
        }

        public IEnumerable<CosmeticEntity> GetAll()
        {
            return _dbSet.CosmeticEntities.AsNoTracking().ToList();
        }

        public void Create(CosmeticEntity entity)
        {
            _dbSet.CosmeticEntities.Add(entity);
        }

        public void Delete(CosmeticEntity entity)
        {
            _dbSet.CosmeticEntities.Remove(entity);
        }

        public void Edit(CosmeticEntity entity)
        {
            _dbSet.CosmeticEntities.Update(entity);
        }

        public void Detach()
        {
            foreach (var cosmetic in _dbSet.ChangeTracker.Entries().ToArray())
                if (cosmetic.Entity != null)
                    cosmetic.State = EntityState.Detached;
        }
    }
}