using System;
using System.Collections.Generic;

namespace _5.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = "";
            while((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] personInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                people.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine());
            Person person = people[n - 1];

            int matchingPeopleCount = people.Count(x => x.CompareTo(person) == 0);

            int notMatchingPeopleCount = people.Count - matchingPeopleCount;

            if(matchingPeopleCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchingPeopleCount} {notMatchingPeopleCount} {people.Count}");
            }
        }
    }
}
