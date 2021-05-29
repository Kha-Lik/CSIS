using System;

namespace Models
{
    public class PurchaseCreateUpdateModel
    {
        public int ClientId { get; set; }
        public int CosmeticId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Units { get; set; }

        public ClientCreateUpdateModel Client { get; set; }
        public CosmeticCreateUpdateModel Cosmetic { get; set; }
    }
}