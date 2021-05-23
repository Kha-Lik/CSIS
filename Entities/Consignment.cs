using System;

namespace Entities
{
    public class Consignment : BaseEntity
    {
        public int CosmeticId { get; set; }
        public int Units { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsEnding { get; set; }

        public Cosmetic Cosmetic { get; set; }
    }
}