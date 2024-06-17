using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            string input = "";
            int countOfPassedCars = 0;

            while((input = Console.ReadLine()).ToLower() != "end")
            {
                if(input == "green")
                {
                    for(int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            countOfPassedCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{countOfPassedCars} cars passed the crossroads.");
        }
    }
}
