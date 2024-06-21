using System;
using System.Linq;

namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsColsCount[0], rowsColsCount[1]];
            int rowIdxMaxSum = 0;
            int colIdxMaxSum = 0;
            int max3x3Sum = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < rowElements.Length; j++)
                {
                    matrix[i, j] = rowElements[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if(max3x3Sum < sum)
                    {
                        max3x3Sum = sum;
                        rowIdxMaxSum = i;
                        colIdxMaxSum = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {max3x3Sum}");
            Console.WriteLine($"{matrix[rowIdxMaxSum, colIdxMaxSum]} {matrix[rowIdxMaxSum, colIdxMaxSum + 1]} {matrix[rowIdxMaxSum, colIdxMaxSum + 2]}\n" +
                $"{matrix[rowIdxMaxSum + 1, colIdxMaxSum]} {matrix[rowIdxMaxSum + 1, colIdxMaxSum + 1]} {matrix[rowIdxMaxSum + 1, colIdxMaxSum + 2]}\n" +
                $"{matrix[rowIdxMaxSum + 2, colIdxMaxSum]} {matrix[rowIdxMaxSum + 2, colIdxMaxSum + 1]} {matrix[rowIdxMaxSum + 2, colIdxMaxSum + 2]}");
        }
    }
}
