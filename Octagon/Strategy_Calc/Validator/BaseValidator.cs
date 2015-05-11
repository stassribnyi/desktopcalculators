using Strategy_Calc.Strategy;
using System.Text.RegularExpressions;

namespace Strategy_Calc.Validator
{
    public class BaseValidator : IStrategy
    {
        public bool Algorithm(string expression)
        {
            return Validate(expression);
        }

        private bool Validate(string expression)
        {
            var reg = new Regex(@"((\d{1,}\,\d{1,})|\d{1,})+((\+|\-|\*|\/|\^)+((\d{1,}\,\d{1,})|\d{1,})){1,}");//remake
            return reg.IsMatch(expression);
        }
    }
}
