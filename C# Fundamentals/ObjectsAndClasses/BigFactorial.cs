using System;
using System.Numerics;

namespace BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            BigInteger bigFactorial = 1;

            for (var i = number; i > 0; i--)
            {
                bigFactorial *= i;
            }
            Console.WriteLine(bigFactorial);
        }
    }
}