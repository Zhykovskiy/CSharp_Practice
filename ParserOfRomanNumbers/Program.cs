using System;
using System.Collections.Generic;

namespace ParserOfRomanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {    
            string str = Console.ReadLine();
            Console.WriteLine(RomanNumeral.Parse(str));

            Console.ReadLine();
        }
    }
}
