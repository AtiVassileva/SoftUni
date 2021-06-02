using System;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;

namespace CarSalesmen
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engines = new HashSet<Engine>();
            var cars = new List<Car>();

            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var engineArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                Engine engine = null;

                var model = engineArgs[0];
                var power = int.Parse(engineArgs[1]);

                if (engineArgs.Length == 4)
                {
                    var displacement = int.Parse(engineArgs[2]);
                    var efficiency = (engineArgs[3]);

                    engine = new Engine(model, power, displacement, efficiency);
                }

                else if (engineArgs.Length == 3)
                {
                    int displacement;

                    var isDisplacement = int.TryParse(engineArgs[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineArgs[2]);
                    }
                }
                else if (engineArgs.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                if (engine != null)
                {
                    engines.Add(engine);
                }
            }

            var secCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < secCount; i++)
            {
                var carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                Car car = null;

                var model = carArgs[0];

                var engine = engines.First(e => e.Model == carArgs[1]);

                if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArgs.Length == 3)
                {
                    var isWeight = double.TryParse(carArgs[2], out var weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carArgs[2]);
                    }

                }
                else if (carArgs.Length == 4)
                {
                    var weight = double.Parse(carArgs[2]);
                    var color = carArgs[3];

                    car = new Car(model, engine, weight, color);
                }

                if (car != null)
                {
                    cars.Add(car);
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

    }
}