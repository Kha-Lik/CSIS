using System.Collections.Generic;

namespace CSIS_DataAccess
{
    public interface ICosmeticRepository
    {
        IEnumerable<CosmeticEntity> GetAll();
        void Create(CosmeticEntity entity);
        void Delete(CosmeticEntity entity);
        void Edit(CosmeticEntity entity);
        void Detach();
    }
}