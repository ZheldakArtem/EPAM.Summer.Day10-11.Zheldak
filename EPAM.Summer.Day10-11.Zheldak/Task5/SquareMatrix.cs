using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// The class describing square matrix and work with it.
    /// </summary>
    public sealed class SquareMatrix<T> : BaseMatrix<T>
    {
        private readonly T[,] _array;
        public SquareMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException();
            Copy(array);
        }
        private void Copy(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(0); j++)
                    _array[i, j] = array[i, j];
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
                var temp = _array[i, j];
                OnChange(this, new ChangeEventeArgs<T>(i, j, temp));
                SetValue(i, j, value);
            }
        }

        /// <summary>
        /// Get size of array
        /// </summary>
        public override int Size => _array.GetLength(0);

        /// <summary>
        /// Get value from matrix.
        /// </summary>
        protected override T GetValue(int i, int j)
        {
            return _array[i, j];
        }

        /// <summary>
        /// Set value to the matrix.
        /// </summary>
        protected override void SetValue(int i, int j, T value)
        {
            _array[i, j] = value;
        }
    }
}
