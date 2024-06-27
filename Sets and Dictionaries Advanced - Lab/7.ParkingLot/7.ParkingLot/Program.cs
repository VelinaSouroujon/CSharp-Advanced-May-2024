using System;
using System.Collections.Generic;

namespace _7.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            string input = "";

            while((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0].ToLower();
                string carNum = tokens[1];

                if(command == "in")
                {
                    carNumbers.Add(carNum);
                }
                else if(command == "out") 
                {
                    carNumbers.Remove(carNum);
                }
            }

            if (carNumbers.Count > 0)
            {
                foreach (string carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
