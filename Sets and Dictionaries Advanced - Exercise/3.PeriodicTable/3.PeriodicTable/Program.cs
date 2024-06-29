using System;
using System.Collections.Generic;

namespace _3.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split();
                foreach(string c in chemicalCompounds)
                {
                    chemicalElements.Add(c);
                }
            }
            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
