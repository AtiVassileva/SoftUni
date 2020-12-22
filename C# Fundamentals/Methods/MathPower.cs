using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());
            var power = double.Parse(Console.ReadLine());

            ReturnResult(num, power);
        }

        static double ReturnResult(double num, double power)
        {
            var result = Math.Pow(num, power);
            Console.WriteLine(result);
            return result;
        }
    }
}