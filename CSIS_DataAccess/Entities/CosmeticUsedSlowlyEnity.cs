using CSIS_DataAccess.Entities;

namespace CSIS_DataAccess
{
    public class CosmeticUsedSlowlyEnity : BaseEntity
    {
        public int ShelfLife { get; set; }

        public int UsingTime { get; set; }

        public bool IsEnding { get; set; }
    }
}