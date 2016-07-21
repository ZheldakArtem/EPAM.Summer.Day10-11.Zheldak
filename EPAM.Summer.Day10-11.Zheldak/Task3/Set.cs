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
    public class Set<T> : IEnumerable<T> where T : class
    {
        private readonly IEqualityComparer<T> _equalityComparer;
        private ISet<int> d=new HashSet<int>();
        private Hashtable _hashTable;

        public int Count => _hashTable.Count;

        public Set() : this(EqualityComparer<T>.Default)
        {

        }

        public Set(IEqualityComparer<T> equalityComparer)
        {
            if (ReferenceEquals(equalityComparer, null))
            {
                throw new ArgumentNullException();
            }
            _equalityComparer = equalityComparer;
            _hashTable = new Hashtable((IEqualityComparer)_equalityComparer);
        }

        public Set(IEnumerable<T> enumerable) : this(enumerable, EqualityComparer<T>.Default)
        {

        }

        public Set(IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer) : this(equalityComparer)
        {
            if (ReferenceEquals(enumerable, null))
            {
                throw new ArgumentNullException();
            }
            foreach (T item in enumerable)
            {
                _hashTable.Add(item, item);
            }
        }
        /// <summary>
        ///  Modifies the current collections to contain only elements that are present in that object and in the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current</param>
        public void Intersection(Set<T> other)
        {
            IEnumerable<T> bigger, smaller;
            if (Count > other.Count)
            {
                bigger = this;
                smaller = other;
            }
            else
            {
                bigger = other;
                smaller =this;
            }
            _hashTable = new Hashtable((IEqualityComparer)_equalityComparer);
            foreach (var item in smaller)
            {
                if (bigger.Contains(item))
                {
                    _hashTable.Add(item, item);
                }
            }
        }

        /// <summary>
        /// Union collections
        /// </summary>
        /// <param name="other"></param>
        public void Union(Set<T> other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException();
            }
            if (ReferenceEquals(other, this))
            {
                return;
            }
            foreach (var item in other)
            {   if(!_hashTable.Contains(item))
                _hashTable.Add(item, item);
            }
        }

        /// <summary>
        /// Find the difference of two sets.
        /// </summary>
        public void Difference(Set<T> other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException();
            }
            if (ReferenceEquals(this, other))
                Clear();
            foreach (T item in other)
            {
                if (_hashTable.Contains(item))
                {
                    _hashTable.Remove(item);
                }
            }
        }

        /// <summary>
        /// Add item to collection
        /// </summary>
        /// <param name="item">Element to added</param>
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (_hashTable.Contains(item))
                throw new ArgumentException();
            _hashTable.Add(item, item);
        }
        /// <summary>
        /// Removes element from a collection
        /// </summary>
        /// <param name="elem">Removing element</param>
        public void Remove(T elem)
        {
            if (_hashTable.Contains(elem))
            {
                _hashTable.Remove(elem);
            }
        }

        /// <summary>
        /// Clear collection
        /// </summary>
        public void Clear()
        {
            _hashTable.Clear();
        }

        /// <summary>
        /// Check if item contains in set.
        /// </summary>
        /// <param name="item">Item to be checked.</param>
        /// <returns>True if set contains item, else false.</returns>
        public bool Contains(T item)
        {
            return _hashTable.Contains(item);
        }
        /// <summary>Indicates whether the current object is equal to another object of the set.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Set<T> other)
        {
            if (ReferenceEquals(null, other) || other.ToArray().Count() != Count)
                return false;
            foreach (var item in other)
            {
                if (_hashTable.Contains(item))
                    return false;
            }
            return true;
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _hashTable.Values)
            {
                yield return (T)item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>Returns a string that represents the set.</summary>
        /// <returns>A string that represents the set.</returns>
        public override string ToString()
        {
            if (ReferenceEquals(null, _hashTable))
                throw new ArgumentException();
            string result = " ";
            foreach (var item in _hashTable.Values)
            {
                result += item + " ";
            }

            return result;
        }
    }
}
