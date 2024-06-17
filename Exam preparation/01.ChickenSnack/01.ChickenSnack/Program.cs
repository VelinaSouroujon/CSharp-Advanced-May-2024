using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Channels;

namespace _01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> moneyAmount = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> foodPrices = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int countFoodEaten = 0;

            while(moneyAmount.Count > 0 && foodPrices.Count > 0)
            {
                int money = moneyAmount.Pop();
                int price = foodPrices.Dequeue();
                int difference = money - price;

                if(difference >= 0)
                {
                    countFoodEaten++;

                    if (moneyAmount.Count > 0)
                    {
                        int moneyToPush = moneyAmount.Pop() + difference;
                        moneyAmount.Push(moneyToPush);
                    }
                }
            }
            if(countFoodEaten >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {countFoodEaten} foods.");
            }
            else if(countFoodEaten == 1)
            {
                Console.WriteLine($"Henry ate: {countFoodEaten} food.");
            }
            else if(countFoodEaten == 0)
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
            else
            {
                Console.WriteLine($"Henry ate: {countFoodEaten} foods.");
            }
        }
    }
}
