using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.KnightGame
{
    internal class Program
    {
        static int[,] board;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            board = new int[n, n];
            List<int> knights = new List<int>();
            int totalKnightsRemoved = 0;

            for (int i = 0; i < n; i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    char element = rowElements[j];
                    board[i, j] = element;

                    if(element == 'K')
                    {
                        knights.Add(i);
                        knights.Add(j);
                    }
                }
            }

            int[] positions =
            {
                -2, -1,
                -2, 1,
                -1, 2,
                 1, 2,
                 2, 1,
                 2, -1,
                 1, -2,
                -1, -2
            };

            while (knights.Count > 0)
            {
                int maxKnightsHit = 0;
                int knightToRemoveRowIdx = -1;
                int knightToRemoveColIdx = -1;
                int rowIdxToRemoveFromList = -1;
                int colIdxToRemoveFromList = -1;

                for (int i = 0; i < knights.Count - 1; i += 2)
                {
                    int countKnightsHit = 0;
                    int knightRow = knights[i];
                    int knightCol = knights[i + 1];

                    for (int j = 0; j < positions.Length - 1; j += 2)
                    {
                        int targetRow = knightRow + positions[j];
                        int targetCol = knightCol + positions[j + 1];

                        if (IsInside(targetRow, targetCol) && board[targetRow, targetCol] == 'K')
                        {
                            countKnightsHit++;
                        }
                    }

                    if (maxKnightsHit < countKnightsHit)
                    {
                        maxKnightsHit = countKnightsHit;
                        knightToRemoveRowIdx = knightRow;
                        knightToRemoveColIdx = knightCol;

                        rowIdxToRemoveFromList = i;
                        colIdxToRemoveFromList = i + 1;
                    }
                }
                if(knightToRemoveRowIdx == -1)
                {
                    break;
                }

                board[knightToRemoveRowIdx, knightToRemoveColIdx] = '0';
                totalKnightsRemoved++;

                knights.RemoveAt(rowIdxToRemoveFromList);
                knights.RemoveAt(colIdxToRemoveFromList - 1);
            }
            Console.WriteLine(totalKnightsRemoved);
        }
        static bool IsInside(int row, int col)
        {
            return row >= 0 && row < board.GetLength(0)
                && col >= 0 && col < board.GetLength(1);
        }
    }
}
