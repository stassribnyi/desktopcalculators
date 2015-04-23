using System.Collections;
using System.Collections.Generic;

namespace Octagon.Parser
{
    public interface IParseble//бред, переделать
    {
        IEnumerable<string> GetOperators { get; }
        string[] Convert(string expression);
    }
}