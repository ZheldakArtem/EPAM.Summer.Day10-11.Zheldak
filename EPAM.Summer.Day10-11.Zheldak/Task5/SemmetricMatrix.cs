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
    public sealed class SemmetricMatrix<T> : BaseMatrix<T>
    {
        public SemmetricMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException();
            if (!array.IsSemmetric())
                throw new ArgumentException();
            _array = (T[,])array.Clone();
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
                return _array[i, j];
            }
            set
            {
                if (!IsIndex(i) || !IsIndex(j))
                    throw new ArgumentOutOfRangeException();
                var temp = _array[i, j];
                _array[i, j] = value;
                OnChange(this, new ChangeEventeArgs<T>(i, j, temp));
            }
        }

        /// <summary>
        /// Get size of array
        /// </summary>
        public override int Size => _array.GetLength(0);
    }
}

