using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input = "";
            while((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] tokens = input.Split();
                int rowIdx = int.Parse(tokens[1]);
                int colIdx = int.Parse(tokens[2]);
                if(!ValidIndex(matrix, rowIdx, colIdx))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                string command = tokens[0].ToLower();
                int value = int.Parse(tokens[3]);
                if(command == "add")
                {
                    matrix[rowIdx][colIdx] += value;
                }
                else if(command == "subtract")
                {
                    matrix[rowIdx][colIdx] -= value;
                }
            }
            PrintMatrix(matrix);
        }
        static void PrintMatrix(int[][] matrix)
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
        static bool ValidIndex(int[][] matrix, int rowIdx, int colIdx)
        {
            return rowIdx >= 0 && colIdx >= 0 && rowIdx < matrix.Length && colIdx < matrix[rowIdx].Length;
        }
    }
}
