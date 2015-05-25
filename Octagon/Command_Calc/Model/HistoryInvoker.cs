using System;
using System.Collections.Generic;
using Command_Calc.Command;

namespace Command_Calc.Model
{
    //invoker
    [Serializable]

    public class HistoryInvoker
    {
        private readonly IList<BaseCommand> _commands;

        private readonly ExpressionHistory _expressionHistory;

        public HistoryInvoker()
        {
            _commands = new List<BaseCommand>();
            _expressionHistory = new ExpressionHistory();
        }

        public void Redo(int level)
        {
            if (level >= 0 && level < _commands.Count) _commands[level].Redo();
        }

        public void Undo(int level)
        {
            if (level >= 0 && level < _commands.Count) _commands[level].Undo();
        }

        public void Write(string expression)
        {
            var cmd = new HistoryEditCommand(_expressionHistory, expression);
            _commands.Add(cmd);
        }

        public string Read()
        {
            return _expressionHistory.GetExpressions();
        }

        public string ReadLast()
        {
            return _expressionHistory.GetLastExpression();
        }

        public int Count()
        {
            return _commands.Count;
        }
    }
}