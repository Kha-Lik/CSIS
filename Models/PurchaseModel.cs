using System;

namespace Models
{
    public class PurchaseModel : BaseModel
    {
        public int ClientId { get; set; }
        public int CosmeticId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Units { get; set; }

        public ClientModel Client { get; set; }
        public CosmeticModel Cosmetic { get; set; }
    }
}