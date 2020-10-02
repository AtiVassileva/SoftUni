using System;
using Restaurant.Beverages.HotBeverages;
using Restaurant.Food.Desserts;
using Restaurant.Food.MainDishes;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main()
        {
            var cake = new Cake("Lindor");

            Console.WriteLine($"{cake.Grams} -- {cake.Calories} -- {cake.Price}");

            var fish = new Fish("Salmon", 22);
            Console.WriteLine(fish.Grams);

            var coffee = new Coffee("Mocha", 35);
            Console.WriteLine($"{coffee.Price} -- {coffee.Milliliters}");
        }
    }
}
