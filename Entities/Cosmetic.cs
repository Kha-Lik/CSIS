using System.Collections.Generic;

namespace Entities
{
    public class Cosmetic : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DeliveryTime { get; set; }
        public int ShelfLife { get; set; }
    }
}