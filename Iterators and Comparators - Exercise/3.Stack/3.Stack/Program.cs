using System;
using System.Linq;

namespace _3.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();

            string input = "";
            while((input = Console.ReadLine().ToLower()) != "end")
            {
                try
                {
                    string[] tokens = input
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    string command = tokens[0];
                    if (command == "push")
                    {
                        int[] elementsToPush = tokens
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        foreach (int element in elementsToPush)
                        {
                            myStack.Push(element);
                        }
                    }

                    else if (command == "pop")
                    {
                        myStack.Pop();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
            
            PrintStack(myStack);
            PrintStack(myStack);
        }
        static void PrintStack<T>(MyStack<T> myStack)
        {
            foreach(T element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
