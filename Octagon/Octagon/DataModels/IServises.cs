namespace Octagon.DataModels
{
    public interface IServises<T, U>
        where T : IParseble
        where U : IParseble
    {

        void Create(T item1, U item2);

        void Update(T item1, U item2);

        void Delete(T item1, U item2);
    }

    public interface IServises
    {
        void Create(object item1, object item2);

        void Update(object item1, object item2);

        void Delete(object item1, object item2);
    }
}