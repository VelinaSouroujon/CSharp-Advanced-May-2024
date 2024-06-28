using System;
using System.Collections.Generic;

namespace _2.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSetOfNums = new HashSet<int>();
            HashSet<int> secondSetOfNums = new HashSet<int>();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSetOfNums.Add(number);
            }
            for (int i = 0;i < m; i++)
            {
                int number = int.Parse((Console.ReadLine()));
                secondSetOfNums.Add(number);
            }
            firstSetOfNums.IntersectWith(secondSetOfNums);

            Console.WriteLine(string.Join(" ", firstSetOfNums));
        }
    }
}
