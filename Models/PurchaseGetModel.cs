using System;

namespace Models
{
    public class PurchaseGetModel : BaseGetModel
    {
        public int ClientId { get; set; }
        public int CosmeticId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Units { get; set; }

        public ClientGetModel Client { get; set; }
        public CosmeticGetModel Cosmetic { get; set; }
    }
}