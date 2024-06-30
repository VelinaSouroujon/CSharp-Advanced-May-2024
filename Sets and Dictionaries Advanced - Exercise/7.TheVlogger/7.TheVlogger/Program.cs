using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _7.TheVlogger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggersAndFollowers = new Dictionary<string, Vlogger>();
            string input = "";
            while ((input = Console.ReadLine()).ToLower() != "statistics")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string command = tokens[1];

                if ((command == "joined") && (!vloggersAndFollowers.ContainsKey(name)))
                {
                    Vlogger vlogger = new Vlogger(name);
                    vloggersAndFollowers[name] = vlogger;
                }
                else if (command == "followed")
                {
                    string followedVlogger = tokens[2];

                    if (vloggersAndFollowers.ContainsKey(name)
                        && vloggersAndFollowers.ContainsKey(followedVlogger)
                        && (!vloggersAndFollowers[followedVlogger].followers.Contains(name))
                        && (name != followedVlogger))
                    {
                        vloggersAndFollowers[followedVlogger].followers.Add(name);
                        vloggersAndFollowers[name].followingCount++;
                    }
                }
            }
            vloggersAndFollowers = vloggersAndFollowers
                .OrderByDescending(x => x.Value.followers.Count)
                .ThenBy(x => x.Value.followingCount)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggersAndFollowers.Count} vloggers in its logs.");
            int counter = 1;

            foreach(var kvp in vloggersAndFollowers)
            {
                Vlogger vlogger = kvp.Value;
                Console.WriteLine($"{counter}. {kvp.Key} : {vlogger.followers.Count} followers, {vlogger.followingCount} following");

                if (counter == 1)
                {
                    foreach (string followerName in vlogger.followers)
                    {
                        Console.WriteLine($"*  {followerName}");
                    }
                }
                counter++;
            }
        }
    }
}
