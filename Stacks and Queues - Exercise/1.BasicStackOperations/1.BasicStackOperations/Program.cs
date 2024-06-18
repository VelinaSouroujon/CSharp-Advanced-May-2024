using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int pushCount = input[0];
            int popCount = input[1];
            int searchedElement = input[2];

            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < pushCount; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0;i < popCount; i++)
            {
                if(stack.Any())
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }
            if(stack.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
