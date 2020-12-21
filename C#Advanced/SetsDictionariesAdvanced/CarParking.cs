using System;
using System.Linq;
using System.Collections.Generic;

namespace CarParking
{
    class Program
    {
        static void Main()
        {
            var parking = new HashSet<string>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }
                var inputArgs = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var command = inputArgs[0];
                var carNumber = inputArgs[1];

                if (command == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (command == "OUT" && parking.Any())
                {
                    parking.Remove(carNumber);
                }
            }
            if (parking.Any())
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}