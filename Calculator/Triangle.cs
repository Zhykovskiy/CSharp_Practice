using System;

namespace Calculator
{
    class Triangle
    {
        public static double GetTriangleSquare(double a, double b, double c)
        {
            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static double GetTriangleSquare(double a, double h)
        {
            return 0.5 * a * h;
        }

        public static double GetTriangleSquare(double a, double b, int alpha)
        {
            double rads = alpha * Math.PI / 180;
            return 0.5 * a * b * Math.Sin(rads);
        }
    }
}
