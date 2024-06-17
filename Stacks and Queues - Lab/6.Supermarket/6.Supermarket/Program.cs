using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if(input == "end")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }
                if(input == "paid")
                {
                    while(queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
        }
    }
}
