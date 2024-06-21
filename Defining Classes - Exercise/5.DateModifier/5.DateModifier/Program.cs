using System;
namespace _5.DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            Console.WriteLine(DateModifier.DaysDifference(date1, date2));
        }
    }
}
