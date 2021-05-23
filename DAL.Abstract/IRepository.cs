using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DAL.Abstract
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
    }
}