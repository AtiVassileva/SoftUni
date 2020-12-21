using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var parkingInfo = new Dictionary<string, string>();

            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var name = input[1];

                if (command == "register")
                {
                    var number = input[2];

                    if (!parkingInfo.ContainsKey(name))
                    {
                        parkingInfo.Add(name, number);
                        Console.WriteLine($"{name} registered {number} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingInfo[name]}");
                    }
                }
                else if (command == "unregister")
                {
                    if (!parkingInfo.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        parkingInfo.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in parkingInfo)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}