using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = double.Parse(Console.ReadLine());
            var second = double.Parse(Console.ReadLine());

            var firstFac = Result(first);
            var secondFac = Result(second);
            var output = firstFac / secondFac;
            Console.WriteLine($"{output:f2}");

        }
        static double Result(double number)
        {
            var factorial = 1;
            for (var i = number; i >= 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}