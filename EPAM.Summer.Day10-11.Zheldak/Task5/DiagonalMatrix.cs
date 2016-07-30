using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// The class describing diagonal matrix and work with it.
    /// </summary>
    public sealed class DiagonalMatrix<T> : BaseMatrix<T>
    {
        private readonly T[] _array;
        public DiagonalMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException();
            if (!array.IsDiagonal())
                throw new ArgumentException();
            _array = new T[array.GetLength(0)];
            Copy(array);
        }

        /// <summary>
        /// Copies elements from an array to _array
        /// </summary>
        private void Copy(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(0); j++)
                    if (i == j)
                        _array[i] = array[i, j];
        }

        /// <summary>
        /// The index of the element to get or set
        /// </summary>
        /// <param name="i">index of row</param>
        /// <param name="j">index of column</param>
        /// <returns>Value an element of array wich have index[<param name="i"/>,<param name="j"/>] </returns>
        public override T this[int i, int j]
        {
            get
            {
                if (!IsIndex(i) || !IsIndex(j))
                    throw new ArgumentOutOfRangeException();
                return GetValue(i, j);
            }
            set
            {
                if (!IsIndex(i) || !IsIndex(j))
                    throw new ArgumentOutOfRangeException();
                var temp = GetValue(i, j);
                SetValue(i, j, value);
                OnChange(this, new ChangeEventeArgs<T>(i, j, temp));
            }
        }

        public override int Size => _array.Length;

        /// <summary>
        /// Get value from matrix.
        /// </summary>
        protected override T GetValue(int i, int j)
        {
            if (i == j)
                return _array[i];
            return default(T);
        }

        /// <summary>
        /// Set value to the matrix.
        /// </summary>
        protected override void SetValue(int i, int j, T value)
        {
            if (i != j) throw new InvalidOperationException();
            _array[i] = value;
        }
    }
}
