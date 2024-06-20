using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[rowsColsCount[0], rowsColsCount[1]];
            int count2x2EqualCharsSquares = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < rowElements.Length; j++)
                {
                    matrix[i, j] = rowElements[j];
                }

            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if ((matrix[i, j] == matrix[i, j + 1])
                        && matrix[i, j] == matrix[i + 1, j]
                        && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        count2x2EqualCharsSquares++;
                    }
                }
            }
            Console.WriteLine(count2x2EqualCharsSquares);
        }
    }
}
