using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    public class Set<T> : IEquatable<Set<T>>, IEnumerable<T> where T : class, IEquatable<T>, IFormattable
    {
        private T[] _array;
        public int Count => _array.Length;

        public Set(T[] array)
        {
            if (ReferenceEquals(array, null))
            {
                _array = null;
            }
            else
            {
                _array = new T[array.Length];
                Array.Copy(array, _array, array.Length);
            }

        }
        /// <summary>
        /// Adds an item to collection
        /// </summary>
        /// <param name="elem">The object to add to the collection</param>
        public void Add(T elem)
        {
            if (_array.Any(item => item.Equals(elem)))
            {
                throw new ArgumentException();
            }

            Array.Resize(ref _array, _array.Length + 1);
            _array[_array.Length - 1] = elem;
        }
        /// <summary>
        /// Removes element from a collection
        /// </summary>
        /// <param name="elem">Removing element</param>
        public void Remove(T elem)
        {
            T[] result = new T[_array.Length];
            int i = 0;

            foreach (T item in _array)
            {
                if (!elem.Equals(item))
                {
                    result[i] = item;
                    i++;
                }
            }
            Array.Resize(ref result, i);
            Array.Resize(ref _array, i);

            Array.Copy(result, _array, 0);
        }
        /// <summary>
        /// Removes all elements from a collection
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = default(T);
            }
        }

        public static Set<T> Unoin(Set<T> first, Set<T> second)
        {
            T[] newArray = new T[first.Count + second.Count];
            int counter = 0;
            Array.Copy(first._array, newArray, first.Count);
            for (int i = 0; i < second.Count; i++)
            {
                if (!first.Contains(second._array[i]))
                {
                    counter++;
                    newArray[first.Count + counter] = second._array[i];
                }
            }
            Array.Resize(ref newArray, first.Count + counter + 1);
            return new Set<T>(newArray);
        }

        /// <summary>
        /// Finds the intersection of two sets.
        /// </summary>
        /// <returns>Returns a new collection of type of set.</returns>
        public static Set<T> Intersection(Set<T> first, Set<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return new Set<T>(null);
            }
            if (first == second)
            {
                return first;
            }
            int counter = 0;
            T[] tempArray = new T[first.Count + second.Count];
            foreach (var item in first)
            {
                if (!second.Contains(item)) continue;
                tempArray[counter] = item;
                counter++;
            }
            Array.Resize(ref tempArray, counter + 1);
            return new Set<T>(tempArray);
        }

        /// <summary>
        /// Find the difference of two sets.
        /// </summary>
        /// <returns>Returns a new collection of type of set.</returns>
        public static Set<T> Difference(Set<T> first, Set<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return new Set<T>(null);
            }
            if (first == second)
            {
                return new Set<T>(null);
            }
            int counter = 0;
            T[] tempArray = new T[first.Count];

            foreach (var item in first)
            {

                if (!second.Contains(item))
                {
                    tempArray[counter] = item;
                }
            }

            return new Set<T>(tempArray);
        }

        /// <summary>Indicates whether the current object is equal to another object of the set.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Set<T> other)
        {
            if (ReferenceEquals(null, other) || other.Count != Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                if (other._array[i] != this._array[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>Determines whether the specified object is equal to the set.</summary>
        /// <returns>true if the specified object  is equal to the set; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the set. </param>
        public override bool Equals(object obj)
        {

            if (ReferenceEquals(null, obj))
                return false;
            Set<T> set = obj as Set<T>;
            if (ReferenceEquals(null, set))
            {
                return false;
            }
            return Equals(set);
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            int[] i;
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>Returns a string that represents the set.</summary>
        /// <returns>A string that represents the set.</returns>
        public override string ToString()
        {
            if (ReferenceEquals(null, _array))
                throw new ArgumentException();
            string result = " ";
            foreach (var item in _array)
            {
                result += item + " ";
            }

            return result;
        }

        /// <summary>Overriding functions which get hashcode. </summary>
        /// <returns>A hash code of collection.</returns>
        public override int GetHashCode()
        {
            return _array.Sum(item => item.GetHashCode());
        }

        /// <summary>
        /// Operator == overloading 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>True if <param name="rhs"></param> equals <param name="lhs"></param> </returns>
        public static bool operator ==(Set<T> lhs, Set<T> rhs)
        {
            if (ReferenceEquals(null, lhs) || ReferenceEquals(null, rhs))
                return false;

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Operator != overloading 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>False if <param name="rhs"></param> equals <param name="lhs"></param> </returns>
        public static bool operator !=(Set<T> lhs, Set<T> rhs)
        {
            return !(lhs == rhs);
        }

    }
}
