using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', 4);
            string fullName = input[0] + " " + input[1];
            string address = input[2];
            string town = input[3];
            Threeuple<string, string, string> personPersonalInfo = new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(personPersonalInfo);

            input = Console.ReadLine().Split();
            string name = input[0];
            int amountOfBeer = int.Parse(input[1]);
            bool isDrunk = input[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> drinkingPerson = new Threeuple<string, int, bool>(name, amountOfBeer, isDrunk);
            Console.WriteLine(drinkingPerson);

            input = Console.ReadLine().Split();
            string personName = input[0];
            double accountBalance = double.Parse(input[1]);
            string bankName = input[2];
            Threeuple<string, double, string> personWithBankAccount = new Threeuple<string, double, string>(personName, accountBalance, bankName);
            Console.WriteLine(personWithBankAccount);
        }
    }
}
