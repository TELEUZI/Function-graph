using Lab_2.Models.Enums;
using Lab_2.Models.Interfaces;
using System.Collections;

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
