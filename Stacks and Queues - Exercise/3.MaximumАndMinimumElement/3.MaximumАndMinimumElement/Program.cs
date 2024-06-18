using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximumАndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] inputTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int commandNum = inputTokens[0];

                if (commandNum == 1)
                {
                    int numToPush = inputTokens[1];
                    nums.Push(numToPush);
                }
                else if (commandNum == 2)
                {
                    if (nums.Count > 0)
                    {
                        nums.Pop();
                    }
                }
                else if (commandNum == 3)
                {
                    if (nums.Count > 0)
                    {
                        Console.WriteLine(nums.Max());
                    }
                }
                else if (commandNum == 4)
                {
                    if (nums.Count > 0)
                    {
                        Console.WriteLine(nums.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
