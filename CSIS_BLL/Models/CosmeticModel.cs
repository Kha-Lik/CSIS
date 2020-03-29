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

        [DataMember]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}