using System;
using System.Linq;
namespace _3.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, int> minNumber = nums => nums.Min();

            int[] inputNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minNumber(inputNums));
        }
    }
}
