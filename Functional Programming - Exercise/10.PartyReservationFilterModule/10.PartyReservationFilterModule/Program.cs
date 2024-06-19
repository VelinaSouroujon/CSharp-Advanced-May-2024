using System;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool[] map = new bool[inputNames.Length];
            map = map
                .Select(x => true)
                .ToArray();

            string input = "";
            while((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string inputFilter = tokens[1];
                string arg = tokens[2];
                Predicate<string> filter = GetFilter(inputFilter, arg);

                if (command.StartsWith("Add"))
                {
                    for (int i = 0; i < inputNames.Length; i++)
                    {
                        if (filter(inputNames[i]))
                        {
                            map[i] = false;
                        }
                    }
                }
                else if (command.StartsWith("Remove"))
                {
                    for (int i = 0; i < inputNames.Length; i++)
                    {
                        if (filter(inputNames[i]))
                        {
                            map[i] = true;
                        }
                    }
                }
            }
            for (int i = 0; i < map.Length; i++)
            {
                if(map[i])
                {
                    Console.Write(inputNames[i] + " ");
                }
            }
        }
        static Predicate<string> GetFilter(string filterType, string argument)
        {
            switch(filterType)
            {
                case "Starts with":
                    return x => x.StartsWith(argument);

                case "Ends with":
                    return x => x.EndsWith(argument);

                case "Length":
                    int length = int.Parse(argument);
                    return x => x.Length == length;

                case "Contains":
                    return x => x.Contains(argument);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
