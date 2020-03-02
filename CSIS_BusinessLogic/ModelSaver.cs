namespace CSIS_BusinessLogic
{
    public class ModelSaver<T>
    {
        private IDataSaver<T> _saver;

        public ModelSaver(IDataSaver<T> dataSaver) => _saver = dataSaver;

        public void  Save(T obj) => _saver.Save(obj);
    }
}