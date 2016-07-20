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
        private T[] array;
        private int size;
        private const int defaultCapacity = 1;
        private int capacity;

        public int Count => size;

        public CustomQueue()
        {
            capacity = defaultCapacity;
            this.array = new T[defaultCapacity];
            this.size = 0;
        }

        public void Enqueue(T newElement)
        {
            size++;
            if (this.size == this.capacity)
            {
                T[] newQueue = new T[2 * capacity];
                Array.Copy(array, 0, newQueue, 1, array.Length);
                array = newQueue;
                capacity = 2 * capacity;
            }
            else
            {
                for (int i = size - 1; i >= 0; i--)
                    array[i + 1] = array[i];
            }
            array[0] = newElement;
        }

        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            size--;
            var temp = array[size];
            array[size] = default(T);
            return temp;
        }

        public T Peek()
        {
            if (Count > 0)
                return array[size - 1];
            throw new InvalidOperationException("Queue is empty.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct QueueIterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> _collection;
            private int _currentIndex;
            public QueueIterator(CustomQueue<T> queue)
            {
                _collection = queue;
                _currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (_currentIndex > _collection.Count - 1)
                    {
                        throw new InvalidOperationException();
                    }
                    return _collection.array[_currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (_currentIndex > _collection.Count)
                        throw new InvalidOperationException();
                    return _collection.array[_currentIndex];
                }
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (_currentIndex < _collection.Count - 1)
                {
                    _currentIndex++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }
        }

    }

}
