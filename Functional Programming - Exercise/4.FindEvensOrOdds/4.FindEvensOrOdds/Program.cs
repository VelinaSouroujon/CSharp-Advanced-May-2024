using System;
using System.Linq;

namespace _4.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] startEnd = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = startEnd[0];
            int end = startEnd[1];

            string command = Console.ReadLine();
            Predicate<int> filter = FilterNumber(command);
            
            List<int> numbers = new List<int>();

            for (int num = start; num <= end; num++)
            {
                if (filter(num))
                {
                    numbers.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
        static Predicate<int> FilterNumber(string command)
        {
            command = command.ToLower();

            switch(command)
            {
                case "even":
                    return n => n % 2 == 0;

                case "odd":
                    return n => n % 2 != 0;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
