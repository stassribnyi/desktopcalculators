using Octagon.Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Octagon.Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для NumberPanel.xaml
    /// </summary>
    public partial class BaseCalculator : Page
    {
        private BaseCalculatorViewModel _baseCalculatorViewModel;
        public BaseCalculator()
        {
            InitializeComponent();
            _baseCalculatorViewModel = (BaseCalculatorViewModel)base.DataContext;
        }

        //Enter value into expression box
        private void EnterValue(string value)
        {
            _baseCalculatorViewModel.AppendValue(value);
        }
        
        private void EnterComma(object sender, RoutedEventArgs e)
        {
            EnterValue(Comma.Content.ToString());
        }
        private void EnterZero(object sender, RoutedEventArgs e)
        {
            EnterValue(Zero.Content.ToString());
        }
        private void EnterOne(object sender, RoutedEventArgs e)
        {
            EnterValue(One.Content.ToString());
        }
        private void EnterTwo(object sender, RoutedEventArgs e)
        {
            EnterValue(Two.Content.ToString());
        }
        private void EnterThree(object sender, RoutedEventArgs e)
        {
            EnterValue(Three.Content.ToString());
        }
        private void EnterFour(object sender, RoutedEventArgs e)
        {
            EnterValue(Four.Content.ToString());
        }
        private void EnterFive(object sender, RoutedEventArgs e)
        {
            EnterValue(Five.Content.ToString());
        }
        private void EnterSix(object sender, RoutedEventArgs e)
        {
            EnterValue(Six.Content.ToString());
        }
        private void EnterSeven(object sender, RoutedEventArgs e)
        {
            EnterValue(Seven.Content.ToString());
        }
        private void EnterEight(object sender, RoutedEventArgs e)
        {
            EnterValue(Eight.Content.ToString());
        }
        private void EnterNine(object sender, RoutedEventArgs e)
        {
            EnterValue(Nine.Content.ToString());
        }
        private void EnterAddition(object sender, RoutedEventArgs e)
        {
            EnterValue(Addition.Content.ToString());
        }
        private void EnterSubstraction(object sender, RoutedEventArgs e)
        {
            EnterValue(Substraction.Content.ToString());
        }
        private void EnterMultiplication(object sender, RoutedEventArgs e)
        {
            EnterValue(Multiplication.Content.ToString());
        }
        private void EnterDivision(object sender, RoutedEventArgs e)
        {
            EnterValue(Division.Content.ToString());
        }
        private void EnterPower(object sender, RoutedEventArgs e)
        {
            EnterValue(Power.Content.ToString());
        }

    }
}
