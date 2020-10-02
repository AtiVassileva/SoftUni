using System;
using System.Linq;
using P04.PizzaCalories.Models;

namespace P04.PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            var pizzaArgs = Console.ReadLine().Split().ToArray();
            var doughArgs = Console.ReadLine().Split().ToArray();

            try
            {
                var pizzaName = pizzaArgs[1];

                var doughFlourType = doughArgs[1];
                var doughBakingTechnique = doughArgs[2];
                var doughWeight = double.Parse(doughArgs[3]);

                var dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);

                var pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var line = Console.ReadLine();
                    if (line == "END")
                    {
                        break;
                    }

                    var toppingArgs = line.Split().ToArray();
                    var toppingType = toppingArgs[1];
                    var toppingWeight = double.Parse(toppingArgs[2]);

                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
