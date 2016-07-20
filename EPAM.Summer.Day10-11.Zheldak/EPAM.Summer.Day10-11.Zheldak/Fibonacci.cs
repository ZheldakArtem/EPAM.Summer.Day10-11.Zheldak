using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1

{
    public static class Fibonacci
    {
        /// <summary>
        /// The method get fibonacci numbers
        /// </summary>
        /// <param name="count">Amount of numbers</param>
        /// <returns>Fibonacci numbers</returns>
        public static IEnumerable<int> GetFibonacci(int count)
        {
          if (count < 0)
            {
                throw new ArgumentException("count is negative");
            }

            if (count != 0)
            {
                int x = 0;
                int y = 1;
                int temp = 1;
                yield return temp;
                temp = 0;
                for (int i = 1; i < count; i++)
                {
                    temp = x + y;
                    x = y;
                    y = temp;
                    yield return temp;
                }
            }
        }
    }
}
