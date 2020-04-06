using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSIS_BLL;
using CSIS_BLL.Interfaces;
using CSIS_UI_WPF.Services;

namespace CSIS_UI_WPF.ViewModel
{
    public class FilteredWindowViewModel : INotifyPropertyChanged
    {
        private readonly IFacade _facade;
        private RelayCommand _changeAmountCommand;
        private IEnumerable<CosmeticModel> _filtered;

        private int _amount;

        public FilteredWindowViewModel(IFacade facade)
        {
            _facade = facade;
            _filtered = _facade.FilterService.GetFiltered();
        }

        public RelayCommand ChangeAmountCommand => 
            _changeAmountCommand ??= new RelayCommand(o =>
        {
            _facade.FilterService.SetMinLeftAmount(Amount);
            Filtered = _facade.FilterService.GetFiltered();
        });

        public IEnumerable<CosmeticModel> Filtered
        {
            get => _filtered;
            set
            {
                _filtered = value;
                OnPropertyChanged();
            }
        }

        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}