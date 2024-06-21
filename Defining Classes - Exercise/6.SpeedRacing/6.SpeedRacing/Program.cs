using System;
using System.Linq;

namespace _6.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                string[] inputTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = inputTokens[0];
                double fuelAmount = double.Parse(inputTokens[1]);
                double fuelConsumptionFor1km = double.Parse(inputTokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars[i] = car;
            }

            string input = "";
            while((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[1];
                double distance = double.Parse(tokens[2]);

                Car carToDrive = cars.FirstOrDefault(c => c.Model == model);
                carToDrive.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
