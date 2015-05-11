using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command_Calc.Model
{
    //receiver
    public class ExpressionHistory
    {
        private readonly IList<string> _expressionsList;

        public ExpressionHistory()
        {
            _expressionsList = new List<string>();
        }

        public void Append(string expression)
        {
            _expressionsList.Add(expression);
        }

        public void Prepend(string expression)
        {
            _expressionsList.Remove(expression);
        }

        public void Prepend(int pointer)
        {
            _expressionsList.RemoveAt(pointer);
        }

        public string GetLastExpression()
        {
            if (_expressionsList.Count != 0)
                return _expressionsList.Last();
            return null;
        }

        public string GetExpressions()
        {
            var sb = new StringBuilder();
            foreach (var expression in _expressionsList)
                sb.AppendFormat("{0}{1}", expression, Environment.NewLine);
            return sb.ToString();
        }
    }
}
