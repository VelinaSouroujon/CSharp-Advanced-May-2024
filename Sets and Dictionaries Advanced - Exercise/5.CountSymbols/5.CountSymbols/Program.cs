using System;
using System.Collections.Generic;

namespace _5.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charOccurrences = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            foreach(char c in text)
            {
                if(!charOccurrences.ContainsKey(c))
                {
                    charOccurrences.Add(c, 1);
                }
                else
                {
                    charOccurrences[c]++;
                }
            }

            foreach(var kvp in charOccurrences)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
