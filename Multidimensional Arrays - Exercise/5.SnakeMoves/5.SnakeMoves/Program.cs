using System;
using System.Linq;

namespace _5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rowsColsCount = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(rowsColsCount[0]);
            int cols = int.Parse(rowsColsCount[1]);
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            int idxSnake = 0;
            bool fromLeftToRight = true;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (fromLeftToRight)
                    {
                        matrix[i, j] = snake[idxSnake];
                    }
                    else
                    {
                        matrix[i, cols - 1 - j] = snake[idxSnake];
                    }

                    idxSnake++;
                    if(idxSnake == snake.Length)
                    {
                        idxSnake = 0;
                    }
                    if(j == cols - 1)
                    {
                        if(fromLeftToRight)
                        {
                            fromLeftToRight = false;
                        }
                        else
                        {
                            fromLeftToRight = true;
                        }
                    }
                }
            }

            for (int i = 0; i < rows; i ++)
            {
                for(int j = 0;j < cols; j ++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
