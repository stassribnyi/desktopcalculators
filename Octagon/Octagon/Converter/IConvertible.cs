using System.Collections.Generic;

namespace Octagon.Converter
{
    public interface IConvertible//бред, переделать
    {
        IEnumerable<string> GetOperators { get; }
        string[] Convert(string expression);
    }
}