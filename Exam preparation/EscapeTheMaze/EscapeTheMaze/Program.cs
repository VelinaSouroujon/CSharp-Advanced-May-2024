using System;
using System.Linq;

namespace EscapeTheMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int maxHealth = 100;
            int health = maxHealth;
            int monsterDamage = 40;
            int boostHealth = 15;
            int travellerRow = -1;
            int travellerCol = -1;
            int exitRow = -1;
            int exitCol = -1;
            bool hasPlayerDied = false;

            for (int i = 0; i < n; i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < rowElements.Length; j++)
                {
                    char element = rowElements[j];
                    matrix[i, j] = element;

                    if(element == 'P')
                    {
                        travellerRow = i;
                        travellerCol = j;
                    }
                    else if(element == 'X')
                    {
                        exitRow = i;
                        exitCol = j;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                matrix[travellerRow, travellerCol] = '-';

                switch(command)
                {
                    case "up":
                        if(IsInside(matrix, travellerRow - 1, travellerCol))
                        {
                            travellerRow--;
                        }
                        break;

                    case "down":
                        if (IsInside(matrix, travellerRow + 1, travellerCol))
                        {
                            travellerRow++;
                        }
                        break;

                    case "right":
                        if (IsInside(matrix, travellerRow, travellerCol + 1))
                        {
                            travellerCol++;
                        }
                        break;

                    case "left":
                        if (IsInside(matrix, travellerRow, travellerCol - 1))
                        {
                            travellerCol--;
                        }
                        break;
                }

                if (matrix[travellerRow, travellerCol] == 'M')
                {
                    health -= monsterDamage;

                    if(health <= 0)
                    {
                        hasPlayerDied = true;
                        health = 0;
                        break;
                    }
                }

                else if (matrix[travellerRow, travellerCol] == 'H')
                {
                    health = Math.Min(maxHealth, health + boostHealth);
                }
                else if (matrix[travellerRow, travellerCol] == 'X')
                {
                    break;
                }
                matrix[travellerRow, travellerCol] = 'P';
            }

            matrix[travellerRow, travellerCol] = 'P';

            if (hasPlayerDied)
            {
                Console.WriteLine($"Player is dead. Maze over!\nPlayer's health: {health} units");
            }
            else
            {
                Console.WriteLine($"Player escaped the maze. Danger passed!\nPlayer's health: {health} units");
            }
            PrintMatrix(matrix);
        }
        static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
