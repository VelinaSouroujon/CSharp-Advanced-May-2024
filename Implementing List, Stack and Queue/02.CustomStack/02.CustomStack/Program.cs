using System;

namespace _02.CustomStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            Console.WriteLine(stack.Peek());

            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}

            stack.ForEach(Console.WriteLine);
        }
    }
}
