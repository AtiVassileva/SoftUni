using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.Capacity = capacity;
        }
        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int Count
        {
            get { return this.cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }

            else if (this.cars.Count >= this.capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars.Remove(this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";

            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currentNumber in registrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == currentNumber);
            }
        }
    }
}