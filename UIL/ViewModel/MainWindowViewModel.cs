using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BLL;
using BLL.Interfaces;
using CSIS_UI_WPF.Services;

namespace CSIS_UI_WPF.ViewModel

{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IFacade _facade;
        private IEnumerable<CosmeticModel> _cosmetics;
        private CosmeticModel _selectedCosmetic;
        
        private RelayCommand _addCosmeticCommand;
        private RelayCommand _saveEditCommand;
        private OpenFilteredWindowCommand _openFiltered;


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
                    SelectedCosmetic = Cosmetics.Last();
                });
            }
        }

        public OpenFilteredWindowCommand OpenFiltered => _openFiltered ??= new OpenFilteredWindowCommand(_facade);


        public RelayCommand SaveEditCommand =>
            _saveEditCommand ??= new RelayCommand(o =>
            {
                _facade.CosmeticService.Update(SelectedCosmetic);
                Cosmetics = _facade.CosmeticService.GetAll();
            }, o => SelectedCosmetic != null);

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}