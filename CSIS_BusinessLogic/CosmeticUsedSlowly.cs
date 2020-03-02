using System;
using System.Runtime.Serialization;

namespace CSIS_BusinessLogic
{
    [DataContract]
    public class CosmeticUsedSlowly : Cosmetic
    {
        private int _shelfLife; //Shelf life in days
        private int _usingTime; //Using time in days
        private bool _isEnding;

        [DataMember]
        public int ShelfLife
        {
            get => _shelfLife;
            set
            {
                if (value > 0) _shelfLife = value;
                else
                {
                    throw new ArgumentOutOfRangeException("Shelf life must be greater than zero");
                }
                OnPropertyChanged("ShelfLife");
            }
        }

        [DataMember]
        public int UsingTime
        {
            get => _usingTime;
            set
            {
                if (value >= 0 && value <= _shelfLife) _usingTime = value;
                else
                {
                    throw new ArgumentOutOfRangeException("Using time have to be between zero and shelf life");
                }
                OnPropertyChanged("UsingTime");
            }
        }

        [DataMember]
        public bool IsEnding
        {
            get => _isEnding;
            set
            {
                _isEnding = value;
                OnPropertyChanged("IsEnding");
            }
        }

        public CosmeticUsedSlowly(string name, int units, int price, int delivTime, int shelfLife, int usingTime, bool isEnding = false) : base(name, units, price, delivTime)
        {
            ShelfLife = shelfLife;
            UsingTime = usingTime;
            IsEnding = isEnding;
        }

        public object Clone()
        {
            return new CosmeticUsedSlowly(Name, Units, Price, DeliveryTime, ShelfLife, UsingTime, IsEnding);
        }
    }
}