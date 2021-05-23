using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace BLL.Abstract
{
    public interface IFilterService
    {
        public Task<IEnumerable<CosmeticModel>> GetFiltered();
        public void SetMinLeftAmount(int amount);
    }
}