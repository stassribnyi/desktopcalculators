using Octagon.CalculatorCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Octagon
{
    public class BaseCalculator : IBase<double>, ICalculator<double>
    {
        private IDictionary<string, Operator<double>> _operatorFunc = new Dictionary<string, Operator<double>>();

        public IDictionary<string, Operator<double>> OperatorFunction
        {
            get
            {
                return _operatorFunc;
            }
            set
            {
                _operatorFunc = value;
            }
        }
        
        public BaseCalculator()
        {
            _operatorFunc.Add("(", new Operator<double> { Priority = 0 });
            _operatorFunc.Add(")", new Operator<double> { Priority = 0 });
            _operatorFunc.Add("+", new Operator<double> { Priority = 1, OperatorFunction = Addition });
            _operatorFunc.Add("-", new Operator<double> { Priority = 1, OperatorFunction = Subtraction });
            _operatorFunc.Add("*", new Operator<double> { Priority = 2, OperatorFunction = Multiplication });
            _operatorFunc.Add("/", new Operator<double> { Priority = 2, OperatorFunction = Division });
            _operatorFunc.Add("^", new Operator<double> { Priority = 3, OperatorFunction = Power });
        }

        public double Addition(params double[] values)
        {
            return values.Sum();
        }

        public double Subtraction(params double[] values)
        {
            return values.Aggregate<double, double>(0, (current, item) => item - current);
        }

        public double Multiplication(params double[] values)
        {
            return values.Aggregate<double, double>(1, (current, item) => current * item);
        }

        public double Division(params double[] values)
        {
            return values.Aggregate<double, double>(1, (current, item) => item / current);
        }

        public double Power(params double[] values)
        {
            return Math.Pow(values[1], values[0]);
        }
    }
}