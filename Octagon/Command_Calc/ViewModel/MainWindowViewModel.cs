using System;
using System.Windows.Input;
using Command_Calc.Model;
using Octagon;

namespace Command_Calc.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _expression;
        private string _symbols;
        private string _memory;
        private int _lvl = -1;
        private int _position = -1;

        private ICommand _desideCommand;
        private ICommand _undoCommand;
        private ICommand _redoCommand;
        private ICommand _mrCommand;
        private ICommand _msCommand;
        private ICommand _mcCommand;
        private ICommand _mpCommand;
        private ICommand _mmCommand;

        private readonly CalcMemory _calcMemory;
        private readonly HistoryInvoker _instance;
        
        public string Expression
        {
            get { return _expression; }
            set
            {
                _expression = value;
                OnPropertyChanged("Expression");
            }
        }

        public string Memory
        {
            get { return _memory; }
            set
            {
                _memory = value;
                OnPropertyChanged("Memory");
            }
        }

        public string Symbols
        {
            get { return _symbols; }
        }

        public MainWindowViewModel()
        {
            _calcMemory = new CalcMemory();
            _instance = new HistoryInvoker();
            _symbols = Shell.GetSymbols();
        }

        private void Solve()
        {
            _instance.Write(Expression);
            Expression = Shell.GetResult(Expression).ToString();
            _lvl++;
            _position = _lvl;
        }

        public ICommand DesideCommand
        {
            get
            {
                return _desideCommand ?? (_desideCommand = new RelayCommand(args =>
                {
                    Solve();
                }));
            }
        }
        
        public ICommand RedoCommand
        {
            get
            {
                return _redoCommand ?? (_redoCommand = new RelayCommand(args =>
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
                return _undoCommand ?? (_undoCommand = new RelayCommand(args =>
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
                return _mrCommand ?? (_mrCommand = new RelayCommand(args =>
                {
                    Expression = _calcMemory.Memory.ToString();
                }));
            }
        }

        public ICommand MS
        {
            get
            {
                return _msCommand ?? (_msCommand = new RelayCommand(args =>
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
                return _mcCommand ?? (_mcCommand = new RelayCommand(args =>
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
                return _mpCommand ?? (_mpCommand = new RelayCommand(args =>
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
                return _mmCommand ?? (_mmCommand = new RelayCommand(args =>
                {
                    Solve();
                    _calcMemory.Memory -= Convert.ToDouble(Expression);
                    Memory = _calcMemory.Memory.ToString();
                }));
            }
        }
        }
}
