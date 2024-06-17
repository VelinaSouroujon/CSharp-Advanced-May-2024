using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(expression.Reverse());
            int result = int.Parse(stack.Pop());

            while (stack.Any())
            {
                string operation = stack.Pop();
                int number = int.Parse(stack.Pop());

                if(operation == "+")
                {
                    result += number;
                }
                else if(operation == "-")
                {
                    result -= number;
                }
            }
            Console.WriteLine(result);
        }
    }
}
