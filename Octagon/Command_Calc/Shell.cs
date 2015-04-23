using Octagon;
using Octagon.CalculatorCore;
using Octagon.Solvers;
using System.Text;

namespace Command_Calc
{
    internal static class Shell
    {
        private static readonly ICalculator<double> _calc = new BaseCalculator();

        private static readonly ISolverable<double> _solver = new Solver();

        public static double GetResult(string expression)
        {
            return _solver.GetResult(expression, _calc);
        }

        public static string GetSymbols()
        {
            var str = new StringBuilder();
            foreach (var key in _calc.OperatorFunction.Keys)
                str.Append(key);
            return str.ToString();
        }
    }
}