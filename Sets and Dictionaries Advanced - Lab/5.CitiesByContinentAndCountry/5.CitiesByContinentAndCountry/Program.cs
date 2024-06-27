using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentsInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = inputTokens[0];
                string country = inputTokens[1];
                string city = inputTokens[2];

                if(!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo[continent] = new Dictionary<string, List<string>>();
                }
                if (!continentsInfo[continent].ContainsKey(country))
                {
                    continentsInfo[continent][country] = new List<string>();
                }
                continentsInfo[continent][country].Add(city);
            }

            foreach(var kvp in continentsInfo)
            {
                Console.WriteLine($"{kvp.Key}:");
                
                foreach(var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"{kvp2.Key} -> {string.Join(", ", kvp2.Value)}");
                }
            }
        }
    }
}
