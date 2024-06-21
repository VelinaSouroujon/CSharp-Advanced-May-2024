using System;
using System.Linq;

namespace _7.RawData
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
                int engineSpeed = int.Parse(inputTokens[1]);
                int enginePower = int.Parse(inputTokens[2]);
                int cargoWeight = int.Parse(inputTokens[3]);
                string cargoType = inputTokens[4];

                double firstTirePressure = double.Parse(inputTokens[5]);
                int firstTireAge = int.Parse(inputTokens[6]);
                double secondTirePressure = double.Parse(inputTokens[7]);
                int secondTireAge = int.Parse(inputTokens[8]);
                double thirdTirePressure = double.Parse(inputTokens[9]);
                int thirdTireAge = int.Parse(inputTokens[10]);
                double fourthTirePressure = double.Parse(inputTokens[11]);
                int fourthTireAge = int.Parse(inputTokens[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tire[] tires = new Tire[4];
                tires[0] = new Tire(firstTireAge, firstTirePressure);
                tires[1] = new Tire(secondTireAge, secondTirePressure);
                tires[2] = new Tire(thirdTireAge, thirdTirePressure);
                tires[3] = new Tire(fourthTireAge, fourthTirePressure);

                Car car = new Car(model, engine, cargo, tires);
                cars[i] = car;
            }

            string cargoTypeToLookup = Console.ReadLine();

            if(cargoTypeToLookup == "fragile")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == cargoTypeToLookup && c.Tires.Any(x => x.Pressure < 1))
                    .ToArray();
            }
            else if(cargoTypeToLookup == "flammable")
            {
                cars = cars
                   .Where(c => c.Cargo.Type == cargoTypeToLookup && c.Engine.Power > 250)
                   .ToArray();
            }

            foreach(Car car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
