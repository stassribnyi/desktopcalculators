using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command_Calc
{
    //base command
    public abstract class Command
    {
        public abstract void Redo();
        public abstract void Undo();
    }

    //concrete implementation
    public class HistoryEditCommand : Command
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

    //invoker
    public class HistoryInvoker
    {
        private readonly IList<Command> _commands;

        private readonly ExpressionHistory _expressionHistory;

        public HistoryInvoker()
        {
            _commands = new List<Command>();
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
    }
    
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