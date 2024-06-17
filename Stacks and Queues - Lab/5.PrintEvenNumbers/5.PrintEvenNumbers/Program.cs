using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(x => int.Parse(x)));
            bool isFirst = true;

            while(queue.Any())
            {
                int number = queue.Dequeue();

                if(number % 2 == 0)
                {
                    if(isFirst)
                    {
                        isFirst = false;
                        Console.Write(number);
                    }
                    else
                    {
                        Console.Write($", {number}");
                    }
                }
            }
        }
    }
}
