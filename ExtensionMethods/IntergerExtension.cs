using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal static class IntergerExtension
    {

        public static bool PositiveOrNegative(this Int32 number)
        {
            return number >= 0;
        }

        public static bool EvenOdd(this Int32 number)
        {

            return number / 2 == 0;
        }

        public static bool Greater(this Int32 number, int num)
        {

            return number < num;
        }
    }
}
