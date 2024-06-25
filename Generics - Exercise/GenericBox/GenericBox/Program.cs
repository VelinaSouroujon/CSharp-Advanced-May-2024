using System;
using System.Collections.Generic;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                list.Add(element);
            }
            double value = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>(value);

            Console.WriteLine(box.CountElementsGreaterThanValue(list));
        }
    }
}
