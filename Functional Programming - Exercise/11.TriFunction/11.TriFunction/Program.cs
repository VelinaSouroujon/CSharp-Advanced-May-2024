using System;
using System.Linq;

namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> filter = (name, n) => name.Sum(x => x) >= n;

            Func<IEnumerable<string>, Func<string, int, bool>, int, string> findName = (collection, filter, n) =>
                collection.First(x => filter(x, n));

            Console.WriteLine(findName(inputNames, filter, n));
        }
    }
}
