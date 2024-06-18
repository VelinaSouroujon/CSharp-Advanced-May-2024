using System;

namespace _7.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Func<string, int, bool> filter = (name, maxLength) => name.Length <= maxLength;

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(name => filter(name, n))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
