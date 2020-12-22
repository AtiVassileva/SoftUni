using System;

namespace CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            PrintClosestPoints(x1, y1, x2, y2);
        }

        static void PrintClosestPoints(double x1, double y1, double x2, double y2)
        {
            var result = Math.Abs(x1) + Math.Abs(y1);
            var result2 = Math.Abs(x2) + Math.Abs(y2);

            if (result < result2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}