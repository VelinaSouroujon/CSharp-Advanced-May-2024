using System;
using System.Collections.Generic;

namespace _6.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputTokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = inputTokens[0];
                string[] clothes = inputTokens[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if(!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                
                foreach(string pieceOfClothing in clothes)
                {
                    if (!wardrobe[color].ContainsKey(pieceOfClothing))
                    {
                        wardrobe[color].Add(pieceOfClothing, 1);
                    }
                    else
                    {
                        wardrobe[color][pieceOfClothing]++;
                    }
                }
            }

            string[] searchedClothes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colorToLookFor = searchedClothes[0];
            string clothesToLookFor = searchedClothes[1];

            foreach(var (color, clothesCount) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach(var (clothes, count) in clothesCount)
                {
                    if(color == colorToLookFor &&  clothes == clothesToLookFor)
                    {
                        Console.WriteLine($"* {clothes} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes} - {count}");
                    }
                }
            }
        }
    }
}
