using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            Func<IEnumerable<int>, int, bool> filter = (collection, num) =>
                collection.All(div => num % div == 0);

            for (int i = 1; i <= n; i++)
            {
                if (filter(dividers, i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
