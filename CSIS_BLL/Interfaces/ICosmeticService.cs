using System.Collections;
using System.Collections.Generic;

namespace CSIS_BLL.Interfaces
{
    public interface ICosmeticService
    {
        public IEnumerable<CosmeticModel> GetAll();
        public void Create(CosmeticModel cosmetic);
    }
}