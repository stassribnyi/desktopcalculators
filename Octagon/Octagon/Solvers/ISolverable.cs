using Octagon.CalculatorCore;

namespace Octagon.Solvers
{
    public interface ISolverable<T>
    {
        T GetResult(string expression, ICalculator<T> calculator);
    }
}