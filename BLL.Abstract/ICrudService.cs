using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace BLL.Abstract
{
    public interface ICrudService<TGetModel, in TCreateUpdateModel> where TGetModel : BaseGetModel
    {
        public Task<IEnumerable<TGetModel>> GetAllAsync();

        public Task<TGetModel> GetByIdAsync(int id);
        
        public Task CreateAsync(TCreateUpdateModel model);

        public Task UpdateAsync(TCreateUpdateModel model, int id);

        public Task DeleteByIdAsync(int id);
    }
}