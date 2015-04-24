using System.Collections.Generic;

namespace Octagon.DataModels
{
    public interface IServices<T>
    {
        void Create(T item);

        void Update(T item);

        void Delete(T item);

        List<T> Select();
    }
}
