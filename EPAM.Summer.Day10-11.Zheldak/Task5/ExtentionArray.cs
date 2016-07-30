using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public static class ExtentionArray
    {
        /// <summary>
        ///The method checks whether a square matrix.
        /// </summary>
        /// <typeparam name="T">The type of elements in the matrix</typeparam>
        /// <param name="array"></param>
        /// <returns>True if matrix is an square,otherwise false</returns>
        public static bool IsSquare<T>(this T[,] array)
        {
            return array.GetLength(0) == array.GetLength(1);
        }

        /// <summary>
        ///The method checks whether a diagonal matrix.
        /// </summary>
        /// <typeparam name="T">The type of elements in the matrix</typeparam>
        /// <param name="array"></param>
        /// <returns>True if matrix is an diagonal,otherwise false</returns>
        public static bool IsDiagonal<T>(this T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(0); j++)
                    if (i != j && !array[i, j].Equals(default(T)))
                        return false;

            return true;
        }

        /// <summary>
        ///The method checks whether a semmetric matrix.
        /// </summary>
        /// <typeparam name="T">The type of elements in the matrix</typeparam>
        /// <param name="array"></param>
        /// <returns>True if matrix is an semmetric, otherwise false</returns>
        public static bool IsSemmetric<T>(this T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = i; j < array.GetLength(0); j++)
                    if (i != j && !array[i, j].Equals(array[j, i]))
                        return false;

            return true;

        }

        /// <summary>
        /// Adds two matrices
        /// </summary>
        /// <typeparam name="T">The type of elements in the matrix</typeparam>
        /// <param name="first">The first matrix</param>
        /// <param name="second">The second matrix</param>
        /// <param name="operationFunc">The delegate which sums elements of matrix</param>
        /// <returns></returns>
        public static BaseMatrix<T> SumMatrix<T>(this BaseMatrix<T> first, BaseMatrix<T> second, Func<T, T, T> operationFunc)
        {
            if (ReferenceEquals(first, null) || (ReferenceEquals(second, null)))
                throw new ArgumentNullException();
            if (first.Size != second.Size)
                throw new ArgumentException("Matrixes have a difference size");
            BaseMatrix<T> matrixResult;

            var size = first.Size;

            if (second.GetType() == typeof(SquareMatrix<T>) || first.GetType() == typeof(SquareMatrix<T>))
            {
                matrixResult = new SquareMatrix<T>(new T[size,size]);
            }
            else if (second.GetType() == typeof(SquareMatrix<T>) || first.GetType() == typeof(SymmetricMatrix<T>))
            {
                matrixResult = new SquareMatrix<T>(new T[size, size]);
            }
            else if (second.GetType() == typeof(SymmetricMatrix<T>) || first.GetType() == typeof(SquareMatrix<T>))
            {
                matrixResult = new SquareMatrix<T>(new T[size, size]);
            }
            else if (second.GetType() == typeof(DiagonalMatrix<T>) || first.GetType() == typeof(SquareMatrix<T>))
            {
                matrixResult = new SquareMatrix<T>(new T[size, size]);
            }
            else if (second.GetType() == typeof(SquareMatrix<T>) || first.GetType() == typeof(DiagonalMatrix<T>))
            {
                matrixResult = new SquareMatrix<T>(new T[size, size]);
            }
            else if (second.GetType() == typeof(DiagonalMatrix<T>) || first.GetType() == typeof(SymmetricMatrix<T>))
            {
                matrixResult = new SymmetricMatrix<T>(new T[size, size]);
            }
            else if (second.GetType() == typeof(SymmetricMatrix<T>) || first.GetType() == typeof(DiagonalMatrix<T>))
            {
                matrixResult = new SymmetricMatrix<T>(new T[size, size]);
            }
            else if (second.GetType() == typeof(SymmetricMatrix<T>) || first.GetType() == typeof(SymmetricMatrix<T>))
            {
                matrixResult = new SymmetricMatrix<T>(new T[size, size]);
            }
            else
            {
                matrixResult = new DiagonalMatrix<T>(new T[size, size]);
            }

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrixResult[i, j] = operationFunc(first[i, j], second[i, j]);
                }
            }
            return matrixResult;
        }
    }
}
