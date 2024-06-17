using System;
using System.Reflection;

namespace _5._FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);

            string format = Console.ReadLine();
            Action<Person> printer = CreatePrinter(format);

            PrintFilteredPeople(people, filter, printer);
        }
        static List<Person> ReadPeople()
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }
            return people;
        }
        static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if(condition == "older")
            {
                return p => p.Age >= ageThreshold;
            }
            else if(condition == "younger")
            {
                return p => p.Age < ageThreshold;
            }
            throw new ArgumentException();
        }
        static Action<Person> CreatePrinter(string format)
        {
            string[] tokens = format.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(format == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }

            if(format == "name")
            {
                return p => Console.WriteLine(p.Name);
            }
            if(format == "age")
            {
                return p => Console.WriteLine(p.Age);
            }
            throw new ArgumentException();
        }
        static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach(Person person in people)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
        }
    }
}
