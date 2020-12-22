using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = double.Parse(Console.ReadLine());
            var sign = char.Parse(Console.ReadLine());
            var second = double.Parse(Console.ReadLine());

            switch (sign)
            {
                case '/': 
                    ReturnDivide(first, second); 
                    break;
                case '*': 
                    ReturnMultiply(first, second); 
                    break;
                case '-': 
                    ReturnSubstraction(first, second); 
                    break;
                case '+': 
                    ReturnAdding(first, second); 
                    break;
            }
        }
        static double ReturnDivide(double first, double second)
        {
            var result = first / second;
            Console.WriteLine(Math.Round(result, 2));
            return result;
        }
        static double ReturnMultiply(double first, double second)
        {
            var result = first * second;
            Console.WriteLine(Math.Round(result, 2));
            return result;
        }
        static double ReturnSubstraction(double first, double second)
        {
            var result = first - second;
            Console.WriteLine(Math.Round(result, 2));
            return result;
        }
        static double ReturnAdding(double first, double second)
        {
            var result = first + second;
            Console.WriteLine(Math.Round(result, 2));
            return result;
        }
    }
}