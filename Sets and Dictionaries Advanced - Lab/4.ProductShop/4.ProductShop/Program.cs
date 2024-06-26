using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            string input = "";
            while((input = Console.ReadLine()).ToLower() != "revision")
            {
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if(!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                shops[shop].Add(product, price);
            }

            foreach(var kvp in shops)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach(var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"Product: {kvp2.Key}, Price: {kvp2.Value}");
                }
            }
        }
    }
}
