using System;

namespace Models
{
    public class ConsignmentCreateUpdateModel
    {
        public int Units { get; set; }
        public int CosmeticId { get; set; }
        public CosmeticCreateUpdateModel Cosmetic { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsEnding { get; set; }
    }
}