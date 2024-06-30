using System;
using System.Linq;

namespace _1.ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputCreate = Console.ReadLine().Split();
            ListyIterator<string> iterator = new ListyIterator<string>(inputCreate.Skip(1));

            string command = "";
            while((command = Console.ReadLine().ToLower()) != "end")
            {
                try
                {
                    switch (command)
                    {
                        case "move":
                            Console.WriteLine(iterator.Move());
                            break;

                        case "print":
                            iterator.Print();
                            break;

                        case "hasnext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
