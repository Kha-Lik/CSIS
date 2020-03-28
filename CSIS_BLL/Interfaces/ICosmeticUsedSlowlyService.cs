using System.Collections.Generic;
using CSIS_BusinessLogic;
using CSIS_DataAccess;

namespace CSIS_BLL.Interfaces
{
    public interface ICosmeticUsedSlowlyService
    {
        public IEnumerable<CosmeticUsedSlowlyModel> GetAll();
        public void Create(CosmeticUsedSlowlyModel cosmetic);
    }
}