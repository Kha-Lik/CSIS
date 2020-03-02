using System.IO;
using System.Runtime.Serialization;
using CSIS_BusinessLogic;

namespace CSIS_DataAccess
{
    public class XmlDeserializer<T> : IDataLoader<T>
    {
        private DataContractSerializer _serializer;
        public XmlDeserializer() => _serializer = new DataContractSerializer(typeof(T));
        public T Load()
        {
            using (FileStream fileStream = new FileStream(Properties.Properties.initialStorageLoadPath, FileMode.Open))
            {
                return (T)_serializer.ReadObject(fileStream);
            }
        }
    }
}