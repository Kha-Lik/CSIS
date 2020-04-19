namespace BLL
{
    public class CosmeticModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public int Price { get; set; }
        public int DeliveryTime { get; set; }
        public int ShelfLife { get; set; }
        public int UsingTime { get; set; }

        public bool IsEnding { get; set; }
    }
}