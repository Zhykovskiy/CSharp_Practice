using System;
using System.Collections.Generic;
using System.Text;

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
            return 0.5 * a * b * Math.Sin(alpha);
        }
    }
}
