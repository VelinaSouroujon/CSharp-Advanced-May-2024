using System;
using System.Linq;

namespace _3.LargestThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var largestThreeNums = Console.ReadLine().Split().Select(double.Parse).OrderByDescending(x => x).Take(3);
            Console.WriteLine(string.Join(" ", largestThreeNums));
        }
    }
}
