using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int enqueueCount = input[0];
            int dequeueCount = input[1];
            int searchedNumber = input[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < enqueueCount; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0;i < dequeueCount; i++)
            {
                if(queue.Any())
                {
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if(queue.Contains(searchedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(queue.Any())
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
