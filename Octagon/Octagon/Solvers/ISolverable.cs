using Octagon.CalculatorCore;
using Octagon.Parser;

namespace Octagon.Solvers
{
    public interface ISolverable<T>
    {
        T GetResult(string expression, ICalculator<T> calculator);
    }
}