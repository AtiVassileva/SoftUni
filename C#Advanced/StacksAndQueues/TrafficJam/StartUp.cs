using System;
using System.Linq;
using System.Collections.Generic;

namespace TraficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var passingCars = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();

            var totalCarsPassed = 0;
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                else if (line == "green")
                {
                    for (var i = 0; i < passingCars; i++)
                    {
                        if (cars.Any())
                        {
                            var currCar = cars.Dequeue();
                            Console.WriteLine($"{currCar} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(line);
                }
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}