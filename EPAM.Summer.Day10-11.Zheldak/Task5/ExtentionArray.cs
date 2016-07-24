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
        public static bool IsSquare<T>(this T[,] array)
        {
            return array.GetLength(0) == array.GetLength(1);
        }

        public static bool IsDiagonal<T>(this T[,] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    if (i != j && !array[i, j].Equals(default(T)))
                        return false;

            return true;
        }

        public static bool IsSemetric<T>(this T[,] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = i; j < array.Length; j++)
                    if (i != j && !array[i, j].Equals(array[j, i]))
                        return false;

            return true;

        }

        public static ManrixBase<T> SumMatrix<T>(this ManrixBase<T> first, ManrixBase<T> second)
        {
            //in process
            return null;
        }
    }
}
