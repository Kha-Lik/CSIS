using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSIS_BLL;
using CSIS_BusinessLogic;
using CSIS_UI_WPF.Services;

namespace CSIS_UI_WPF.ViewModel

{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand _addCosmeticCommand;

        private RelayCommand _addCosmeticUsedSlowlyCommand;
        private readonly MainFacade _mainFacade = new MainFacade();
        
        private OpenFilteredWindowCommand _openFiltered;
        private Cosmetic _selectedCosmetic;


        public ObservableCollection<Cosmetic> Cosmetics => _mainFacade.Storage.GetCosmetics();
        public Storage Storage => _mainFacade.Storage;

        public Cosmetic SelectedCosmetic
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
                    var cosmetic = new Cosmetic();
                    _mainFacade.AddCosmetic(cosmetic);
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
                    var cosmetic = new CosmeticUsedSlowly();
                    _mainFacade.AddCosmetic(cosmetic);
                    SelectedCosmetic = cosmetic;
                });
            }
        }

        public OpenFilteredWindowCommand OpenFiltered => _openFiltered ??= new OpenFilteredWindowCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}