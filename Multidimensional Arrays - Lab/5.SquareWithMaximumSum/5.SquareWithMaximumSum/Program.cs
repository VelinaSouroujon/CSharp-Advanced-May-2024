using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColsCount = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsColsCount[0], rowsColsCount[1]];
            int max2x2Sum = int.MinValue;
            int rowIdx = -1;
            int colIdx = -1;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < rowElements.Length; j++)
                {
                    matrix[i, j] = rowElements[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int matrixSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if(max2x2Sum < matrixSum)
                    {
                        max2x2Sum = matrixSum;
                        rowIdx = i;
                        colIdx = j;
                    }
                }
            }
            Console.WriteLine($"{matrix[rowIdx, colIdx]} {matrix[rowIdx, colIdx + 1]}");
            Console.WriteLine($"{matrix[rowIdx + 1, colIdx]} {matrix[rowIdx + 1, colIdx + 1]}");
            Console.WriteLine(max2x2Sum);
        }
    }
}
