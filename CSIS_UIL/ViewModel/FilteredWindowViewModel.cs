using System.Collections.ObjectModel;
using CSIS_BLL;
using CSIS_BLL.Interfaces;
using CSIS_BusinessLogic;

namespace CSIS_UI_WPF.ViewModel
{
    public class FilteredWindowViewModel
    {
        private readonly IFacade _facade;
        public FilteredWindowViewModel(IFacade facade)
        {
            _facade = facade;
        }

        public ObservableCollection<CosmeticModel> Filtered => 
            (ObservableCollection<CosmeticModel>)_facade.FilterService.GetFiltered();

        public void SetMaxAmountToOrder(int amount)
        {
             _facade.FilterService.SetMinLeftAmount(amount);
        }
    }
}