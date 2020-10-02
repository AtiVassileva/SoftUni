using System;
using System.Linq;
using P04.PizzaCalories.Core;
using P04.PizzaCalories.Models;

namespace P04.PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
