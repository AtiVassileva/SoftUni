using System;
using System.Linq;
using System.Collections.Generic;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var cars = new HashSet<Car>();

            for (var i = 0; i < count; i++)
            {
                var carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var model = carArgs[0];
                var engineSpeed = int.Parse(carArgs[1]);
                var enginePower = int.Parse(carArgs[2]);
                var cargoWeight = int.Parse(carArgs[3]);
                var cargoType = carArgs[4];
                var tire1Pressure = double.Parse(carArgs[5]);
                var tire1Age = int.Parse(carArgs[6]);
                var tire2Pressure = double.Parse(carArgs[7]);
                var tire2Age = int.Parse(carArgs[8]);
                var tire3Pressure = double.Parse(carArgs[9]);
                var tire3Age = int.Parse(carArgs[10]);
                var tire4Pressure = double.Parse(carArgs[11]);
                var tire4Age = int.Parse(carArgs[12]);

                var car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
                    tire1Pressure, tire1Age, tire2Pressure, tire2Age,
                    tire3Pressure, tire3Age, tire4Pressure, tire4Age);

                cars.Add(car);
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                var result = cars.Where(c => c.Cargo.Type == "fragile" &&
                                             c.Tires.Any(t => t.Pressure < 1)).ToHashSet();
                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
            else if (command == "flamable")
            {
                var result = cars.Where(c => c.Cargo.Type == "flamable" &&
                                c.Engine.Power > 250).ToHashSet();

                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
        }
    }
}