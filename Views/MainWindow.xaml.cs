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

        private static double GetNumberFromTextBox(TextBox textBox)
        {
            var safeString = textBox.Text.Contains('.') ? textBox.Text.Replace('.', ',') : textBox.Text;
            return double.TryParse(safeString, out var result) ? result : 0.1;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var minValue = GetNumberFromTextBox(xMin);
            var maxValue = GetNumberFromTextBox(xMax);
            var dxValue = GetNumberFromTextBox(dx);
            if (Chart.IsLegitValues(minValue, maxValue, dxValue))
            {
                ShowMessage(
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
        private static MessageBoxResult ShowMessage(string message, string caption, MessageBoxButton button,
            MessageBoxImage image)
        {
            return MessageBox.Show(
                message,
                caption,
                button,
                image);
        }
    }
    
}