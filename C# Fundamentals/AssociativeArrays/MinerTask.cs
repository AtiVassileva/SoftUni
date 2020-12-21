using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, long>();

            string product;

            while ((product = Console.ReadLine()) != "stop")
            {
                var quantity = int.Parse(Console.ReadLine());

                if (!materials.ContainsKey(product))
                {
                    materials[product] = 0;
                }

                materials[product] += quantity;
            }

            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Key} -> {material.Value}");
            }
        }
    }
}