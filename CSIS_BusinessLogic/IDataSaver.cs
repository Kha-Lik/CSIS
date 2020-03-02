namespace CSIS_BusinessLogic
{
    public interface IDataSaver<T>
    {
        public void Save(T obj);
    }
}