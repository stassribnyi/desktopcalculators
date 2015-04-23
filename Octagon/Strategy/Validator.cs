using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Strategy.Strategy;

namespace Strategy
{
    public class Validator : IStrategy
    {
        public bool Algorithm(string expression)
        {
            return Validate(expression);
        }

        private bool Validate(string expression)
        {
            var reg = new Regex(@"([\^\*\+/\-/(/)])");
            return reg.IsMatch(expression);
        }
    }
}
