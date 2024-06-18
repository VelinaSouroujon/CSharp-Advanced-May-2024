using System;
namespace _2.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> nameWithSir = name => $"Sir {name}";
            Action <string[]> printAllNames = names => 
                Console.WriteLine(string.Join(Environment.NewLine, names.Select(n => nameWithSir(n))));

            string[] inputNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            printAllNames(inputNames);
        }
    }
}
