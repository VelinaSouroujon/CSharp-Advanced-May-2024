using System;
using System.Linq;

namespace _9.Miner
{
    internal class Program
    {
        static char[,] matrix;
        static bool areCoalsCollected;
        static bool isGameOver;
        static int coalsLeft;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputCommands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            matrix = new char[n, n];
            areCoalsCollected = false;
            isGameOver = false;
            coalsLeft = 0;

            int minerRowIdx = -1;
            int minerColIdx = -1;

            for (int i = 0; i < n; i++)
            {
                char[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < rowElements.Length; j++)
                {
                    char element = rowElements[j];
                    matrix[i, j] = element;

                    if(element == 'c')
                    {
                        coalsLeft++;
                    }
                    else if(element == 's')
                    {
                        minerRowIdx = i;
                        minerColIdx = j;
                    }
                }
            }

            for (int i = 0; i < inputCommands.Length; i++)
            {
                string direction = inputCommands[i];

                switch(direction)
                {
                    case "left":
                        if(IsIndexValid(minerRowIdx, minerColIdx - 1))
                        {
                            minerColIdx--;
                        }
                        break;

                    case "right":
                        if (IsIndexValid(minerRowIdx, minerColIdx + 1))
                        {
                            minerColIdx++;
                        }
                        break;

                    case "up":
                        if (IsIndexValid(minerRowIdx - 1, minerColIdx))
                        {
                            minerRowIdx--;
                        }
                        break;

                    case "down":
                        if (IsIndexValid(minerRowIdx + 1, minerColIdx))
                        {
                            minerRowIdx++;
                        }
                        break;
                }
                CheckSquare(minerRowIdx, minerColIdx);
                
                if(areCoalsCollected || isGameOver)
                {
                    break;
                }
            }
            if(areCoalsCollected)
            {
                Console.WriteLine($"You collected all coals! ({minerRowIdx}, {minerColIdx})");
            }
            else if(isGameOver)
            {
                Console.WriteLine($"Game over! ({minerRowIdx}, {minerColIdx})");
            }
            else
            {
                Console.WriteLine($"{coalsLeft} coals left. ({minerRowIdx}, {minerColIdx})");
            }
        }
        static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0
                && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
        static void CheckSquare(int row, int col)
        {
            if(matrix[row, col] == 'c')
            {
                coalsLeft--;
                matrix[row, col] = '*';

                if(coalsLeft == 0)
                {
                    areCoalsCollected = true;
                }
            }

            else if(matrix[row, col] == 'e')
            {
                isGameOver = true;
            }
        }
    }
}
