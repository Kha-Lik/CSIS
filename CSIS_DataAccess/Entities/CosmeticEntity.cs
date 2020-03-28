using CSIS_DataAccess.Entities;

namespace CSIS_DataAccess
{
    public class CosmeticEntity : BaseEntity
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Units { get; set; }

        public int DeliveryTime { get; set; }
    }
}