using System.Collections.Generic;

namespace CSIS_DataAccess
{
    public interface ICosmeticUsedSlowlyRepository
    {
        IEnumerable<CosmeticUsedSlowlyEnity> GetAll();
        CosmeticUsedSlowlyEnity GetById(int id);
        void Create(CosmeticUsedSlowlyEnity entity);
        void Delete(CosmeticUsedSlowlyEnity entity);
        void Edit(CosmeticUsedSlowlyEnity entity);
    }
}