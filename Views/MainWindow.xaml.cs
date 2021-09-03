using Lab_2.Models.Entities;
using Lab_2.Models.Enums;
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab_2
{
    
    public partial class MainWindow : Window
    {
        private readonly Chart _chart;
        public MainWindow()
        {
            InitializeComponent();
            _chart = new();
            
        }

        private void onButtonClick(object sender, RoutedEventArgs e)
        {
            double minValue = getNumberFromTextBox(xMin);
            double maxValue = getNumberFromTextBox(xMax);
            double dxValue = getNumberFromTextBox(dx);
            if (Chart.IsLegit(minValue, maxValue, dxValue))
            {
                MessageBox.Show($"Ошибка в вводе, функция определена на промежутке от {ChartBorders.Start} до {ChartBorders.End}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ArrayList dots = _chart.FindFuncValues(minValue, maxValue, dxValue);
            listBox.Items.Clear();
            foreach ((double value, int index) item in dots.ToArray().Select((value, index) => (value, index)))
            {
                listBox.Items.Add($"{item.index}:{Math.Round(item.value, 3)}");
            }
        }

        private double getNumberFromTextBox(TextBox textBox)
        {
            string safeString = textBox.Text.Contains('.') ? textBox.Text.Replace('.', ',') : textBox.Text;
            return double.TryParse(safeString, out double result) ? result : 0.1;
        }

    }

 
    

    

    
}