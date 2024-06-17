using System;
using System.Linq;

namespace _4.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parseToDouble = str => double.Parse(str);
            Func<double, double> addVAT = num => 1.2 * num;
            Func<double, string> roundNum = num => num.ToString("f2");

            double[] numsWithVAT = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parseToDouble)
                .Select(x => addVAT(x))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, numsWithVAT.Select(roundNum)));
        }
    }
}
