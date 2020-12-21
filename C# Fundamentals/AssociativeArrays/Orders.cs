using System;
using System.Linq;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var productPrices = new Dictionary<string, decimal>();
            var productQuantities = new Dictionary<string, long>();

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                var productArguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = productArguments[0];
                var price = decimal.Parse(productArguments[1]);
                var quantity = int.Parse(productArguments[2]);

                if (!productQuantities.ContainsKey(name))
                {
                    productPrices[name] = 0;
                    productQuantities[name] = 0;
                }

                productQuantities[name] += quantity;
                productPrices[name] = price;
            }

            foreach (var kvp in productPrices)
            {
                var name = kvp.Key;
                var price = kvp.Value;
                var quantity = productQuantities[name];
                var totalPrice = price * quantity;

                Console.WriteLine($"{name} -> {totalPrice:f2}");
            }
        }
    }
}