using System.Collections.Generic;

namespace DAL
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