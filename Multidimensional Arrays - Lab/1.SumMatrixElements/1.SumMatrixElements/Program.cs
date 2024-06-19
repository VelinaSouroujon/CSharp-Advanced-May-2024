using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColsCount = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsColsCount[0], rowsColsCount[1]];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int elementsSum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < currentRow.Length; j++)
                {
                    int element = currentRow[j];
                    matrix[i,j] = element;
                    elementsSum += element;
                }
            }
            Console.WriteLine($"{rows}\n{cols}\n{elementsSum}");
        }
    }
}
