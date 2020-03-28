using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using CSIS_BusinessLogic;

namespace CSIS_BLL
{
    [DataContract]
    [KnownType(typeof(CosmeticUsedSlowly))]
    public class Cosmetic : ICloneable, INotifyPropertyChanged
    {
        private string _name;
        private int _units; 
        private int _price;
        private int _delivTime; //Delivery time in days

        [DataMember]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
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
                    throw new ArgumentOutOfRangeException("Amount of cosmetics must be greater than zero");
                }
                OnPropertyChanged("Units");
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
                    throw new ArgumentOutOfRangeException("Price must be greater than zero");
                }
                OnPropertyChanged("Price");
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
                    throw new ArgumentOutOfRangeException("Delivery time must be greater than zero");
                }
                OnPropertyChanged("DeliveryTime");
            }
        }

        public Cosmetic(string name, int units, int price, int delivTime)
        {
            Name = name;
            Units = units;
            Price = price;
            DeliveryTime = delivTime;
        }

        public Cosmetic() {}

        public object Clone()
        {
            return new Cosmetic(Name, Units, Price, DeliveryTime);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop="") 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}