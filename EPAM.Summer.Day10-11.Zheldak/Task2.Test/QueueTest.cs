using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Test
{
    [TestFixture]
    public class QueueTest
    {
        [TestCase(new int[] { 9, 8, 4, 2 }, 2)]
        public void TestMethodsEnqueuDequeuPeek(int[] expectedArray, int expectedPeek)
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            var customIter = customQueue.GetEnumerator();
            Queue<int> queue = new Queue<int>();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(4);
            customQueue.Enqueue(8);
            customQueue.Enqueue(9);
            customQueue.Dequeue();
            Assert.AreEqual(customQueue.Peek(), expectedPeek);
            int[] array = customQueue.ToArray();
            CollectionAssert.AreEqual(expectedArray, array);

        }
    }
}
