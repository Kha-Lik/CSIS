using System;
using System.IO;
using CSIS_BusinessLogic;
using System.Runtime.Serialization;

namespace CSIS_DataAccess
{
    public class XmlSerializer<T> : IDataSaver<T>
    {
        private DataContractSerializer _serializer;
        public XmlSerializer() => _serializer = new DataContractSerializer(typeof(T));
        public void Save(T obj)
        {
            using (FileStream fileStream = new FileStream(Properties.Properties.initialStorageLoadPath, FileMode.OpenOrCreate))
            {
                _serializer.WriteObject(fileStream, obj);
            }
        }
    }
}