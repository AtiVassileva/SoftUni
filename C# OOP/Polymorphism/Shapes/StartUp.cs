using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            var rect = new Rectangle(9, 8);
            Console.WriteLine($"{rect.CalculateArea():F2}");
            Console.WriteLine($"{rect.CalculatePerimeter():F2}");
            Console.WriteLine(rect.Draw());

            var circle = new Circle(12);
            Console.WriteLine($"{circle.CalculateArea():F2}");
            Console.WriteLine($"{circle.CalculatePerimeter():F2}");
            Console.WriteLine(circle.Draw());

            var secondRect = new Rectangle(-1, 5);

            
        }
    }
}
