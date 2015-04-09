using System.Text;
using Octagon;
using Octagon.Parser.PolishReverseNotation;
using Octagon.Solvers;
using System.Windows;

namespace OOP_Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           SymbLabel.Content = Shell.GetSymbols();
        }

        private void Deside(object sender, RoutedEventArgs e)
        {
            ExpressionBox.Text = Shell.GetResult(ExpressionBox.Text).ToString();
        }
    }
}
