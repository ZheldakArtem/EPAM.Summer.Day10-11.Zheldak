using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;
using Task_Book;

namespace Task4.Test
{
    [TestFixture]
    public class MyClass
    {

        [TestCaseSource(typeof(DataSource), nameof(DataSource.IntDataPreorder))]
        public void ThreeBypassingPreorderWhithDefaultComparer(int[] arrayCollection, int[] preorderArray)
        {
            BinaryTree<int> tree = new BinaryTree<int>(arrayCollection);
            var enumeratorTree = tree.GetEnumerator();
            var enumeratorPreorder = preorderArray.GetEnumerator();

            while (enumeratorTree.MoveNext() && enumeratorPreorder.MoveNext())
            {
                Assert.AreEqual(enumeratorTree.Current, enumeratorPreorder.Current);
            }
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.IntDataComparer))]
        public void ThreeWithIntComparer(int[] arrayCollection, IComparer<int> comparerInt, int[] resut)
        {
            BinaryTree<int> tree = new BinaryTree<int>(arrayCollection, comparerInt);
            var enumeratorTree = tree.GetEnumerator();
            var enumeratorPreorder = resut.GetEnumerator();

            while (enumeratorTree.MoveNext() && enumeratorPreorder.MoveNext())
            {
                Assert.AreEqual(enumeratorTree.Current, enumeratorPreorder.Current);
            }
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.DataBook))]
        public void ThreeWithBookPreorder(Book[] array, Book[] result)
        {
            BinaryTree<Book> tree = new BinaryTree<Book>(array);

            var enumeratorBook = tree.GetEnumerator();
            var enumeratorResult = result.GetEnumerator();
            while (enumeratorBook.MoveNext() && enumeratorResult.MoveNext())
            {
                Assert.AreEqual(enumeratorResult.Current, enumeratorBook.Current);
            }
        }
    }

    public static class DataSource
    {
        public static IEnumerable IntDataPreorder
        {
            get { yield return new TestCaseData(new int[] { 7, 3, 10, 2, 5, 9, 13 }, new int[] { 7, 3, 2, 5, 10, 9, 13 }); }
        }

        public static IEnumerable IntDataComparer
        {
            get { yield return new TestCaseData(new int[] { 11111, 11, 1111111111, 1, 1111, 11111111, -111111111 }, new IntComparer(), new int[] { 11111, 11, 1, 1111, 1111111111, 11111111, -111111111 }); }
        }

        public static IEnumerable DataBook
        {
            get
            {
                yield return new TestCaseData(new Book[]
          {
                new Book("AAA","AAA","AAA",111,333),
                new Book("DDD","DDD","DDD",444,444),
                new Book("EEE","EEE","EEE",555,555),
                new Book("BBB","BBB","BBB",222,222),
                new Book("CCC","CCC","CCC",333,111)


          },
          new Book[]
          {
                new Book("AAA","AAA","AAA",111,333),
                new Book("BBB","BBB","BBB",222,222),
                new Book("CCC","CCC","CCC",333,111),
                new Book("DDD","DDD","DDD",444,444),
                new Book("EEE","EEE","EEE",555,555)
          });
            }
        }
    }
}


