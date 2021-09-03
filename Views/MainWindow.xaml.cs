using Lab_2.Models.Entities;
using Lab_2.Models.Enums;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab_2.Views
{
    
    public partial class MainWindow : Window
    {
        private readonly Chart _chart;
        public MainWindow()
        {
            InitializeComponent();
            _chart = new();
            
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var minValue = getNumberFromTextBox(xMin);
            var maxValue = getNumberFromTextBox(xMax);
            var dxValue = getNumberFromTextBox(dx);
            if (Chart.IsLegit(minValue, maxValue, dxValue))
            {
                MessageBox.Show(
                    $"Ошибка в вводе, функция определена на промежутке от {ChartBorders.Start} до {ChartBorders.End}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            var dots = _chart.FindFuncValues(minValue, maxValue, dxValue);
            ListBox.Items.Clear();
            var dotsIndexedArray = dots.ToArray().Select((value, index) => (value, index));
            foreach (var (value, index) in dotsIndexedArray)
            {
                ListBox.Items.Add($"{index.ToString()}: {value.ToString(CultureInfo.CurrentCulture)}");
            }
        }

        private double getNumberFromTextBox(TextBox textBox)
        {
            var safeString = textBox.Text.Contains('.') ? textBox.Text.Replace('.', ',') : textBox.Text;
            return double.TryParse(safeString, out var result) ? result : 0.1;
        }

    }

 
    

    

    
}