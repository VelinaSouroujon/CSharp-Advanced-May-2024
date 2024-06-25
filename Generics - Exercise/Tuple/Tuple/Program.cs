using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string fullName = input[0] + " " + input[1];
            string address = input[2];
            MyTuple<string, string> personNameAddress = new MyTuple<string, string>(fullName, address);
            Console.WriteLine(personNameAddress);

            input = Console.ReadLine().Split();
            string name = input[0];
            int amountOfBeer = int.Parse(input[1]);
            MyTuple<string, int> personNameAmountOfBeer = new MyTuple<string, int>(name, amountOfBeer);
            Console.WriteLine(personNameAmountOfBeer);

            input = Console.ReadLine().Split();
            MyTuple<int, double> numbers = new MyTuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(numbers);
        }
    }
}
