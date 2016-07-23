using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Test
{
    /// <summary>
    /// Compare the numbers on the number of
    /// </summary>
    class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (NumberOfNumbers(x) < NumberOfNumbers(y))
                return -1;
            return NumberOfNumbers(x) > NumberOfNumbers(y) ? 1 : 0;
        }

        private int NumberOfNumbers(int x)
        {
            var counter = 1;
            while (Math.Abs(x) >= 10)
            {
                x = x / 10;
                counter++;
            }
           
            return counter;
        }
    }
}
