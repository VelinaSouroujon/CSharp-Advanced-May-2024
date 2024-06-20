using System;
using System.Linq;

namespace _7.GroupNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var numsGroups = numbers.GroupBy(x => Math.Abs(x % 3)).OrderBy(x => x.Key);

            foreach ( var group in numsGroups )
            {
                foreach(int numInGroup in group)
                {
                    Console.Write(numInGroup + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
