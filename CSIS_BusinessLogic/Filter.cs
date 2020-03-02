using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace CSIS_BusinessLogic
{
    internal class Filter
    {
        private int _maxAmountToOrder;
        private Storage _storage;
        private ObservableCollection<Cosmetic> _filtered;
        public ObservableCollection<Cosmetic> Filtered => _filtered;

        public Filter(Storage storage)
        {
            _maxAmountToOrder = 3;
            _storage = storage;
            GetCosmeticsToOrder();
        }
        public void SetAmountWhenOrder(int amount)
        {
            _maxAmountToOrder = amount;
            GetCosmeticsToOrder();
        }

        private void GetCosmeticsToOrder()
        {
            ObservableCollection<Cosmetic> filtered = new ObservableCollection<Cosmetic>();
            
            foreach (var cosmetic in _storage)
            {
                if (cosmetic is CosmeticUsedSlowly)
                {
                    if((cosmetic as CosmeticUsedSlowly).ShelfLife - (cosmetic as CosmeticUsedSlowly).UsingTime <= 
                        (cosmetic as CosmeticUsedSlowly).DeliveryTime || 
                        (cosmetic as CosmeticUsedSlowly).IsEnding) 
                        filtered.Add(cosmetic);
                }
                else
                {
                    if (cosmetic.Units <= _maxAmountToOrder) filtered.Add(cosmetic);
                }
            }

            _filtered = filtered;
        }
    }
}