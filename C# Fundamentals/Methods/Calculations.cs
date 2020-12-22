using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var result = 0;

            switch (command)
            {
                case "add": 
                    result = Add(first, second); 
                    break;
                case "divide": 
                    result = Divide(first, second); 
                    break;
                case "substract": 
                    result = Substract(first, second); 
                    break;
                case "multiply": 
                    result = Multiply(first, second); 
                    break;
            }

            Console.WriteLine(result);
        }
        static int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
        static int Substract(int num1, int num2)
        {
            return (num1 - num2);
        }
        static int Multiply(int num1, int num2)
        {
            return (num1 * num2);
        }
        static int Divide(int num1, int num2)
        {
            return (num1 / num2);
        }
    }
}