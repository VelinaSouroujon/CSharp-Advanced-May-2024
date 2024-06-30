using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsPasswords = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> pointsAndContestsByName = new SortedDictionary<string, Dictionary<string, int>>();
            string input = "";

            while((input = Console.ReadLine()).ToLower() != "end of contests")
            {
                string[] tokens = input.Split(':');
                string contest = tokens[0];
                string password = tokens[1];

                contestsPasswords[contest] = password;
            }

            while((input = Console.ReadLine()).ToLower() != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string name = tokens[2];
                int points = int.Parse(tokens[3]);

                if((!contestsPasswords.ContainsKey(contest))
                    || (contestsPasswords[contest] != password)
                    || (pointsAndContestsByName.ContainsKey(name)
                    && pointsAndContestsByName[name].ContainsKey(contest)
                    && pointsAndContestsByName[name][contest] >= points))
                {
                    continue;
                }

                if(!pointsAndContestsByName.ContainsKey(name))
                {
                    pointsAndContestsByName[name] = new Dictionary<string, int>();
                }
                pointsAndContestsByName[name][contest] = points;
            }
            var bestCandidate = pointsAndContestsByName
                .OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in pointsAndContestsByName)
            {
                Console.WriteLine(kvp.Key);

                foreach(var (contest, points) in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
