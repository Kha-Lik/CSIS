namespace DAL
{
    public interface ISerializer
    {
        void Serialize(string path, object obj);

        object Deserialize(string path);
    }
}