using System;

namespace Models
{
    public class ConsignmentModel : BaseModel
    {
        public int Units { get; set; }
        public int CosmeticId { get; set; }
        public CosmeticModel Cosmetic { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsEnding { get; set; }
    }
}