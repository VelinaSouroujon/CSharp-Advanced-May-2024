using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            while(queue.Count > 1)
            {
                for(int i = 0; i < n - 1; i++)
                {
                    string currentKid = queue.Dequeue();
                    queue.Enqueue(currentKid);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
