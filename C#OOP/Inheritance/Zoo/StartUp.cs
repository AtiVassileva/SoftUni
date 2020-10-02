using System;
using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>()
            {
                new Bear("Ivan"),
                new Gorilla("Pesho"),
                new Lizard("Lizko"),
                new Snake("Snaky")
            };

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.GetType().Name} -- {animal.Name}");
            }
        }
    }
}
