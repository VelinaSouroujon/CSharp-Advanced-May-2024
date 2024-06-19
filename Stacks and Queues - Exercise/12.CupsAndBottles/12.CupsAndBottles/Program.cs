using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedLittersOfWater = 0;
            int currentCupCapacity = cupsCapacity.Peek();

            while (true)
            {
                int currentBottleCapacity = bottles.Pop();

                if(currentCupCapacity > currentBottleCapacity)
                {
                    currentCupCapacity -= currentBottleCapacity;
                }
                else
                {
                    cupsCapacity.Dequeue();
                    wastedLittersOfWater += currentBottleCapacity - currentCupCapacity;

                    if (cupsCapacity.Count == 0)
                    {
                        Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                        break;
                    }
                    currentCupCapacity = cupsCapacity.Peek();
                }
                if(bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
                    break;
                }
            }
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
