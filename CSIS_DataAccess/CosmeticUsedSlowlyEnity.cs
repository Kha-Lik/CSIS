namespace CSIS_DataAccess
{
    public class CosmeticUsedSlowlyEnity
    {
        public int Id { get; set; }
        
        public int ShelfLife { get; set; }

        public int UsingTime { get; set; }
        
        public bool IsEnding { get; set; }
    }
}