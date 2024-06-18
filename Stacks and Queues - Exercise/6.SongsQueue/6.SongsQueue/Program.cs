using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Count > 0)
            {
                string[] inputTokens = Console.ReadLine().Split(' ', 2);
                string command = inputTokens[0].ToLower();

                switch (command)
                {
                    case "play":
                        songs.Dequeue();
                        break;

                    case "add":
                        string song = inputTokens[1];
                        if(songs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }
                        break;

                    case "show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
