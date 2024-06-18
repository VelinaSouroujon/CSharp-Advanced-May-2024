using System;
using System.Linq;
namespace _6.ReverseАndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> isDivisible = (num, n) => num % n == 0;

            var nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            nums.RemoveAll(x => isDivisible(x, n));
            nums.Reverse();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
