﻿using System.Collections.ObjectModel;
using CSIS_DataAccess;
using CSIS_BusinessLogic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSIS_UI_WPF.Services;

namespace CSIS_UI_WPF.ViewModel

{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainFacade _mainFacade = new MainFacade(new XmlDeserializer<Storage>());
        private Cosmetic _selectedCosmetic;
        
        private FilterFacade _filter;

        public ObservableCollection<Cosmetic> Filtered => _filter.Filtered;

        public Storage Cosmetics => _mainFacade.Storage;
        public Cosmetic SelectedCosmetic
        {
            get => _selectedCosmetic;
            set
            {
                _selectedCosmetic = value;
                OnPropertyChanged("SelectedCosmetic");
            }
        }
        
        private RelayCommand _addCosmeticCommand;
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
        
        private RelayCommand _addCosmeticUsedSlowlyCommand;
        public RelayCommand AddCosmeticUsedSlowlyCommand
        {
            get
            {
                return _addCosmeticCommand ??= new RelayCommand(obj =>
                {
                    var cosmetic = new CosmeticUsedSlowly();
                    _mainFacade.AddCosmetic(cosmetic);
                    SelectedCosmetic = cosmetic;
                });
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get 
            { 
                return _saveCommand ??= new RelayCommand(obj =>
                    _mainFacade.SaveStorage(new XmlSerializer<Storage>()));
            }
        }

        private RelayCommand _loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                return _loadCommand ??= new RelayCommand(obj =>
                    _mainFacade.LoadStorage(new XmlDeserializer<Storage>()));
            }
        }

        private OpenFilteredWindowCommand _openFiltered;

        public OpenFilteredWindowCommand OpenFiltered => _openFiltered ??= new OpenFilteredWindowCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop="")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}