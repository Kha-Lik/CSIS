namespace CSIS_BusinessLogic
{
    public class ModelLoader<T>
    {
        private IDataLoader<T> _loader;

        public ModelLoader(IDataLoader<T> dataLoader) => _loader = dataLoader;

        public T Load() => _loader.Load();
    }
}