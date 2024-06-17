using System;
using System.Linq;

namespace _02.ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int initialArmor = 300;
            int armor = initialArmor;
            int jetRow = -1;
            int jetCol = -1;
            int enemyJetsCount = 0;

            for (int i = 0; i < n; i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < rowElements.Length; j++)
                {
                    char element = rowElements[j];
                    matrix[i, j] = element;

                    if(element == 'J')
                    {
                        jetRow = i;
                        jetCol = j;
                    }
                    else if(element == 'E')
                    {
                        enemyJetsCount++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                matrix[jetRow, jetCol] = '-';

                if(command == "up")
                {
                    jetRow--;
                }
                else if (command == "down")
                {
                    jetRow++;
                }
                else if (command == "left")
                {
                    jetCol--;
                }
                else if (command == "right")
                {
                    jetCol++;
                }

                if (matrix[jetRow, jetCol] == 'E')
                {
                    matrix[jetRow, jetCol] = 'J';
                    armor -= 100;

                    if (armor <= 0)
                    {
                        Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
                        break;
                    }

                    enemyJetsCount--;
                    if(enemyJetsCount == 0)
                    {
                        Console.WriteLine($"Mission accomplished, you neutralized the aerial threat!");
                        break;
                    }
                }
                else if (matrix[jetRow, jetCol] == 'R')
                {
                    armor = initialArmor;
                }
                matrix[jetRow, jetCol] = 'J';
            }
            PrintMatrix(matrix);
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
