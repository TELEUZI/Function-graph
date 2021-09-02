using Lab_2.Models.Interfaces;

namespace Lab_2.Models.Entities
{
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

        public double CalculateValue(double x) => (_slope * x) + _b;
    }
}
