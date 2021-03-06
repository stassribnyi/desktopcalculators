﻿using System.Linq;
using Octagon.CalculatorCore;
using Octagon.Converter.PolishReverseNotation;
using System;
using System.Collections.Generic;

namespace Octagon.Solvers
{
    public class Solver : ISolverable<double>
    {
        private Converter.IConvertible _parser;

        public Solver()
        {
        }

        public Solver(Converter.IConvertible parser)
        {
            _parser = parser;
        }

        private void InitParser(ICalculator<double> calc)
        {
            _parser = new PolishReverseNotation(calc.OperatorFunction);
        }

        public double GetResult(string expression, ICalculator<double> calculator)
        {
            if (expression.Length != 0)
            {
                InitParser(calculator);

                var stack = new Stack<string>();

                var queue = new Queue<string>(_parser.Convert(expression));

                var str = queue.Dequeue();

                while (queue.Count >= 0)
                {
                    if (!_parser.GetOperators.Contains(str))
                    {
                        stack.Push(str);
                        if (queue.Count > 0)
                            str = queue.Dequeue();
                        else
                            break;
                    }
                    else
                    {
                        var func = calculator.OperatorFunction[str];
                        var mas = new double[2]; //создаем масив на 2 элемента ибо больше 2 -х фн принамать не могут
                        mas[0] = Convert.ToDouble(stack.Pop());
                        if (stack.Count != 0)
                            mas[1] = Convert.ToDouble(stack.Pop());
                        //при условии что стек не пуст заполняем второй элемеет, на случай если у нас функция с одним операндом
                        var answer = func.OperatorFunction(mas);

                        stack.Push(answer.ToString());
                        if (queue.Count > 0)
                            str = queue.Dequeue();
                        else
                            break;
                    }
                }
                
                return Convert.ToDouble(stack.Pop());
            }
            return 0;
        }
    }
}

