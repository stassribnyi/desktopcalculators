using System;
using System.Collections.Generic;

namespace Octagon.Converter.PolishReverseNotation
{
    public class PolishReverseNotation : IConvertible
    {
        private readonly IDictionary<string, Operator<double>> _operatorFunc = new Dictionary<string, Operator<double>>();

        public IEnumerable<string> GetOperators
        {
            get { return _operatorFunc.Keys; }
        }

        public PolishReverseNotation(IDictionary<string, Operator<double>> operFunc)
        {
            _operatorFunc = operFunc;
        }

        public IEnumerable<string> Separate(string expression)
        {
            var position = 0;

            while (position < expression.Length)
            {
                var separated = string.Empty + expression[position];

                if (!_operatorFunc.ContainsKey(expression[position].ToString()))
                {
                    for (var i = position + 1; i < expression.Length &&
                        (Char.IsDigit(expression[i]) || expression[i] == ',' || expression[i] == '.'); i++)

                        separated += expression[i];
                }
                else if (Char.IsLetter(expression[position]))
                {
                    for (var i = position + 1; i < expression.Length &&
                        (Char.IsLetter(expression[i]) || Char.IsDigit(expression[i])); i++)

                        separated += expression[i];
                }
                yield return separated;

                position += separated.Length;
            }
        }

        public string[] Convert(string expression)
        {
            var outputSeparated = new List<string>();

            var stack = new Stack<string>();

            foreach (var item in Separate(expression))
            {
                if (_operatorFunc.ContainsKey(item))
                {
                    if (stack.Count > 0 && !item.Equals("("))
                    {
                        if (item.Equals(")"))
                        {
                            var s = stack.Pop();

                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (_operatorFunc[item].Priority > _operatorFunc[stack.Peek()].Priority)
                            stack.Push(item);
                        else
                        {
                            while (stack.Count > 0 && _operatorFunc[item].Priority <= _operatorFunc[stack.Peek()].Priority)
                                outputSeparated.Add(stack.Pop());
                            stack.Push(item);
                        }
                    }
                    else
                        stack.Push(item);
                }
                else
                    outputSeparated.Add(item);
            }
            if (stack.Count > 0)
                outputSeparated.AddRange(stack);

            return outputSeparated.ToArray();
        }
    }
}
