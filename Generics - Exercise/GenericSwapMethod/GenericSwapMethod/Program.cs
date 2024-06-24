using System;
using System.Collections.Generic;

namespace GenericSwapMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                list.Add(num);
            }
            string[] inputIndexesToSwap = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int firstIndex = int.Parse(inputIndexesToSwap[0]);
            int secondIndex = int.Parse(inputIndexesToSwap[1]);
            Swap(list, firstIndex, secondIndex);

            foreach(int item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
        static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
