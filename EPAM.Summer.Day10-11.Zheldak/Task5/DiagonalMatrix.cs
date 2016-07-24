using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class DiagonalMatrix<T> : ManrixBase<T>
    {

        public DiagonalMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException();
            if (!array.IsDiagonal())
                throw new ArgumentException();
            _array = (T[,])array.Clone();
        }
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

        public override int Size => _array.GetLength(0);
    }
}
