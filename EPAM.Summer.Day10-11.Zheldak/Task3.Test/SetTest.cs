using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task3;

namespace Task3.Test
{
    [TestFixture]
    public class SetTest
    {
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.DataUnion))]
        public void TestSetUnion(Set<string> setFirst, Set<string> setSecond, Set<string> resultSet)
        {
            setFirst.Union(setSecond);
            var iteratorFirst = setFirst.GetEnumerator();
            var resultIterator = resultSet.GetEnumerator();
            while (iteratorFirst.MoveNext() && resultIterator.MoveNext())
            {
                Assert.AreEqual(iteratorFirst.Current, resultIterator.Current);
            }
        }
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.DataIntersections))]
        public void TestSetIntersection(Set<string> setFirst, Set<string> setSecond, Set<string> resultSet)
        {
            setFirst.Intersection(setSecond);
            var iteratorFirst = setFirst.GetEnumerator();
            var resultIterator = resultSet.GetEnumerator();
            while (iteratorFirst.MoveNext() && resultIterator.MoveNext())
            {
                Assert.AreEqual(iteratorFirst.Current, resultIterator.Current);
            }
        }
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.DataDifference))]
        public void TestSetDifference(Set<string> setFirst, Set<string> setSecond, Set<string> resultSet)
        {
            setFirst.Difference(setSecond);
            var iteratorFirst = setFirst.GetEnumerator();
            var resultIterator = resultSet.GetEnumerator();
            while (iteratorFirst.MoveNext() && resultIterator.MoveNext())
            {
                Assert.AreEqual(iteratorFirst.Current, resultIterator.Current);
            }
        }


        public static class TestDataSource
        {
            public static IEnumerable DataUnion
            {
                get
                {
                    yield return new TestCaseData(new Set<string> { "a", "b", "c" }, new Set<string> { "a", "j", "f" }, new Set<string> { "a", "b", "c", "j", "f" });
                    yield return new TestCaseData(new Set<string> { "a", "b", "c" }, new Set<string> { "a", "b", "c" }, new Set<string> { "a", "b", "c" });
                }
            }

            public static IEnumerable DataDifference
            {
                get
                {
                    yield return new TestCaseData(new Set<string> { "a", "b", "c" }, new Set<string> { "a", "j", "f" }, new Set<string> { "b", "c" });
                    yield return new TestCaseData(new Set<string> { "a", "b", "c" }, new Set<string> { "a", "b", "c" }, new Set<string> { });
                }
            }

            public static IEnumerable DataIntersections
            {
                get
                {
                    yield return new TestCaseData(new Set<string> { "a", "b", "c" }, new Set<string> { "a", "j", "f" }, new Set<string> { "a" });
                    yield return new TestCaseData(new Set<string> { "a", "b", "c" }, new Set<string> { "a", "b", "c" }, new Set<string> { "a", "b", "c" });
                }
            }

        }
    }
}
