using System;
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
    }
}