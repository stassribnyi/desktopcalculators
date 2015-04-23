using Strategy.Strategy;

namespace Strategy
{
    public class ControlExpression
    {
        private IStrategy _strategy;

        public ControlExpression(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool VerifyExpression(string expression)
        {
            return _strategy.Algorithm(expression);
        }
    }
}
