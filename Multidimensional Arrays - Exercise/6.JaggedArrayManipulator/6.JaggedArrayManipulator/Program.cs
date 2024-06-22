using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    internal class Program
    {
        static double[][] matrix;
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            matrix = new double[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(double.Parse).ToArray();

                if(i != 0)
                {
                    if (matrix[i].Length == matrix[i - 1].Length)
                    {
                        MultiplyBy2(i);
                    }
                    else
                    {
                        DivideBy2(i);
                    }
                }
            }

            string input = "";
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] tokens = input.Split();
                int rowIdx = int.Parse(tokens[1]);
                int colIdx = int.Parse(tokens[2]);
                if (!IsIndexValid(rowIdx, colIdx))
                {
                    continue;
                }

                string command = tokens[0].ToLower();
                int value = int.Parse(tokens[3]);
                if (command == "add")
                {
                    matrix[rowIdx][colIdx] += value;
                }
                else if (command == "subtract")
                {
                    matrix[rowIdx][colIdx] -= value;
                }
            }
            PrintMatrix();
        }
        static void MultiplyBy2(int row)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] *= 2;
                matrix[row - 1][col] *= 2;
            }
        }
        static void DivideBy2(int row)
        {
            int length = Math.Min(matrix[row - 1].Length, matrix[row].Length);

            for(int col = 0; col < length; col++)
            {
                matrix[row - 1][col] /= 2;
                matrix[row][col] /= 2;
            }
            double[] elementsLeft;
            if(length == matrix[row - 1].Length)
            {
                elementsLeft = matrix[row];
            }
            else
            {
                elementsLeft = matrix[row - 1];
            }

            for(int col = length; col < elementsLeft.Length; col++)
            {
                elementsLeft[col] /= 2;
            }
        }
        static void PrintMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool IsIndexValid(int rowIdx, int colIdx)
        {
            return rowIdx >= 0 && colIdx >= 0 && rowIdx < matrix.Length && colIdx < matrix[rowIdx].Length;
        }
    }
}
