using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var heigth = double.Parse(Console.ReadLine());

            var result = CalculateArea(width, heigth);
            Console.WriteLine(result);

        }
        static double CalculateArea(double width, double height)
        {
            return width * height;
        }
    }
}