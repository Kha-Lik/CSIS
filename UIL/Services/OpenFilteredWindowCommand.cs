using System;
using System.Windows;
using BLL.Abstract;
using ViewModels;

namespace UIL.Services
{
    public class OpenFilteredWindowCommand : IOpenFilteredCommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App)?.DisplayRootRegistry;

            var filteredWindowViewModel = new FilteredWindowViewModel(Facade);
            displayRootRegistry?.ShowModalPresentation(filteredWindowViewModel);
        }

        public IFacade Facade { get; set; }
    }
}