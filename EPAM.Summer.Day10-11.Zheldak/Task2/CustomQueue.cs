using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public sealed class CustomQueue<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _size;
        private const int DefaultCapacity = 1;
        private int _capacity;

        public int Count => _size;

        public CustomQueue()
        {
            _capacity = DefaultCapacity;
            this._array = new T[DefaultCapacity];
            this._size = 0;
        }
        /// <summary>
        /// Adds an object to the end of the CustomQueue
        /// </summary>
        /// <param name="newElement"></param>
        public void Enqueue(T newElement)
        {
            _size++;
            if (this._size == this._capacity)
            {
                T[] newQueue = new T[2 * _capacity];
                Array.Copy(_array, 0, newQueue, 1, _array.Length);
                _array = newQueue;
                _capacity = 2 * _capacity;
            }
            else
            {
                for (int i = _size - 1; i >= 0; i--)
                    _array[i + 1] = _array[i];
            }
            _array[0] = newElement;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the CustomQueue
        /// </summary>
        /// <returns>The object that is removed from the beginning of the CusotmQueue</returns>
        public T Dequeue()
        {
            Queue<T> w = new Queue<T>();
            w.Peek();
            if (this._size == 0)
            {
                throw new InvalidOperationException();
            }
            _size--;
            var temp = _array[_size];
            _array[_size] = default(T);
            return temp;
        }

        /// <summary>
        /// Returns the object at the beginning of the CustomQueue without removing it.
        /// </summary>
        /// <returns>
        /// The object at the beginning of the</returns>
        public T Peek()
        {
            if (Count > 0)
                return _array[_size - 1];
            throw new InvalidOperationException("Queue is empty.");
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct QueueIterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> _collection;
            private int _currentIndex;
            public QueueIterator(CustomQueue<T> queue)
            {
                _collection = queue;
                _currentIndex = -1;
            }

            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            ///  <returns>
            /// The current element in the collection.
            /// </returns>
            public T Current
            {
                get
                {
                    if (_currentIndex > _collection.Count - 1)
                    {
                        throw new InvalidOperationException();
                    }
                    return _collection._array[_currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (_currentIndex > _collection.Count)
                        throw new InvalidOperationException();
                    return _collection._array[_currentIndex];
                }
            }

            public void Dispose()
            {

            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            ///  <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            public bool MoveNext()
            {
                if (_currentIndex < _collection.Count - 1)
                {
                    _currentIndex++;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                _currentIndex = -1;
            }
        }

    }

}
