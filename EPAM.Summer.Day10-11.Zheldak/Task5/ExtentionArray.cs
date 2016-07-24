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
        /// <param name="sumFunc">The delegate which sums elements of matrix</param>
        /// <returns></returns>
        public static BaseMatrix<T> SumMatrix<T>(this BaseMatrix<T> first, BaseMatrix<T> second, Func<T, T, T> sumFunc)
        {
            if (ReferenceEquals(first, null) || (ReferenceEquals(second, null)))
                throw new ArgumentNullException();
            if (first.Size != second.Size)
                throw new ArgumentException("Matrixes have a difference size");
            var tempArr = new T[first.Size, first.Size];
            for (int i = 0; i < first.Size; i++)
                for (int j = 0; j < first.Size; j++)
                    tempArr[i, j] = sumFunc(first[i, j], second[i, j]);

            return new SquareMatrix<T>(tempArr);
        }
    }
}
