using System;
using System.Collections.Generic;
using System.Text;

namespace ParserOfRomanNumbers
{
    class RomanNumeral
    {
        private static Dictionary<char, int> map = new Dictionary<char, int>()
        {
            {'I',  1},
            {'V',  5},
            {'X',  10},
            {'L',  50},
            {'C',  100},
            {'D',  500},
            {'M',  1000}
        };

        private static bool IsSubtractive(int a, int b)
        {
            return b > a;
        }
        static public int Parse(string roman)
        {
            int[] arabics = new int[roman.Length];
            for (int i = 0; i < arabics.Length; i++) arabics[i] = map[roman.ToUpper()[i]];

            int result = 0;

            for (int i = 0; i < arabics.Length; i++)
            {
                if (i + 1 < arabics.Length && IsSubtractive(arabics[i], arabics[i + 1]))
                {
                    result -= arabics[i];
                }
                else result += arabics[i];

            }

            return result;
        }
    }
}
