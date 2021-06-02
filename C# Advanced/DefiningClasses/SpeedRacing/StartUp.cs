using System;
using System.Linq;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var allCars = new HashSet<Car>();

            for (var i = 0; i < count; i++)
            {
                var inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var model = inputArgs[0];
                var fuelAmount = double.Parse(inputArgs[1]);
                var fuelConsumptionFor1km = double.Parse(inputArgs[2]);

                var car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                allCars.Add(car);
            }

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var carModel = tokens[1];
                var kmAmount = double.Parse(tokens[2]);

                allCars.Where(c => c.Model == carModel).ToList().ForEach(c => c.Drive(kmAmount));

            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}