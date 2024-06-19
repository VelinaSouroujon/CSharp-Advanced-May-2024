using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> namesCount = new Dictionary<string, int>();

            foreach (string name in names)
            {
                if (!namesCount.ContainsKey(name))
                {
                    namesCount[name] = 1;
                }
                else
                {
                    namesCount[name]++;
                }
            }

            string input = "";
            while((input =  Console.ReadLine()).ToLower() != "party!")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0].ToLower();
                Predicate<string> filter = GetPredicate(tokens[1], tokens[2]);

                if(command == "remove")
                {
                    namesCount = namesCount
                        .Where(x => !filter(x.Key))
                        .ToDictionary(x => x.Key, x => x.Value);
                }
                else if(command == "double")
                {
                    foreach(var (name, count) in namesCount)
                    {
                        if(filter(name))
                        {
                            namesCount[name] *= 2;
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            if (namesCount.Count > 0)
            {
                foreach (var (name, count) in namesCount)
                {
                    for (int i = 0; i < count; i++)
                    {
                        sb.Append(name);
                        sb.Append(", ");
                    }
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append(" are going to the party!");
            }
            else
            {
                sb.Append("Nobody is going to the party!");
            }
            Console.WriteLine(sb.ToString());
        }
        static Predicate<string> GetPredicate(string command, string argument)
        {
            switch(command.ToLower())
            {
                case "startswith":
                    return x => x.StartsWith(argument);

                case "endswith":
                    return x => x.EndsWith(argument);

                case "length":
                    int length = int.Parse(argument);
                    return x => x.Length == length;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
