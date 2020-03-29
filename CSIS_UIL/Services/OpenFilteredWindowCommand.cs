using System;
using System.Windows;
using System.Windows.Input;
using CSIS_BLL.Interfaces;
using CSIS_UI_WPF.ViewModel;

namespace CSIS_UI_WPF.Services
{
    public class OpenFilteredWindowCommand : ICommand
    {
        private readonly IFacade _facade;

        public OpenFilteredWindowCommand(IFacade facade)
        {
            _facade = facade;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App)?.DisplayRootRegistry;

            var filteredWindowViewModel = new FilteredWindowViewModel(_facade);
            displayRootRegistry?.ShowModalPresentation(filteredWindowViewModel);
        }
    }
}