using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FurnitureEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quan>\d+)";

            var regex = new Regex(pattern);
            var totalSum = 0m;
            var furnitures = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    var name = match.Groups["name"].Value;
                    var price = decimal.Parse(match.Groups["price"].Value);
                    var quantity = int.Parse(match.Groups["quan"].Value);

                    furnitures.Add(name);
                    totalSum += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in furnitures)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}