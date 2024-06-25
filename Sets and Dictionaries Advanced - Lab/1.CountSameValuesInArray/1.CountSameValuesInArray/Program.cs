using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            Dictionary<double, int> numCount = new Dictionary<double, int>();

            foreach (double num in nums)
            {
                if(numCount.ContainsKey(num))
                {
                    numCount[num]++;
                }
                else
                {
                    numCount[num] = 1;
                }
            }

            foreach(var pair in numCount)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
