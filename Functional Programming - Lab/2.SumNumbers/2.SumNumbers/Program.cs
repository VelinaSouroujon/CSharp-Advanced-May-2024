using System;
using System.Linq;

namespace _2.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parseToInt = str => int.Parse(str);

            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parseToInt)
                .ToArray();

            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }
    }
}
