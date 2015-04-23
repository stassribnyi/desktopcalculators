﻿using Octagon;
using System;
using System.Windows;

namespace Command_Calc
{
    public partial class MainWindow : Window
    {
        private readonly CalcMemory _calcMemory = new CalcMemory();
        private readonly HistoryInvoker _instance = new HistoryInvoker();
        private int _lvl = -1;

        public MainWindow()
        {
            InitializeComponent();
            SymbLabel.Content = Shell.GetSymbols();
            MemLabel.Content = _calcMemory.Memory;
        }

        private void Deside(object sender, RoutedEventArgs e)
        {
            var exp = ExpressionBox.Text;
            _instance.Write(exp);
            ExpressionBox.Text = Shell.GetResult(exp).ToString();
            _lvl++;
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


        public void Mat(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_instance.Read());
        }
        public void Redo(object sender, RoutedEventArgs e)
        {
            _instance.Redo(_lvl+1);
            ExpressionBox.Text = _instance.ReadLast();
            _lvl++;
        }
        public void Undo(object sender, RoutedEventArgs e)
        {
            _instance.Undo(_lvl);
            ExpressionBox.Text = _instance.ReadLast();
            _lvl--;
        }
    }
}
