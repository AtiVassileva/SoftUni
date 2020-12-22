using System;
using System.Linq;
using System.Collections.Generic;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            var capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                var input = line.Split();
                switch (input[0])
                {
                    case "Add":
                        var numToAdd = int.Parse(input[1]);
                        if (numToAdd <= capacity)
                        {
                            wagons.Add(numToAdd);
                        }
                        break;
                    default:
                        var currentPassengers = int.Parse(input[0]);
                        for (var i = 0; i < wagons.Count; i++)
                        {
                            if (wagons[i] + currentPassengers <= capacity)
                            {
                                wagons[i] += currentPassengers;
                                break;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}