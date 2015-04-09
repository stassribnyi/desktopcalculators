using System.Collections;
using System.Collections.Generic;

namespace Octagon.Parser
{
    public interface IParseble
    {
        IEnumerable<string> GetOperators { get; }
        string[] Convert(string expression);
    }
}