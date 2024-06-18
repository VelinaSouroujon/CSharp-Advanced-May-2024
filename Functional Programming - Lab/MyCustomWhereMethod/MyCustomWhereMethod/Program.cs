using System;
using System.Collections.Generic;

namespace MyCustomWhereMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new() { 1, 2, 3, 4, 5, 6 };

            nums = nums.Where(n => n % 2 == 0).ToList();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
