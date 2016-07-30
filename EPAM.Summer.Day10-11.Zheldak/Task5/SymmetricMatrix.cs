using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// The class describing semmetric matrix and work with it.
    /// </summary>
    public sealed class SymmetricMatrix<T> : BaseMatrix<T>
    {
        private readonly T[][] _array;
        public SymmetricMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException();
            if (!array.IsSemmetric())
                throw new ArgumentException();
            _array = new T[array.GetLength(0)][];
            Copy(array);
        }

        /// <summary>
        /// Copies elements from an array to _array
        /// </summary>
        private void Copy(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j <= i; j++)
                    _array[i][j] = array[i, j];
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

        /// <summary>
        /// Get size of array
        /// </summary>
        public override int Size => _array.GetLength(0);

        /// <summary>
        /// Get value from matrix.
        /// </summary>
        protected override T GetValue(int i, int j)
        {
            if (j <= i) return _array[i][j];
            Swap(ref i, ref j);

            return _array[i][j];
        }

        /// <summary>
        /// Set value to the matrix.
        /// </summary>
        protected override void SetValue(int i, int j, T value)
        {
            if (j <= i)
                _array[i][j] = value;
            else
            {
                Swap(ref i, ref j);
                _array[i][j] = value;
            }
        }

        private void Swap(ref int i, ref int j)
        {
            var temp = i;
            i = j;
            j = temp;
        }

    }
}

