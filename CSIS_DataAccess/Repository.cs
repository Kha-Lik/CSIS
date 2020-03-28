using System.Collections.Generic;
using System.Linq;
using CSIS_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}