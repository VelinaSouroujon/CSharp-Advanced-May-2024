using System;
using System.Linq;

namespace _8.Bombs
{
    internal class Program
    {
        static int[,] matrix;
        static int sum;
        static int aliveCells;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            sum = 0;
            aliveCells = 0;

            for (int i = 0; i < n; i++)
            {
                int[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    int element = rowElements[j];
                    matrix[i, j] = element;

                    if(element > 0)
                    {
                        sum += element;
                        aliveCells++;
                    }
                }
            }

            string[] inputCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(string coordinate in inputCoordinates)
            {
                int[] coordinatesInfo = coordinate.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int rowIdx = coordinatesInfo[0];
                int colIdx = coordinatesInfo[1];

                if (matrix[rowIdx, colIdx] > 0)
                {
                    BombExplode(rowIdx, colIdx);
                    sum -= matrix[rowIdx, colIdx];
                    matrix[rowIdx, colIdx] = 0;
                    aliveCells--;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void BombExplode(int row, int col)
        {
            int damage = matrix[row, col];
            InflictDamage(row - 1, col - 1, damage);
            InflictDamage(row - 1, col, damage);
            InflictDamage(row - 1, col + 1, damage);
            InflictDamage(row, col - 1, damage);
            InflictDamage(row, col + 1, damage);
            InflictDamage(row + 1, col - 1, damage);
            InflictDamage(row + 1, col, damage);
            InflictDamage(row + 1, col + 1, damage);
        }
        static void InflictDamage(int row, int col, int damage)
        {
            if(!IsIdxValid(row, col) || matrix[row, col] <= 0)
            {
                return;
            }

            sum -= Math.Min(matrix[row, col], damage);
            matrix[row, col] -= damage;

            if (matrix[row, col] <= 0)
            {
                aliveCells--;
            }
        }
        static bool IsIdxValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
