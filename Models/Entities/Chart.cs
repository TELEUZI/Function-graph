using Lab_2.Models.Enums;
using Lab_2.Models.Interfaces;
using System.Collections.Generic;

namespace Lab_2.Models.Entities
{
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

        public static bool IsLegitValues(double minValue, double maxValue, double dxValue)
        {
            return minValue < ((double) ChartBorders.Start) || maxValue > (double) ChartBorders.End ||
                   dxValue > (maxValue - minValue);
        }

        public IEnumerable<double> FindFuncValues(double min, double max, double dx)
        {
            LinkedList<double> funcValues = new();
            for (var currentValue = min; currentValue < max; currentValue += dx)
            {
                funcValues.AddLast(GetFunction(currentValue).CalculateValue(currentValue));
            }

            return funcValues;
        }

        private IFunction GetFunction(double min)
        {
            return min switch
            {
                <= (double) ChartBorders.FirstBorder => _linearFunction,
                <= (double) ChartBorders.SecondBorder => _linearFunction2,
                <= (double) ChartBorders.ThirdBorder => _linearFunction3,
                <= (double) ChartBorders.End => _semiCircleFunction,
                _ => null
            };
        }
    }
}