using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new Dictionary<string, Car>();
        }
        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if(capacity <= Count)
            {
                return "Parking is full!";
            }
            cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string RegistrationNumber)
        {
            if(!cars.ContainsKey(RegistrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            cars.Remove(RegistrationNumber);
            return $"Successfully removed {RegistrationNumber}";
        }
        public Car GetCar(string RegistrationNumber)
        {
            return cars[RegistrationNumber];
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach(string number in RegistrationNumbers)
            {
                cars.Remove(number);
            }
        }
    }
}
