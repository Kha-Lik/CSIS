using System.Collections.Generic;

namespace CSIS_DataAccess
{
    public interface ICosmeticRepository
    {
        IEnumerable<CosmeticEntity> GetAll();
        CosmeticEntity GetById(int id);
        void Create(CosmeticEntity entity);
        void Delete(CosmeticEntity entity);
        void Edit(CosmeticEntity entity);
    }
}