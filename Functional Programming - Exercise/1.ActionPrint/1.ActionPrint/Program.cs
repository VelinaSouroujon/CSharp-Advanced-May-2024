using System;

namespace _1.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            print(words);
        }
    }
}
