using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializator.Serializators
{
    public class BinarySerializator<T> : ISerializator<T>
        where T : class
    {
        public void Serialize(string path, T value)
        {
            // create BinaryFormatter object
            var formatter = new BinaryFormatter();
            // get filestream
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                //serialize
                formatter.Serialize(fs, value);
            }
        }

        public T Deserialize(string path)
        {
            // create BinaryFormatter object
            var formatter = new BinaryFormatter();
            // get filestream
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                // deserialize from path
                if (fs.Length != 0)
                {
                    var item = (T) formatter.Deserialize(fs);
                    return item;
                }
                return null;
            }
        }

    }
}
