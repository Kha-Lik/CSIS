using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace BLL.Abstract
{
    public interface ICrudService<TModel> where TModel : BaseModel
    {
        public Task<IEnumerable<TModel>> GetAllAsync();

        public Task<TModel> GetByIdAsync(int id);
        
        public Task CreateAsync(TModel model);

        public Task UpdateAsync(TModel model);

        public Task DeleteByIdAsync(int id);
    }
}