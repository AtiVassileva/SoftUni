using System;
using System.Collections.Generic;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var products = new List<string>();

            for (var i = 0; i < n; i++)
            {
                var currentProduct = Console.ReadLine();
                products.Add(currentProduct);
            }
            products.Sort();
            for (var i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}