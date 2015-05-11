using System.Collections.Generic;

namespace Octagon.DataModels
{
    public interface IRepository<T> where T : IParseble
    {
        void Create(T item);

        void Update(T item);

        void Delete(T item);

        IList<T> Select(int id);
    }

    public interface IRepository
    {
        void Create(object item);

        void Update(object item);

        void Delete(object item);

        List<object> Select();
    }
}
