using System;
using System.Linq;

namespace _4.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> inputNumbers = Console.ReadLine().Split(", ").Select(int.Parse);
            Lake lake = new Lake(inputNumbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
