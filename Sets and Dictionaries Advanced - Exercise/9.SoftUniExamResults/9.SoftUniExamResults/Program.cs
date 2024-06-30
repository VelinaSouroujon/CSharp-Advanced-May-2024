using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> countsByLanguageSubmissions = new Dictionary<string, int>();
            Dictionary<string, int> maxPointsByName = new Dictionary<string, int>();
            string input = "";

            while((input = Console.ReadLine()).ToLower() != "exam finished")
            {
                string[] tokens = input.Split('-');
                string name = tokens[0];

                if (tokens[1] == "banned")
                {
                    maxPointsByName.Remove(name);
                    continue;
                }

                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if(!maxPointsByName.ContainsKey(name))
                {
                    maxPointsByName[name] = points;
                }
                else if (maxPointsByName[name] < points)
                {
                    maxPointsByName[name] = points;
                }
                
                if(!countsByLanguageSubmissions.ContainsKey(language))
                {
                    countsByLanguageSubmissions[language] = 1;
                }
                else
                {
                    countsByLanguageSubmissions[language]++;
                }
            }
            Console.WriteLine("Results:");

            maxPointsByName = maxPointsByName
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var (name, maxPoints) in maxPointsByName)
            {
                Console.WriteLine($"{name} | {maxPoints}");
            }

            Console.WriteLine("Submissions:");

            countsByLanguageSubmissions = countsByLanguageSubmissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach(var (language, count) in countsByLanguageSubmissions)
            {
                Console.WriteLine($"{language} - {count}");
            }
        }
    }
}
