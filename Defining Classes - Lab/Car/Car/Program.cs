using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = "";

            while((input = Console.ReadLine()) != "No more tires")
            {
                string[] tokensInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                tires.Add(new Tire[4]);

                int tireIdx = 0;
                for (int i = 0; i < tokensInfo.Length - 1; i += 2)
                {
                    int year = int.Parse(tokensInfo[i]);
                    double pressure = double.Parse(tokensInfo[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tires[tires.Count - 1][tireIdx] = tire;

                    tireIdx++;
                }
            }
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tokensInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(tokensInfo[0]);
                double cubicCapacity = double.Parse(tokensInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokensInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = tokensInfo[0];
                string model = tokensInfo[1];
                int year = int.Parse(tokensInfo[2]);
                double fuelQuantity = double.Parse(tokensInfo[3]);
                double fuelConsumption = double.Parse(tokensInfo[4]);
                int engineIndex = int.Parse(tokensInfo[5]);
                int tiresIndex = int.Parse(tokensInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            cars = cars
                .Where(car =>
                {
                    double tirePressureSum = car.Tires.Sum(t => t.Pressure);

                    return car.Year >= 2017
                    && car.Engine.HorsePower > 330
                    && tirePressureSum >= 9
                    && tirePressureSum <= 10;
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (Car car in cars)
            {
                car.Drive(20);

                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }
            Console.WriteLine(sb);
        }
    }
}
