namespace Serializator.Serializators
{
    public interface ISerializator<T>
    {
        void Serialize(string path, T value);
        T Deserialize(string path);
    }
}