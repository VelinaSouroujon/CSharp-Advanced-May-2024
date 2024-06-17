using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string input = "";

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                switch(command)
                {
                    case "add":
                        int num1 = int.Parse(tokens[1]);
                        int num2 = int.Parse(tokens[2]);
                        stack.Push(num1);
                        stack.Push(num2);
                        break;

                    case "remove":
                        int numbersCountToRemove = int.Parse(tokens[1]);

                        if(stack.Count >= numbersCountToRemove)
                        {
                            for(int i = 0; i < numbersCountToRemove; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
