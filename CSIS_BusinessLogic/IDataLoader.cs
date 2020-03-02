namespace CSIS_BusinessLogic
{
    public interface IDataLoader<T>
    {
        public T Load();
    }
}