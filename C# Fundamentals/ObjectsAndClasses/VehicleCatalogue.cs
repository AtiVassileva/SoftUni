using System;
using System.Linq;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    public class VehicleCatalogue
    {
        public static void Main()
        {
            var catalogue = new List<Vehicle>();

            while (true)
            {
                var inputTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                if (inputTokens[0] == "End")
                {
                    break;
                }

                var type = inputTokens[0].ToLower();
                var model = inputTokens[1];
                var color = inputTokens[2].ToLower();
                var horsePower = int.Parse(inputTokens[3]);
                var currentVehicle = new Vehicle(type, model, color, horsePower);
                catalogue.Add(currentVehicle);
            }

            while (true)
            {
                var model = Console.ReadLine();
                if (model == "Close the Catalogue")
                {
                    break;
                }

                Console.WriteLine(catalogue.Find(x => x.Model == model));
            }

            var allCars = catalogue.Where(x => x.Type == "car").ToList();
            var allTrucks = catalogue.Where(x => x.Type == "truck").ToList();

            var totalCarsHorsepower = 0;
            var totalTrucksHorsepower = 0;

            foreach (var car in allCars)
            {
                totalCarsHorsepower += car.HorsePower;
            }

            foreach (var truck in allTrucks)
            {
                totalTrucksHorsepower += truck.HorsePower;
            }

            var averageCarsHorsepower = totalCarsHorsepower / allCars.Count;
            var averageTrucksHorsepower = totalTrucksHorsepower / allTrucks.Count;

            if (allCars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (allTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            var output = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                $"Model: {this.Model}{Environment.NewLine}" +
                                $"Color: {this.Color}{Environment.NewLine}" +
                                $"Horsepower: {this.HorsePower}";

            return output.TrimEnd();
        }
    }
}