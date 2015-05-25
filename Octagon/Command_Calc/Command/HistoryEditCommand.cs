using System;
using Command_Calc.Model;

namespace Command_Calc.Command
{
    //concrete implementation
    [Serializable]
    public class HistoryEditCommand : BaseCommand
    {
        private readonly ExpressionHistory _expressionHistory;

        private readonly string _expression;

        public HistoryEditCommand(ExpressionHistory expressionHistory, string expression)
        {
            _expressionHistory = expressionHistory;
            _expression = expression;
            _expressionHistory.Append(_expression);
        }

        public override void Redo()
        {
            _expressionHistory.Append(_expression);
        }

        public override void Undo()
        {
            _expressionHistory.Prepend(_expression);
        }
    }
}
