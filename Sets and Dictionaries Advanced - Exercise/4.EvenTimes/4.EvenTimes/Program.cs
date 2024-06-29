using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if(!numbersCount.ContainsKey(num))
                {
                    numbersCount[num] = 1;
                }
                else
                {
                    numbersCount[num]++;
                }
            }
            int numEvenTimes = numbersCount.Where(x => x.Value % 2 == 0).First().Key;
            Console.WriteLine(numEvenTimes);
        }
    }
}
