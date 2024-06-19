using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColsCount = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsColsCount[0], rowsColsCount[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < rowElements.Length; j++)
                {
                    matrix[i, j] = rowElements[j];
                }
            }

            for (int colIdx = 0;colIdx < matrix.GetLength(1); colIdx++)
            {
                int colSum = 0;
                for (int rowIdx = 0; rowIdx < matrix.GetLength(0); rowIdx++)
                {
                    colSum += matrix[rowIdx, colIdx];
                }
                Console.WriteLine(colSum);
            }
        }
    }
}
