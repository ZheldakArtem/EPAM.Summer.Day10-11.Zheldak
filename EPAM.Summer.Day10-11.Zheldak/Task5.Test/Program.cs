using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task5;

namespace Task5.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] squareArray = { { 1, 2, 3 }, { 1, 2, 9 }, { 2, 4, 1 } };
            int[,] diagonalArray = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] semetricalArray = { { 1, 3, 5 }, { 3, 2, 4 }, { 5, 4, 6 } };
            try
            {
                var squareMatrix = new SquareMatrix<int>(squareArray);
                var diagonalMatrix = new DiagonalMatrix<int>(diagonalArray);
                var semetricalMatrix = new SemmetricMatrix<int>(semetricalArray);
                Console.WriteLine(diagonalMatrix.ToString());
                Console.WriteLine(semetricalMatrix.ToString());
                var resultSum=semetricalMatrix.SumMatrix(diagonalMatrix, (a, b) => a + b);
                Console.WriteLine(resultSum.ToString());
                diagonalMatrix.Changes+= Change;
                diagonalMatrix[2, 2] = 123;
                diagonalMatrix[2, 2] = 0;

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
               Console.ReadKey();
            }

        }

        static void Change(object sender, ChangeEventeArgs<int>  info)
        {
            Console.WriteLine("You changed element {0} wich have index [{1},{2}]", info.OldElem,info.I,info.J);
            Thread.Sleep(2000);
        }
    }
}
