using System.Collections.ObjectModel;

namespace CSIS_BusinessLogic
{
    public class FilterFacade
    {
        private Storage _storage;
        private Filter _filter;
        private ObservableCollection<Cosmetic> _filtered;
        public ObservableCollection<Cosmetic> Filtered => _filter.Filtered;

        public FilterFacade(Storage storage)
        {
            _storage = storage;
            _filter = new Filter(_storage);
        }

        public void SetMaxAmountToOrder(int amount) => _filter.SetAmountWhenOrder(amount);
    }
}