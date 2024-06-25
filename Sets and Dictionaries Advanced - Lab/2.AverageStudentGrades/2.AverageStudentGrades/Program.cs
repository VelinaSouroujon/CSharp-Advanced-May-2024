using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string studentName = inputInfo[0];
                decimal grade = decimal.Parse(inputInfo[1]);

                if(!grades.ContainsKey(studentName))
                {
                    grades[studentName] = new List<decimal>();
                }
                grades[studentName].Add(grade);
            }

            foreach(var kvp in grades)
            {
                Console.Write($"{kvp.Key} -> ");
                decimal averageGrade = 0;

                foreach(decimal grade in kvp.Value)
                {
                    averageGrade += grade;
                    Console.Write($"{grade:f2} ");
                }
                averageGrade /= kvp.Value.Count;
                Console.WriteLine($"(avg: {averageGrade:f2})");
            }
        }
    }
}
