using System;
using System.Windows.Input;
using Command_Calc.Model;
using DAL.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Octagon.DataModels;
using Strategy_Calc;
using Strategy_Calc.Validator;

namespace Octagon.Client.ViewModel
{
    public class BaseCalculatorViewModel : ViewModelBase
    {
        private string _expression;
        private string _memory;
        private int _lvl = -1;
        private int _position = -1;
        private const int UserId = 1;

        private ICommand _desideCommand;
        private ICommand _clearCommand;
        private ICommand _undoCommand;
        private ICommand _redoCommand;
        private ICommand _mrCommand;
        private ICommand _msCommand;
        private ICommand _mcCommand;
        private ICommand _mpCommand;
        private ICommand _mmCommand;

        private readonly CalcMemory _calcMemory;
        private readonly HistoryInvoker _instance;
        private readonly ControlExpression _controlExpression;

        public string Expression
        {
            get { return _expression; }
            set
            {
                _expression = value;
                RaisePropertyChanged(() => Expression);
            }
        }

        public string Memory
        {
            get { return _memory; }
            set
            {
                _memory = value;
                RaisePropertyChanged(() => Memory);
            }
        }

        public BaseCalculatorViewModel()
        {
            _calcMemory = new CalcMemory();
            _instance = new HistoryInvoker();
            _controlExpression = new ControlExpression(new BaseValidator());//does not work right, because it need normal regexp
            InitCalculator();
            InitMemory(new UserMemoryRepository());
            InitHistory(new UserHistoryRepository());
        }

        private void InitCalculator()
        {
            Expression = "0";
            Memory = "0";
        }

        private void InitMemory(IRepository<UserMemoryModel> context)
        {
            var userMemoryList = context.Select(UserId);
            _calcMemory.Memory = Convert.ToDouble(userMemoryList[0].Memory);
            Memory = _calcMemory.Memory.ToString();
        }

        private void InitHistory(IRepository<UserHistoryModel> context)
        {
            var userHistoryList = context.Select(UserId);
            foreach (var userHistoryModel in userHistoryList)
            {
                _instance.Write(userHistoryModel.Expression.Trim());
                _lvl++;
            }

            Expression = _instance.ReadLast();
            _position = _lvl;
        }

        public void AppendValue(string value)
        {
            if (Expression != "0")
                Expression += value;
            else Expression = value;
        }

        private void Solve()
        {
            if (_controlExpression.VerifyExpression(Expression))
            {
                _instance.Write(Expression);
                Expression = Shell.GetResult(Expression).ToString();
                _lvl++;
                _position = _lvl;
            }
        }

        public ICommand DesideCommand
        {
            get { return _desideCommand ?? (_desideCommand = new RelayCommand(Solve)); }
        }

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand(() =>
                {
                    Expression = "0";
                }));
            }
        }

        public ICommand RedoCommand
        {
            get
            {
                return _redoCommand ?? (_redoCommand = new RelayCommand(() =>
                {
                    if (_position < _lvl)
                    {
                        _position++;
                        _instance.Redo(_position);
                        Expression = _instance.ReadLast();
                    }
                }));
            }

        }

        public ICommand UndoCommand
        {
            get
            {
                return _undoCommand ?? (_undoCommand = new RelayCommand(() =>
                {
                    if (_position > 0)
                    {
                        _instance.Undo(_position);
                        Expression = _instance.ReadLast();
                        _position--;
                    }
                }));
            }

        }

        public ICommand MR
        {
            get
            {
                return _mrCommand ?? (_mrCommand = new RelayCommand(() =>
                {
                    Expression = _calcMemory.Memory.ToString();
                }));
            }
        }

        public ICommand MS
        {
            get
            {
                return _msCommand ?? (_msCommand = new RelayCommand(() =>
                {
                    Solve();
                    _calcMemory.Memory = Convert.ToDouble(Expression);
                    Memory = _calcMemory.Memory.ToString();
                }));
            }

        }

        public ICommand MC
        {
            get
            {
                return _mcCommand ?? (_mcCommand = new RelayCommand(() =>
                {
                    _calcMemory.Memory = 0;
                    Memory = _calcMemory.Memory.ToString();
                }));
            }
        }

        public ICommand MP
        {
            get
            {
                return _mpCommand ?? (_mpCommand = new RelayCommand(() =>
                {
                    Solve();
                    _calcMemory.Memory += Convert.ToDouble(Expression);
                    Memory = _calcMemory.Memory.ToString();
                }));
            }
        }

        public ICommand MM
        {
            get
            {
                return _mmCommand ?? (_mmCommand = new RelayCommand(() =>
                {
                    Solve();
                    _calcMemory.Memory -= Convert.ToDouble(Expression);
                    Memory = _calcMemory.Memory.ToString();
                }));
            }
        }

    }
}