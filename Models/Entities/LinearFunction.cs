using Lab_2.Models.Interfaces;

namespace Lab_2.Models.Entities
{
    internal class LinearFunction : IFunction
    {
        public LinearFunction(double slope, double b)
        {
            _slope = slope;
            _b = b;
        }

        private readonly double _slope;
        private readonly double _b;

        public double CalculateValue(double x) => (_slope * x) + _b;
    }
}