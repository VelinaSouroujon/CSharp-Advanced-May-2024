using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static char[,] matrix;
        static bool isGameWon;
        static bool hasPlayerDied;
        static bool hasMovedToValidSquare;
        static void Main(string[] args)
        {
            int[] dimensionsInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix = new char[dimensionsInfo[0], dimensionsInfo[1]];
            int row = -1;
            int col = -1;
            isGameWon = false;
            hasPlayerDied = false;
            hasMovedToValidSquare = true;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    char element = rowElements[j];
                    matrix[i, j] = element;

                    if (element == 'P')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            string inputCommands = Console.ReadLine();

            foreach (char command in inputCommands)
            {
                matrix[row, col] = '.';

                switch (command)
                {
                    case 'L':
                        PlayerMove(row, col - 1);
                        if (hasMovedToValidSquare)
                        {
                            col--;
                        }
                        break;

                    case 'R':
                        PlayerMove(row, col + 1);
                        if (hasMovedToValidSquare)
                        {
                            col++;
                        }
                        break;

                    case 'U':
                        PlayerMove(row - 1, col);
                        if (hasMovedToValidSquare)
                        {
                            row--;
                        }
                        break;

                    case 'D':
                        PlayerMove(row + 1, col);
                        if (hasMovedToValidSquare)
                        {
                            row++;
                        }
                        break;
                }

                AllBunniesSpread();

                if (isGameWon || hasPlayerDied)
                {
                    break;
                }
            }

            PrintMatrix();
            if (isGameWon)
            {
                Console.WriteLine($"won: {row} {col}");
            }
            else if(hasPlayerDied)
            {
                Console.WriteLine($"dead: {row} {col}");
            }
        }
        static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        static void PlayerMove(int row, int col)
        {
            if (IsIndexValid(row, col))
            {
                if (matrix[row, col] == 'B')
                {
                    hasPlayerDied = true;
                }
                else
                {
                    matrix[row, col] = 'P';
                }
            }
            else
            {
                hasMovedToValidSquare = false;
                isGameWon = true;
            }
        }
        static void AllBunniesSpread()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        BunnySpread(i - 1, j);
                        BunnySpread(i + 1, j);
                        BunnySpread(i, j - 1);
                        BunnySpread(i, j + 1);
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'x')
                    {
                        matrix[i, j] = 'B';
                    }
                }
            }
        }
            static void BunnySpread(int row, int col)
            {
                if (IsIndexValid(row, col))
                {
                    if ((matrix[row, col] == 'P') && (!isGameWon))
                    {
                        hasPlayerDied = true;
                    }
                    if (matrix[row, col] != 'B')
                    {
                        matrix[row, col] = 'x';
                    }
                }
            }
            static void PrintMatrix()
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
