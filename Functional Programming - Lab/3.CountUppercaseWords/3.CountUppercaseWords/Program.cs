using System;
using System.Linq;

namespace _3.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> startsWithUppercase = word => Char.IsUpper(word[0]);

            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => startsWithUppercase(x))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
