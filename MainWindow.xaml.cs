using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab_2
{
    internal enum ChartBorders
    {
        Start = -4,
        FirstBorder = -2,
        SecondBorder = 4,
        ThirdBorder = 6,
        End = 10
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Chart _chart;

        public MainWindow()
        {
            InitializeComponent();
            _chart = new();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            double minValue = getNumberFromTextBox(xMin);
            double maxValue = getNumberFromTextBox(xMax);
            double dxValue = getNumberFromTextBox(dx);
            if (Chart.isLegit(minValue, maxValue, dxValue))
            {
                MessageBox.Show($"Ошибка в вводе, функция определена на промежутке от {ChartBorders.Start} до {ChartBorders.End}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ArrayList dots = _chart.FindFuncValues(minValue, maxValue, dxValue);
            listBox.Items.Clear();
            foreach (var item in dots.ToArray().Select((value, index) => (value, index)))
            {
                listBox.Items.Add($"{item.index}:{item.value}");
            }
        }

        private double getNumberFromTextBox(TextBox textBox)
        {
            string safeString = textBox.Text.Contains('.') ? textBox.Text.Replace('.', ',') : textBox.Text;
            return double.TryParse(safeString, out double result) ? result : 0.1;
        }
    }

    internal interface IFuction
    {
        public double CalculateValue(double x);
    }

    internal class LinearFunction : IFuction
    {
        public LinearFunction(double k, double b)
        {
            _slope = k;
            _b = b;
        }

        public double Slope { get => _slope; set => _slope = value; }
        public double B { get => _b; set => _b = value; }
        private double _slope;
        private double _b;

        public double CalculateValue(double x) => _slope * x + _b;
    }

    internal class SemiCircleFunction : IFuction
    {
        public SemiCircleFunction(double radius)
        {
            _radius = radius;
        }

        public double Radius { get => _radius; }
        private readonly double _radius;

        public double CalculateValue(double x) => Math.Sqrt(Math.Pow(_radius, 2) - Math.Pow(x, 2));
    }

    internal class Chart
    {
        private readonly LinearFunction _linearFunction;
        private readonly LinearFunction _linearFunction2;
        private readonly LinearFunction _linearFunction3;
        private readonly SemiCircleFunction _semiCircleFunction;

        public Chart()
        {
            _linearFunction = new(1, 3);
            _linearFunction2 = new(1, -0.5);
            _semiCircleFunction = new(-2d);
            _linearFunction3 = new(0, -2);
        }
        public static bool isLegit(double minValue, double maxValue, double dxValue)
        {
            return minValue < ((double)ChartBorders.Start) || maxValue > (double)ChartBorders.End || dxValue > (maxValue - minValue);
        }

        public ArrayList FindFuncValues(double min, double max, double dx)
        {
            ArrayList funcValues = new();
            for (double currentValue = min; currentValue < max; currentValue += dx)
            {
                funcValues.Add(getFunction(currentValue)?.CalculateValue(currentValue));
            }
            return funcValues;
        }

        private IFuction getFunction(double min)
        {
            if (min <= ((double)ChartBorders.FirstBorder))
            {
                return _linearFunction;
            }
            else if (min <= ((double)ChartBorders.SecondBorder))
            {
                return _linearFunction2;
            }
            else if (min <= ((double)ChartBorders.ThirdBorder))
            {
                return _linearFunction3;
            }
            else if (min <= ((double)ChartBorders.End))
            {
                return _semiCircleFunction;
            }
            else
            {
                return null;
            }
        }
    }
}