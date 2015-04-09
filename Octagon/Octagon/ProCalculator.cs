using Octagon.CalculatorCore;
using System;

namespace Octagon
{
    public class ProCalculator : BaseCalculator, ITrigonometric<double>, ILogarithmic<double>
    {

        private const int _pointer = 0;

        public ProCalculator()
        {
            OperatorFunction.Add("s", new Operator<double>() { Priority = 5, OperatorFunction = Sin });
            OperatorFunction.Add("c", new Operator<double>() { Priority = 5, OperatorFunction = Cos });
            OperatorFunction.Add("t", new Operator<double>() { Priority = 5, OperatorFunction = Tan });
            //experimental ->don`t work with higher than 1 symbol
            OperatorFunction.Add("ctan", new Operator<double>() { Priority = 1, OperatorFunction = CTan });
            OperatorFunction.Add("atan", new Operator<double>() { Priority = 1, OperatorFunction = ATan });
            OperatorFunction.Add("asin", new Operator<double>() { Priority = 1, OperatorFunction = ASin });
            OperatorFunction.Add("acos", new Operator<double>() { Priority = 1, OperatorFunction = ACos });
            OperatorFunction.Add("exp", new Operator<double>() { Priority = 1, OperatorFunction = Exp });
            OperatorFunction.Add("ln", new Operator<double>() { Priority = 1, OperatorFunction = Ln });
            OperatorFunction.Add("log", new Operator<double>() { Priority = 1, OperatorFunction = Log });
            OperatorFunction.Add("!", new Operator<double>() { Priority = 1, OperatorFunction = Fact });
        }

        public double Sin(params double[] value)
        {
            return Math.Sin(value[_pointer]);
        }

        public double Cos(params double[] value)
        {
            return Math.Cos(value[_pointer]);
        }

        public double Tan(params double[] value)
        {
            return Math.Tan(value[_pointer]);
        }

        public double CTan(params double[] value)
        {
            return 1 / Math.Tan(value[_pointer]);
        }

        public double ATan(params double[] value)
        {
            return Math.Atan(value[_pointer]);
        }

        public double ASin(params double[] value)
        {
            return Math.Asin(value[_pointer]);
        }

        public double ACos(params double[] value)
        {
            return Math.Acos(value[_pointer]);
        }

        public double Exp(params double[] value)
        {
            return Math.Exp(value[_pointer]);
        }

        public double Ln(params double[] value)
        {
            return Math.Log(value[_pointer]);
        }

        public double Log(params double[] value)
        {
            return Math.Log10(value[_pointer]);
        }

        public double Fact(params double[] value)
        {
            var result = 1;
            for (var i = Convert.ToInt32(value[_pointer]); i > 1; i--)
                result *= i;
            return result;
        }

    }
}
