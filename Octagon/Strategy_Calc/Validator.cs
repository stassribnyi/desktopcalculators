using Strategy_Calc.Strategy;
using System.Text.RegularExpressions;

namespace Strategy_Calc
{
    public class Validator : IStrategy
    {
        public bool Algorithm(string expression)
        {
            return Validate(expression);
        }

        private bool Validate(string expression)
        {
            var reg = new Regex(@"([\^\*\+/\-/(/)])");//написать нормальную регулярку
            return reg.IsMatch(expression);
        }
    }
}
