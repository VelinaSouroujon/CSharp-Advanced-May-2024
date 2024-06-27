using System;
using System.Collections.Generic;
using System.Text;

namespace _8.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            bool hasPartyBegun = false;

            while (true)
            {
                string input = Console.ReadLine();
                if(input == "PARTY")
                {
                    hasPartyBegun = true;
                    break;
                }
                if(input == "END")
                {
                    break;
                }

                guests.Add(input);
            }

            if (hasPartyBegun)
            {
                string comingGuest = "";

                while ((comingGuest = Console.ReadLine()) != "END")
                {
                    guests.Remove(comingGuest);
                }
            }

            Console.WriteLine(guests.Count);
            StringBuilder sb = new StringBuilder();

            foreach(string g in guests)
            {
                if (char.IsDigit(g[0]))
                {
                    Console.WriteLine(g);
                }
                else
                {
                    sb.AppendLine(g);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
