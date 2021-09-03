using Lab_2.Models.Interfaces;
using System;


namespace Lab_2.Models.Entities
{
    internal class SemiCircleFunction : IFunction
    {
        public SemiCircleFunction(double radius)
        {
            _radius = radius;
        }
        private readonly double _radius;

        public double CalculateValue(double x) => Math.Sqrt(Math.Pow(_radius, 2) - Math.Pow(x, 2));
    }
}
