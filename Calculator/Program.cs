using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Площадь треугольника по формуле Герона: {Triangle.GetTriangleSquare(4.3, 6.9, 3.7)}");
            Console.WriteLine($"Площадь треугольника по высоте и основе: {Triangle.GetTriangleSquare(5, 7)}");
            Console.WriteLine($"Площадь треугольника по двум смежным сторонам и углу между ними: {Triangle.GetTriangleSquare(4, 6, 90)}");
        }
    }
}
