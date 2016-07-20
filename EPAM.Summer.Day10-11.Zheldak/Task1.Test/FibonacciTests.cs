using Task1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Test
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(5, new int[] { 1, 1, 2, 3, 5 })]
        [TestCase(1, new int[] { 1 })]
        [TestCase(6, new int[] { 1, 1, 2, 3, 5, 8 })]
        [TestCase(0, new int[] { })]
        public void GetFibonacciNumbersTest(int count, IEnumerable<int> fibonacciNumbers)
        {
            var result = Fibonacci.GetFibonacci(count).ToArray();

            CollectionAssert.AreEqual(fibonacciNumbers.ToArray(), result);
        }

    }
}
