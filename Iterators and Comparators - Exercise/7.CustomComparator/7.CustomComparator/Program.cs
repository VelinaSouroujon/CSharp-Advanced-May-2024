using System;
using System.Linq;

namespace _7.CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            NumbersComparer comparer = new NumbersComparer();
            Array.Sort(numbers, comparer);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
