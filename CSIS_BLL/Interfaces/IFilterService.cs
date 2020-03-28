using System.Collections;
using System.Collections.Generic;

namespace CSIS_BLL.Interfaces
{
    public interface IFilterService
    {
        public IEnumerable<CosmeticModel> GetFiltered();
    }
}