using System.Collections.Generic;
using Models;

namespace BLL.Abstract
{
    public interface IFilterService
    {
        public IEnumerable<CosmeticModel> GetFiltered();
        public void SetMinLeftAmount(int amount);
    }
}