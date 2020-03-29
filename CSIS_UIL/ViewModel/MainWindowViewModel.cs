using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CSIS_BLL;
using CSIS_BLL.Interfaces;
using CSIS_BusinessLogic;
using CSIS_UI_WPF.Services;

namespace CSIS_UI_WPF.ViewModel

{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IFacade _facade;

        private RelayCommand _addCosmeticCommand;
        private RelayCommand _addCosmeticUsedSlowlyCommand;
        private OpenFilteredWindowCommand _openFiltered;
        private RelayCommand _saveCommand;
        private CosmeticModel _selectedCosmetic;

        public MainWindowViewModel(IFacade facade)
        {
            _facade = facade;
        }

        public ObservableCollection<CosmeticModel> Cosmetics
        {
            get
            {
                var cosmetics = _facade.GetAll().ToList();
                return new ObservableCollection<CosmeticModel>(cosmetics);
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
                    SelectedCosmetic = cosmetic;
                });
            }
        }

        public RelayCommand AddCosmeticUsedSlowlyCommand
        {
            get
            {
                return _addCosmeticUsedSlowlyCommand ??= new RelayCommand(obj =>
                {
                    var cosmetic = new CosmeticUsedSlowlyModel();
                    _facade.CosmeticUsedSlowlyService.Create(cosmetic);
                    SelectedCosmetic = cosmetic;
                });
            }
        }

        public OpenFilteredWindowCommand OpenFiltered => _openFiltered ??= new OpenFilteredWindowCommand(_facade);

        public RelayCommand SaveCommand => _saveCommand ??= new RelayCommand(obj => _facade.SaverService.Save());

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}