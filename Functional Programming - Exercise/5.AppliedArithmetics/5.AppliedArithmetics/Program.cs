using System;
using System.Linq;

namespace _5.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = "";

            Action<IEnumerable<int>> print = nums =>
                Console.WriteLine(string.Join(" ", nums));

            while((command = Console.ReadLine().ToLower()) != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<IEnumerable<int>, IEnumerable<int>> operation = Operation(command);
                    numbers = operation(numbers).ToArray();
                }
            }
        }
        static Func<IEnumerable<int>, IEnumerable<int>> Operation(string command)
        {
            switch (command)
            {
                case "add":
                    return nums => nums.Select(n => n + 1);

                case "multiply":
                    return nums => nums.Select(n => 2 * n);

                case "subtract":
                    return nums => nums.Select(n => n - 1);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
