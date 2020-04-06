using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSIS_BLL;
using CSIS_BLL.Interfaces;
using CSIS_UI_WPF.Services;

namespace CSIS_UI_WPF.ViewModel

{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IFacade _facade;

        private RelayCommand _addCosmeticCommand;
        //private RelayCommand _addCosmeticUsedSlowlyCommand;
        private OpenFilteredWindowCommand _openFiltered;
        private RelayCommand _saveCommand;
        private RelayCommand _saveEditCommand;
        private CosmeticModel _selectedCosmetic;
        private IEnumerable<CosmeticModel> _cosmetics;

        public MainWindowViewModel(IFacade facade)
        {
            _facade = facade;
            _cosmetics = _facade.CosmeticService.GetAll();
        }

        public IEnumerable<CosmeticModel> Cosmetics
        {
            get => _cosmetics;
            set
            {
                _cosmetics = value;
                OnPropertyChanged();
            }
        }

        public CosmeticModel SelectedCosmetic
        {
            get => _selectedCosmetic;
            set
            {
                _selectedCosmetic = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCosmeticCommand
        {
            get
            {
                return _addCosmeticCommand ??= new RelayCommand(obj =>
                {
                    var cosmetic = new CosmeticModel();
                    _facade.CosmeticService.Create(cosmetic);
                    Cosmetics = _facade.CosmeticService.GetAll();
                    SelectedCosmetic = cosmetic;
                });
            }
        }

        /*public RelayCommand AddCosmeticUsedSlowlyCommand
        {
            get
            {
                return _addCosmeticUsedSlowlyCommand ??= new RelayCommand(obj =>
                {
                    var cosmetic = new CosmeticUsedSlowlyModel();
                    _facade.CosmeticUsedSlowlyService.Create(cosmetic);
                    Cosmetics = _facade.GetAll();
                    SelectedCosmetic = cosmetic;
                });
            }
        }*/

        public OpenFilteredWindowCommand OpenFiltered => _openFiltered ??= new OpenFilteredWindowCommand(_facade);

        public RelayCommand SaveCommand => _saveCommand ??= new RelayCommand(obj => _facade.SaverService.Save());

        public RelayCommand SaveEditCommand
        {
            get => _saveEditCommand ??= new RelayCommand( o =>
            {
                _facade.CosmeticService.Update(SelectedCosmetic);
                Cosmetics = _facade.CosmeticService.GetAll();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}