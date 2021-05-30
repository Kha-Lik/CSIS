using System;

namespace Models
{
    public class ConsignmentGetModel : BaseGetModel
    {
        public int Units { get; set; }
        public int CosmeticId { get; set; }
        public CosmeticGetModel Cosmetic { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsEnding { get; set; }
    }
}