using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string input = "";
            int carsPassed = 0;
            bool crashHappened = false;

            while((input = Console.ReadLine()) != "END")
            {
                if(input == "green")
                {
                    int greenLightTimeLeft = greenLightDuration;
                    while(greenLightTimeLeft > 0 && cars.Count > 0)
                    {
                        string carToPass = cars.Dequeue();
                        int numberOfCharsToPass = carToPass.Length;
                        if(greenLightTimeLeft < carToPass.Length)
                        {
                            int carIdx = greenLightTimeLeft;
                            numberOfCharsToPass -= carIdx;
                            greenLightTimeLeft = 0;

                            if(numberOfCharsToPass > freeWindowDuration)
                            {
                                crashHappened = true;
                                carIdx += freeWindowDuration;
                                Console.WriteLine($"A crash happened!\n{carToPass} was hit at {carToPass[carIdx]}.");
                                break;
                            }
                        }
                        else
                        {
                            greenLightTimeLeft -= carToPass.Length;
                        }
                        carsPassed++;
                    }
                    if(crashHappened)
                    {
                        break;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            if(!crashHappened)
            {
                Console.WriteLine($"Everyone is safe.\n{carsPassed} total cars passed the crossroads.\n");
            }
        }
    }
}
