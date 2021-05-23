using System;

namespace Entities
{
    public class Purchase : BaseEntity
    {
        public int ClientId { get; set; }
        public int CosmeticId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Units { get; set; }

        public Client Client { get; set; }
        public Cosmetic Cosmetic { get; set; }
    }
}