namespace DAL.Abstract
{
    public interface ISerializer
    {
        void Serialize(string path, object obj);

        object Deserialize(string path);
    }
}