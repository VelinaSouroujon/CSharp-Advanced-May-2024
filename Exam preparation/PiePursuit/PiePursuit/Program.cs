using System;
using System.Collections.Generic;
using System.Linq;

namespace PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> piecesOfPie = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (true)
            {
                int eatingCapacity = contestants.Dequeue();
                int currentPie = piecesOfPie.Pop();

                if (eatingCapacity >= currentPie)
                {
                    eatingCapacity -= currentPie;

                    if (eatingCapacity > 0)
                    {
                        contestants.Enqueue(eatingCapacity);
                    }
                }
                else
                {
                    currentPie -= eatingCapacity;

                    if (currentPie == 1 && piecesOfPie.Count > 0)
                    {
                        int nextPie = piecesOfPie.Pop();
                        nextPie++;
                        piecesOfPie.Push(nextPie);
                    }
                    else
                    {
                        piecesOfPie.Push(currentPie);
                    }
                }

                if(!piecesOfPie.Any() && contestants.Any())
                {
                    Console.WriteLine("We will have to wait for more pies to be baked!");
                    Console.WriteLine($"Contestants left: {string.Join(", ", contestants)}");
                    break;
                }
                else if((!piecesOfPie.Any()) && (!contestants.Any()))
                {
                    Console.WriteLine("We have a champion!");
                    break;
                }
                else if(!contestants.Any() && piecesOfPie.Any())
                {
                    Console.WriteLine("Our contestants need to rest!");
                    Console.WriteLine($"Pies left: {string.Join(", ", piecesOfPie)}");
                    break;
                }
            }
        }
    }
}
