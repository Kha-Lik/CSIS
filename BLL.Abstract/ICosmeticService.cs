using System.Collections.Generic;
using Models;

namespace BLL.Abstract
{
    public interface ICosmeticService
    {
        public IEnumerable<CosmeticModel> GetAll();
        
        public void Create(CosmeticModel cosmetic);

        public void Update(CosmeticModel cosmeticModel);

        public void Serialize(ICollection<CosmeticModel> cosmeticModels, string path);

        public ICollection<CosmeticModel> Deserialize(string path);
    }
}