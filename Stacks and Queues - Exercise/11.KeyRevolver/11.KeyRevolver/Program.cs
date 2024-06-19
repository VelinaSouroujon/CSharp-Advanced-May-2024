using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletCost = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int rewardValue = int.Parse(Console.ReadLine());
            int numberBulletsInBarrel = Math.Min(gunBarrelSize, bullets.Count);
            int bulletsFired = 0;

            while (true)
            {
                int bullet = bullets.Pop();
                int lockSize = locks.Peek();
                numberBulletsInBarrel--;
                bulletsFired++;

                if (lockSize >= bullet)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }
                if (numberBulletsInBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    numberBulletsInBarrel = Math.Min(gunBarrelSize, bullets.Count);
                }
                if (locks.Count == 0)
                {
                    int priceEarned = rewardValue - bulletsFired * bulletCost;
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${priceEarned}");
                    break;
                }
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}
