using System;
using System.Windows;
using Octagon;
using OOP_Calc;

namespace Strategy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalcMemory _calcMemory = new CalcMemory();

        public MainWindow()
        {
            InitializeComponent();
            SymbLabel.Content = Shell.GetSymbols();
            MemLabel.Content = _calcMemory.Memory;
        }

        private void Deside(object sender, RoutedEventArgs e)
        {
            ExpressionBox.Text = Shell.GetResult(ExpressionBox.Text).ToString();
        }
        private void MR(object sender, RoutedEventArgs e)
        {
            ExpressionBox.Text = _calcMemory.Memory.ToString();
        }
        private void MS(object sender, RoutedEventArgs e)
        {
            Deside(sender, e);
            MemLabel.Content = ExpressionBox.Text;
            _calcMemory.Memory = Convert.ToDouble(ExpressionBox.Text);
        }
        private void MC(object sender, RoutedEventArgs e)
        {
            _calcMemory.Memory = 0;
            MemLabel.Content = _calcMemory.Memory;
        }
        private void MP(object sender, RoutedEventArgs e)
        {
            Deside(sender, e);
            _calcMemory.Memory += Convert.ToDouble(ExpressionBox.Text);
            MemLabel.Content = _calcMemory.Memory;
        }
        private void MM(object sender, RoutedEventArgs e)
        {
            Deside(sender, e);
            _calcMemory.Memory -= Convert.ToDouble(ExpressionBox.Text);
            MemLabel.Content = _calcMemory.Memory;

        }
    }
}
