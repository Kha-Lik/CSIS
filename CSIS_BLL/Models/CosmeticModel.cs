using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CSIS_BLL
{
    public class CosmeticModel : INotifyPropertyChanged
    {
        private int _delivTime; //Delivery time in days
        private string _name;
        private int _price;
        private int _units;
        private bool _isEnding;
        private int _shelfLife; //Shelf life in days
        private int _usingTime; //Using time in days
        
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        
        public int Units
        {
            get => _units;
            set
            {
                if (value > 0) _units = value;
                else
                {
                    var msg = "Amount of cosmetics must be greater than zero";
                    throw new ArgumentOutOfRangeException(msg);
                }
                OnPropertyChanged();
            }
        }
        
        public int Price
        {
            get => _price;
            set
            {
                if (value > 0) _price = value;
                else
                {
                    var msg = "Price must be greater than zero";
                    throw new ArgumentOutOfRangeException(msg);
                }

                OnPropertyChanged();
            }
        }
        
        public int DeliveryTime
        {
            get => _delivTime;
            set
            {
                if (value > 0) _delivTime = value;
                else
                {
                    var msg = "Delivery time must be greater than zero";
                    throw new ArgumentOutOfRangeException(msg);
                }

                OnPropertyChanged();
            }
        }

        public int ShelfLife
        {
            get => _shelfLife;
            set
            {
                if (value > 0) _shelfLife = value;
                else
                {
                    var msg = "Shelf life must be greater than zero";
                    throw new ArgumentOutOfRangeException(msg);
                }

                OnPropertyChanged();
            }
        }


        public int UsingTime
        {
            get => _usingTime;
            set
            {
                if (value >= 0 && value <= _shelfLife) _usingTime = value;
                else
                {
                    var msg = "Using time have to be between zero and shelf life";
                    throw new ArgumentOutOfRangeException(msg);
                }

                OnPropertyChanged();
            }
        }


        public bool IsEnding
        {
            get => _isEnding;
            set
            {
                _isEnding = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}