using System.Collections.ObjectModel;
using CSIS_BLL;
using CSIS_BusinessLogic;

namespace CSIS_UI_WPF.ViewModel
{
    public class FilteredWindowViewModel
    {
        private readonly FilterFacade _filter;

        public FilteredWindowViewModel(Storage storage)
        {
            _filter = new FilterFacade(storage);
        }

        public ObservableCollection<Cosmetic> Filtered => _filter.Filtered;

        public void SetMaxAmountToOrder(int amount)
        {
            _filter.SetMaxAmountToOrder(amount);
        }
    }
}