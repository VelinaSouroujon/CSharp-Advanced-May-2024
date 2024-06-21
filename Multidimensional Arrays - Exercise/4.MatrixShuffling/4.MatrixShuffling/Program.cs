using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    internal class Program
    {
        static string[,] matrix;
        static void Main(string[] args)
        {
            int[] rowsColsCount = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix = new string[rowsColsCount[0], rowsColsCount[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < rowElements.Length; j++)
                {
                    matrix[i, j] = rowElements[j];
                }
            }

            string input = "";

            while((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if((tokens.Length != 5) || (tokens[0] != "swap"))
                {
                    ErrorMessage();
                    continue;
                }
                int rowIdx1 = int.Parse(tokens[1]);
                int colIdx1 = int.Parse(tokens[2]);
                int rowIdx2 = int.Parse(tokens[3]);
                int colIdx2 = int.Parse(tokens[4]);

                if(IsValid(rowIdx1, colIdx1) && IsValid(rowIdx2, colIdx2))
                {
                    Swap(rowIdx1, colIdx1, rowIdx2, colIdx2);
                    PrintMatrix();
                }
                else
                {
                    ErrorMessage();
                }
            }
        }
        static bool IsValid(int rowIdx, int colIdx)
        {
            return rowIdx >= 0 && colIdx >= 0 && rowIdx < matrix.GetLength(0) && colIdx < matrix.GetLength(1);
        }
        static void Swap(int rowIdx1, int colIdx1, int rowIdx2, int colIdx2)
        {
            string temp = matrix[rowIdx1, colIdx1];
            matrix[rowIdx1, colIdx1] = matrix[rowIdx2, colIdx2];
            matrix[rowIdx2, colIdx2] = temp;
        }
        static void ErrorMessage()
        {
            Console.WriteLine("Invalid input!");
        }
        static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
