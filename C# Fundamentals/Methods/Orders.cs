using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            var price = 0.0;

            switch (product)
            {
                case "coffee": 
                    price = 1.5; 
                    break;
                case "water": 
                    price = 1; 
                    break;
                case "coke": 
                    price = 1.4; 
                    break;
                case "snacks": 
                    price = 2; 
                    break;
            }
            Prices(price, quantity);
        }

        static double Prices(double price, double quantity)
        {
            var result = price * quantity;
            Console.WriteLine($"{result:f2}");
            return result;
        }
    }
}