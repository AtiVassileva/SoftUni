using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = double.Parse(Console.ReadLine());
            var num2 = double.Parse(Console.ReadLine());
            var num3 = double.Parse(Console.ReadLine());

            CheckIfPositiveOrNegative(num1, num2, num3);
        }
        static void CheckIfPositiveOrNegative(double num1, double num2, double num3)
        {
            if (num1 < 0 || num2 < 0 || num3 < 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 < 0 && num2 < 0 || num1 < 0 && num3 < 0 || num3 < 0 && num2 < 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}