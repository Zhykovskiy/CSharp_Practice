using System;

namespace Complex_numbers
{
    public class Complex
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex Plus(Complex number)
        {
            return new Complex(Imaginary + number.Imaginary, Real + number.Real);
        }

        public Complex Minus(Complex number)
        {
            return new Complex(Imaginary - number.Imaginary, Real - number.Real);
        }
    }
}
