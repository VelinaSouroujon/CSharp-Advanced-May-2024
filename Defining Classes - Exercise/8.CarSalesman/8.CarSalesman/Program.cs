using System;
namespace _8.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int countOfEngines = int.Parse(Console.ReadLine());
            Engine[] engines = new Engine[countOfEngines];

            for (int i = 0; i < countOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                if(engineInfo.Length == 2)
                {
                    engines[i] = new Engine(model, power);
                }
                else if(engineInfo.Length == 3)
                {
                    if(int.TryParse(engineInfo[2], out int displacement))
                    {
                        engines[i] = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engines[i] = new Engine(model, power, efficiency);
                    }
                }
                else if(engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];

                    engines[i] = new Engine(model, power, displacement, efficiency);
                }
            }

            int countOfCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[countOfCars];

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                if(carInfo.Length == 2)
                {
                    cars[i] = new Car(model, engine);
                }
                else if(carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2], out int weight))
                    {
                        cars[i] = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = carInfo[2];
                        cars[i] = new Car(model, engine, color);
                    }
                }
                else if(carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];

                    cars[i] = new Car(model, engine, weight, color);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
