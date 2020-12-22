using System;
using System.Linq;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var numOfCommands = int.Parse(Console.ReadLine());
            var names = new List<string>();

            for (var i = 0; i < numOfCommands; i++)
            {
                var command = Console.ReadLine();
                var input = command.Split().ToArray();

                if (input[1] == "is" && input[2] == "going!")
                {
                    if (names.Contains(input[0]))
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(input[0]);
                    }
                }
                else
                {
                    if (names.Contains(input[0]))
                    {
                        names.Remove(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}