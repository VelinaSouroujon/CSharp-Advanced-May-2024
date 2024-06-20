using System;

namespace _7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            ulong[][] pascalTriangle = new ulong[n][];

            pascalTriangle[0] = new ulong[1];
            pascalTriangle[0][0] = 1;

            if (n == 1)
            {
                PrintMatrix(pascalTriangle);
                return;
            }
            pascalTriangle[1] = new ulong[2];
            pascalTriangle[1][0] = 1;
            pascalTriangle[1][1] = 1;

            for (int i = 2; i < n; i++)
            {
                pascalTriangle[i] = new ulong[i + 1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][i] = 1;

                for(int j = 1; j <= pascalTriangle[i].Length / 2; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                    pascalTriangle[i][pascalTriangle[i].Length - 1 - j] = pascalTriangle[i][j];
                }
            }
            PrintMatrix(pascalTriangle);
        }
        static void PrintMatrix(ulong[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
