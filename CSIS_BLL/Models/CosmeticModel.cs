namespace CSIS_BLL
{
    public class CosmeticModel
    {
        private int _delivTime; //Delivery time in days
        private string _name;
        private int _price;
        private int _units;
        private bool _isEnding;
        private int _shelfLife; //Shelf life in days
        private int _usingTime; //Using time in days

        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public int Price { get; set; }
        public int DeliveryTime { get; set; }
        public int ShelfLife { get; set; }
        public int UsingTime { get; set; }
        public bool IsEnding { get; set; }
        // public event PropertyChangedEventHandler PropertyChanged;
        //
        // public void OnPropertyChanged([CallerMemberName] string prop = "")
        // {
        //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        // }
    }
}