using System;
using System.Runtime.Serialization;
using CSIS_BLL;

namespace CSIS_BusinessLogic
{
    public class CosmeticUsedSlowlyModel : CosmeticModel
    {
        private bool _isEnding;
        private int _shelfLife; //Shelf life in days
        private int _usingTime; //Using time in days

        public int ShelfLife
        {
            get => _shelfLife;
            set
            {
                if (value > 0) _shelfLife = value;
                else
                    throw new ArgumentOutOfRangeException("Shelf life must be greater than zero");
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
                    throw new ArgumentOutOfRangeException("Using time have to be between zero and shelf life");
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
    }
}