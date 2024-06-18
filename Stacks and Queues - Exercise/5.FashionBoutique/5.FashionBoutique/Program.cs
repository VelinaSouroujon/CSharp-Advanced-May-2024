using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int initialRackCapacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = initialRackCapacity;
            int racksCount = 1;

            while(clothes.Any())
            {
                int currentCloth = clothes.Pop();
                if(currentRackCapacity >= currentCloth)
                {
                    currentRackCapacity -= currentCloth;
                }
                else
                {
                    racksCount++;
                    currentRackCapacity = initialRackCapacity - currentCloth;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
