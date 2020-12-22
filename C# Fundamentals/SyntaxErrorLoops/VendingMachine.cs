using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var coinSum = 0m;

            while (input != "Start")
            {
                decimal currentCoin = decimal.Parse(input);

                if (currentCoin == 0.1M || currentCoin == 0.2M || currentCoin == 0.5M || currentCoin == 1 || currentCoin == 2)
                {
                    coinSum += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }
                input = Console.ReadLine();
            }

            var secInput = Console.ReadLine();
            var productPrice = 0;
            var product = string.Empty;

            while (secInput != "End")
            {
                product = secInput;

                if (product == "Nuts")
                {
                    productPrice = 2.0M;
                }
                else if (product == "Water")
                {
                    productPrice = 0.7M;
                }
                else if (product == "Crisps")
                {
                    productPrice = 1.5M;
                }
                else if (product == "Soda")
                {
                    productPrice = 0.8M;
                }
                else if (product == "Coke")
                {
                    productPrice = 1.0M;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    break;
                }
                secInput = Console.ReadLine();

                if (coinSum < productPrice)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    coinSum -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
            }
            Console.WriteLine($"Change: {coinSum:f2}");
        }
    }
}