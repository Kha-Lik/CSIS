using System.Collections.Generic;
using System.Linq;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Impl
{
    public class CosmeticRepository : ICosmeticRepository
    {
        private readonly CsisDbContext _dbContext;

        public CosmeticRepository(CsisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CosmeticEntity> GetAll()
        {
            return _dbContext.CosmeticEntities.AsNoTracking().ToList();
        }

        public void Create(CosmeticEntity entity)
        {
            _dbContext.CosmeticEntities.Add(entity);
        }

        public void Delete(CosmeticEntity entity)
        {
            _dbContext.CosmeticEntities.Remove(entity);
        }

        public void Edit(CosmeticEntity entity)
        {
            _dbContext.CosmeticEntities.Update(entity);
        }

        public void Detach()
        {
            foreach (var cosmetic in _dbContext.ChangeTracker.Entries().ToArray())
                if (cosmetic.Entity != null)
                    cosmetic.State = EntityState.Detached;
        }
    }
}