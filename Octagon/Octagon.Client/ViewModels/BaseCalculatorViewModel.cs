using System;
using System.Collections.Generic;
using System.Windows.Input;
using Command_Calc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Serializator.Containers;
using Strategy_Calc;
using Strategy_Calc.Validator;

namespace Octagon.Client.ViewModels
{
    public class BaseCalculatorViewModel : ViewModelBase
    {
        private string _expression;
        private string _symbol;
        private string _memory;

        private int _lvl = -1;
        private int _position = -1;
       
        private ICommand _desideCommand;
        private ICommand _clearCommand;
        private ICommand _undoCommand;
        private ICommand _redoCommand;
        private ICommand _appendCommand;
        private ICommand _memoryCommand;

        private CalcMemory _calcMemory;
        private HistoryInvoker _instance;
        private readonly ControlExpression _controlExpression;
        
        private delegate void MemoryDelegate();
        private IDictionary<string, MemoryDelegate> _memoryFunc;
        
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                RaisePropertyChanged(() => Symbol);
            }
        }

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
            _controlExpression = new ControlExpression(new BaseValidator());//does not work fully right, because it need normal regexp
            
            InitCalculator();
            AddMemoryFunc();
        }
        
        private void InitCalculator()
        {
            if (Manager.HistoryAndMemoryContainer!=null)
            {
                _calcMemory = Manager.HistoryAndMemoryContainer.CalcMemory;
                _instance = Manager.HistoryAndMemoryContainer.HistoryInvoker;

                _lvl = _instance.Count()-1;
                _position = _lvl;

                //init fields
                Memory = _calcMemory.Memory.ToString();
                Expression = _instance.ReadLast();
            }
            else
            {
                Memory = "0";
                Expression = "0";
            }

        }

        private void AddMemoryFunc()
        {
            _memoryFunc = new Dictionary<string, MemoryDelegate>
            {
                {
                    "MS", delegate
                    {
                        Solve();
                        _calcMemory.Memory = Convert.ToDouble(Expression);
                        Memory = _calcMemory.Memory.ToString();
                    }
                },
                {
                    "MR", delegate
                    {
                        Expression = _calcMemory.Memory.ToString();
                    }
                },
                {
                    "MC", delegate
                    {
                        _calcMemory.Memory = 0;
                        Memory = _calcMemory.Memory.ToString();
                    }
                },
                {
                    "M+", delegate
                    {
                        Solve();
                        _calcMemory.Memory += Convert.ToDouble(Expression);
                        Memory = _calcMemory.Memory.ToString();
                    }
                },
                {
                    "M-", delegate
                    {
                        Solve();
                        _calcMemory.Memory -= Convert.ToDouble(Expression);
                        Memory = _calcMemory.Memory.ToString();
                    }
                }
            };
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

            Manager.HistoryAndMemoryContainer = Manager.HistoryAndMemoryContainer ?? new HistoryAndMemoryContainer();
            Manager.HistoryAndMemoryContainer.CalcMemory = _calcMemory;
            Manager.HistoryAndMemoryContainer.HistoryInvoker = _instance;
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

        public ICommand MemoryCommand
        {
            get
            {
                return _memoryCommand ?? (_memoryCommand = new RelayCommand<string>((param) => _memoryFunc[param].Invoke()));
            }
        }

        public ICommand AppendCommand
        {
            get
            {
                return _appendCommand ?? (_appendCommand = new RelayCommand<string>((param) =>
                {
                    Expression += param;
                }));
            }
        }
    }
}