using System;
using System.Linq;

namespace _1.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parseToInt = str => int.Parse(str);
            Func<int, bool> isEven = num => num % 2 == 0;
            Func<int, int> sort = num => num;

            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parseToInt)
                .Where(isEven)
                .OrderBy(sort)
                .ToArray();

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
