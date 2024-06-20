using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int i = 0; i < n; i++)
            {
                int[] rowElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < rowElements.Length; j++)
                {
                    int element = rowElements[j];
                    matrix[i, j] = element;

                    if(i == j)
                    {
                        primaryDiagonalSum += element;
                    }
                    if(i + j == n - 1)
                    {
                        secondaryDiagonalSum += element;
                    }
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
