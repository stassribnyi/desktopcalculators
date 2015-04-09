using System.Collections.Generic;

namespace Octagon.CalculatorCore
{
    public interface ICalculator<T>
    {
        IDictionary<string, Operator<T>> OperatorFunction { get; set; }
    }
}