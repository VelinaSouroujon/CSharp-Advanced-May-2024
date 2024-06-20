using System;
using System.Linq;

namespace _4.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowElements[j];
                }
            }
            char searchedSymbol = char.Parse(Console.ReadLine());
            bool symbolFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == searchedSymbol)
                    {
                        symbolFound = true;
                        Console.WriteLine($"({i}, {j})");
                        break;
                    }
                }
                if(symbolFound)
                {
                    break;
                }
            }
            if (!symbolFound)
            {
                Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
            }
        }
    }
}
