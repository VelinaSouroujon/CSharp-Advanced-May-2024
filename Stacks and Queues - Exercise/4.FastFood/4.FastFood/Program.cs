using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int biggestOrder = orders.Max();

            while(orders.Any())
            {
                int currentOrder = orders.Peek();
                if(foodQuantity >= currentOrder)
                {
                    foodQuantity -= currentOrder;
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(biggestOrder);
            if(!orders.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
