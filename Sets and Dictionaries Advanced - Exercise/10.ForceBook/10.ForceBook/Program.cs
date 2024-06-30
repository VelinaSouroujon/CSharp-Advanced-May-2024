using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> usersBySide = new Dictionary<string, SortedSet<string>>();
            string input = "";

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] tokens = input.Split(" | ");
                    string side = tokens[0];
                    string user = tokens[1];

                    if (usersBySide.Values.All(x => !x.Contains(user)))
                    {
                        AddUserToSide(usersBySide, side, user);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] tokens = input.Split(" -> ");
                    string user = tokens[0];
                    string side = tokens[1];
                    
                    foreach(var kvp in usersBySide)
                    {
                        if(usersBySide[kvp.Key].Remove(user))
                        {
                            break;
                        }
                    }
                    AddUserToSide(usersBySide, side, user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            usersBySide = usersBySide
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var (side, members) in usersBySide)
            {
                Console.WriteLine($"Side: {side}, Members: {members.Count}");

                foreach (string member in members)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
        static void AddUserToSide(Dictionary<string, SortedSet<string>> dic, string side, string user)
        {
            if (!dic.ContainsKey(side))
            {
                dic[side] = new SortedSet<string>();
            }
            dic[side].Add(user);
        }
    }
}
