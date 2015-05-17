namespace Octagon.DataModels
{
    public interface IServises<T, U, Z>
        where T : IParseble
        where U : IParseble
        where Z : IParseble
    {

        void Create(T item1, U item2, Z item3);

        void Update(T item1, U item2, Z item3);

        void Delete(T item1, U item2, Z item3);
    }

    public interface IServises
    {
        void Create(object item1, object item2, object item3);

        void Update(object item1, object item2, object item3);

        void Delete(object item1, object item2, object item3);
    }
}