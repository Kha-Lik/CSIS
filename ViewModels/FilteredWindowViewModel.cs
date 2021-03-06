﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL.Abstract;
using Models;

namespace ViewModels
{
    public sealed class FilteredWindowViewModel : INotifyPropertyChanged
    {
        private readonly IFacade _facade;

        private int _amount;
        private RelayCommand _changeAmountCommand;
        private IEnumerable<CosmeticModel> _filtered;

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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}