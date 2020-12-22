using System;

namespace AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var third = int.Parse(Console.ReadLine());

            Sum(first, second, third);
        }
        static void Sum(int a, int b, int c)
        {
            var result = (a + b) - c;
            Console.WriteLine(result);
        }
    }
}