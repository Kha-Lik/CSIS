﻿using System;
using System.Windows;
using System.Windows.Input;
using CSIS_UI_WPF.ViewModel;

namespace CSIS_UI_WPF.Services
{
    public class OpenFilteredWindowCommand : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;

        public OpenFilteredWindowCommand(MainWindowViewModel mainWindowVeiwModel)
        {
            _mainWindowViewModel = mainWindowVeiwModel;
        }
        
        public event EventHandler CanExecuteChanged;
        
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App).displayRootRegistry;

            var filteredWindowViewModel = new FilteredWindowViewModel(_mainWindowViewModel.Cosmetics);
            await displayRootRegistry.ShowModalPresentation(filteredWindowViewModel);
        }
    }
}