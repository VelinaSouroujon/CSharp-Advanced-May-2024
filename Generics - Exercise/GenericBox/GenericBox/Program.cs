using System;
using System.Collections.Generic;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                list.Add(element);
            }
            string value = Console.ReadLine();
            Box<string> box = new Box<string>(value);

            Console.WriteLine(box.CountElementsGreaterThanValue(list));
        }
    }
}
