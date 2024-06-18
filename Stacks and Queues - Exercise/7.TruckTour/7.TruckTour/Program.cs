using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<PetrolPump> pumps = new Queue<PetrolPump>();
            int numberOfPetrolPumps = int.Parse(Console.ReadLine());
            int currentPetrolAmount = 0;
            int successfulRoutePumpIdx = 0;
            int currentIdx = 0;

            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                int[] inputTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int petrolAmount = inputTokens[0];
                int distanceToTheNextPump = inputTokens[1];

                PetrolPump petrolPump = new PetrolPump(petrolAmount, distanceToTheNextPump);
                pumps.Enqueue(petrolPump);
            }

            while (currentIdx < pumps.Count)
            {
                PetrolPump petrolPump = pumps.Dequeue();
                pumps.Enqueue(petrolPump);
                currentIdx++;
                currentPetrolAmount += petrolPump.PetrolAmount;
                
                if(currentPetrolAmount < petrolPump.DistanceToTheNextPump)
                {
                    successfulRoutePumpIdx = currentIdx;
                    currentPetrolAmount = 0;
                }
                else
                {
                    currentPetrolAmount -= petrolPump.DistanceToTheNextPump;
                }
            }
            Console.WriteLine(successfulRoutePumpIdx);
        }
    }
}
