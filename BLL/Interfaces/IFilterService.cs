using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IFilterService
    {
        public IEnumerable<CosmeticModel> GetFiltered();
        public void SetMinLeftAmount(int amount);
    }
}