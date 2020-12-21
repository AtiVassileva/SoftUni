using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allTires = new List<Tire[]>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "No more tires")
                {
                    break;
                }

                var tiresArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var tire1Year = int.Parse(tiresArgs[0]);
                var tire1Pressure = double.Parse(tiresArgs[1]);
                var tire2Year = int.Parse(tiresArgs[2]);
                var tire2Pressure = double.Parse(tiresArgs[3]);
                var tire3Year = int.Parse(tiresArgs[4]);
                var tire3Pressure = double.Parse(tiresArgs[5]);
                var tire4Year = int.Parse(tiresArgs[6]);
                var tire4Pressure = double.Parse(tiresArgs[7]);

                var tires = new Tire[4]
                {
                    new Tire(tire1Year, tire1Pressure),
                    new Tire(tire2Year, tire2Pressure),
                    new Tire(tire3Year, tire3Pressure),
                    new Tire(tire4Year, tire4Pressure),
                };
                allTires.Add(tires);
            }

            var allEngines = new List<Engine>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Engines done")
                {
                    break;
                }

                var engineArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var currHorsePower = int.Parse(engineArgs[0]);
                var currCubicCapacity = double.Parse(engineArgs[1]);

                var currEngine = new Engine(currHorsePower, currCubicCapacity);
                allEngines.Add(currEngine);
            }

            var allCarsCreated = new HashSet<Car>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Show special")
                {
                    break;
                }

                var carArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var make = carArgs[0];
                var model = carArgs[1];
                var year = int.Parse(carArgs[2]);
                var fuelQuantity = double.Parse(carArgs[3]);
                var fuelConsumption = double.Parse(carArgs[4]);
                var engineIndex = int.Parse(carArgs[5]);
                var tiresIndex = int.Parse(carArgs[6]);

                var engine = allEngines[engineIndex];
                var tires = allTires[tiresIndex];

                var currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

                allCarsCreated.Add(currentCar);
            }

            foreach (var car in allCarsCreated)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower >= 330 && HasValidTires(car))
                {
                    car.Drive(20);
                    Console.WriteLine(car);
                }
            }
        }

        private static bool HasValidTires(Car car)
        {
            var hasValidTires = false;
            var totalSum = 0.0;

            foreach (var tire in car.Tires)
            {
                totalSum += tire.Pressure;
            }

            if (totalSum >= 9 && totalSum <= 10)
            {
                hasValidTires = true;
            }
            return hasValidTires;
        }
    }
}