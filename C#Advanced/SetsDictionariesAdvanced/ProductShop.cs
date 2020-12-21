using System;
using System.Linq;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopProductPrice = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Revision")
                {
                    break;
                }

                var input = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var shopName = input[0];
                var currProduct = input[1];
                var currPrice = double.Parse(input[2]);

                if (!shopProductPrice.ContainsKey(shopName))
                {
                    shopProductPrice[shopName] = new Dictionary<string, double>();
                }
                if (!shopProductPrice[shopName].ContainsKey(currProduct))
                {
                    shopProductPrice[shopName].Add(currProduct, currPrice);
                }

            }

            foreach (var kvp in shopProductPrice)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var product in kvp.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}