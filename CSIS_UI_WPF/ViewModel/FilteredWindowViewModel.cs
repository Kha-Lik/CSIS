﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using CSIS_BusinessLogic;
using CSIS_UI_WPF.Services;

namespace CSIS_UI_WPF.ViewModel
{
    public class FilteredWindowViewModel
    {
        private FilterFacade _filter;

        public ObservableCollection<Cosmetic> Filtered => _filter.Filtered;

        private RelayCommand _setMaxAmountToOrderCommand;

        public RelayCommand SetMaxAmountToOrderCommand =>
            _setMaxAmountToOrderCommand ??= new RelayCommand(obj => SetMaxAmountToOrder(int.Parse(obj.ToString())));

        public FilteredWindowViewModel(Storage storage) => _filter = new FilterFacade(storage);

        public void SetMaxAmountToOrder(int amount) => _filter.SetMaxAmountToOrder(amount);
    }
}