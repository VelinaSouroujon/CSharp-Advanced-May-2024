﻿using System;
using System.Collections.Generic;

namespace _6.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
