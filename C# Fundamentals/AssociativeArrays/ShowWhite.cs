using System;
using System.Linq;
using System.Collections.Generic;

namespace SnowWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfInfo = new Dictionary<string, int>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Once upon a time")
                {
                    break;
                }

                var input = line.Split(" <:> ");
                var name = input[0];
                var color = input[1];
                var physics = int.Parse(input[2]);

                var ID = name + ":" + color;

                if (!dwarfInfo.ContainsKey(ID))
                {
                    dwarfInfo.Add(ID, physics);
                }
                else
                {
                    dwarfInfo[ID] = Math.Max(physics, dwarfInfo[ID]);
                }
            }

            foreach (var dwarf in dwarfInfo
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfInfo.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1])
                    .Count()))
            {
                Console.WriteLine("({0}) {1} <-> {2}",
                    dwarf.Key.Split(':')[1],
                    dwarf.Key.Split(':')[0],
                    dwarf.Value);
            }
        }
    }
}