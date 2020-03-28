using System.Collections.Generic;
using CSIS_DataAccess.Entities;

namespace CSIS_DataAccess
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity entity);
        void Delete(TEntity entity);

        void Edit(TEntity entity);
    }
}