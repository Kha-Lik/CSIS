using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using BLL.Abstract;
using Models;

namespace ViewModels

{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IFacade _facade;

        private RelayCommand _addCosmeticCommand;
        private IEnumerable<CosmeticModel> _cosmetics;
        private RelayCommand _saveEditCommand;
        private CosmeticModel _selectedCosmetic;
        private RelayCommand _serializeCommand;
        private RelayCommand _deserializeCommand;
        private readonly string _path;


        public MainWindowViewModel(IFacade facade, IOpenFilteredCommand openFiltered)
        {
            _facade = facade;
            OpenFiltered = openFiltered;
            _cosmetics = _facade.CosmeticService.GetAll();
            _path = ConfigurationManager.AppSettings.Get("SerializationPath");
        }

        public ICollection<CosmeticModel> Cosmetics
        {
            get => _cosmetics as ICollection<CosmeticModel>;
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
                    Cosmetics = _facade.CosmeticService.GetAll() as ICollection<CosmeticModel>;
                    SelectedCosmetic = Cosmetics.Last();
                });
            }
        }

        public RelayCommand SerializeCommand => _serializeCommand ??= new RelayCommand(o =>
        {
            _facade.CosmeticService.Serialize(Cosmetics, _path);
        });

        public RelayCommand DeserializeCommand => _deserializeCommand ??= new RelayCommand(o =>
        {
            var cosmetics = _facade.CosmeticService.Deserialize(_path);
            Cosmetics = cosmetics;
        });

        public IOpenFilteredCommand OpenFiltered { get; }


        public RelayCommand SaveEditCommand =>
            _saveEditCommand ??= new RelayCommand(o =>
            {
                _facade.CosmeticService.Update(SelectedCosmetic);
                Cosmetics = _facade.CosmeticService.GetAll() as ICollection<CosmeticModel>;
            }, o => SelectedCosmetic != null);

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}