using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }
        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if(capacity <= Count)
            {
                return "Parking is full!";
            }
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string RegistrationNumber)
        {
            int idxToRemove = cars.FindIndex(x => x.RegistrationNumber == RegistrationNumber);

            if(idxToRemove == -1)
            {
                return $"Car with that registration number, doesn't exist!";
            }
            cars.RemoveAt(idxToRemove);
            return $"Successfully removed {RegistrationNumber}";
        }
        public Car GetCar(string RegistrationNumber)
        {
            return cars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            cars.RemoveAll(x => RegistrationNumbers.Contains(x.RegistrationNumber));
        }
    }
}
