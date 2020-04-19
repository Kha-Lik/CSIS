using System.Collections.Generic;
using Entities;

namespace DAL.Abstract
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