using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Octagon.Serializator
{
    public static class BinarySerializator
    {
        public static void Serialize(string path, params object[] paramsObjects)
        {
            var formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (var fs = new FileStream(@path, FileMode.CreateNew))
            {
                var list = paramsObjects.ToList();
                formatter.Serialize(fs, list);
            }
        }
        public static IEnumerable<object> DeSerialize(string path)
        {
            var formatter = new BinaryFormatter();
            // десериализация из файла 
            using (var fs = new FileStream(@path, FileMode.Open))
            {
                return (List<Object>)formatter.Deserialize(fs);
            }
        }
    }
}
