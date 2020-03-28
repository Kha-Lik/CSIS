
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSIS_BLL;

namespace CSIS_BusinessLogic
{
    public class MainFacade
    {
        public Storage Storage { get; private set; }
        

        //public MainFacade(IDataLoader<Storage> dataLoader) => LoadStorage(dataLoader);
        public MainFacade() => Storage = new Storage();

        /*public void SaveStorage(IDataSaver<Storage> dataSaver)
        {
            var saver = new ModelSaver<Storage>(dataSaver);
            saver.Save(Storage);
        }*/

        /*public void LoadStorage(IDataLoader<Storage> dataLoader)
        {
            var loader = new ModelLoader<Storage>(dataLoader);
            Storage = loader.Load();
        }*/

        public void AddCosmetic(Cosmetic cosmetic) => Storage.AddCosmetic(cosmetic);

        
    }
}