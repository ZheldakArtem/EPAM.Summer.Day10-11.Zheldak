using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

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
        public void ThreeWithIntComparer(int[] arrayCollection, IComparer<int> comparerInt,int[] resut)
        {
            BinaryTree<int> tree = new BinaryTree<int>(arrayCollection, comparerInt);
            var enumeratorTree = tree.GetEnumerator();
            var enumeratorPreorder = resut.GetEnumerator();

            while (enumeratorTree.MoveNext() && enumeratorPreorder.MoveNext())
            {
                Assert.AreEqual(enumeratorTree.Current, enumeratorPreorder.Current);
            }
        }

       

        [Test]
        public void ThreeWithStringComparer(string[] arrayCollection, IComparer<string> comparerString)
        {
            BinaryTree<string> tree = new BinaryTree<string>(arrayCollection, comparerString);
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
            get { yield return new TestCaseData(new int[] {11111, 11, 1111111111, 1, 1111, 11111111, -111111111},new IntComparer(),new int[] {11111,11,1,1111, 1111111111, 11111111, -111111111}); }
        } 

    }
}


