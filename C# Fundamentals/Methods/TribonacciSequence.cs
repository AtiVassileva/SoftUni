using System;
using System.Numerics;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = BigInteger.Parse(Console.ReadLine());

            if (num <= 0)
            {
                Console.WriteLine(0);
            }
            else if (num == 1)
            {
                Console.Write(1);
            }
            else if (num == 2)
            {
                Console.Write("1 1");
            }
            else if (num == 3)
            {
                Console.Write("1 1 2");
            }
            else
            {
                Console.Write("1 1 2 ");
                GetTribonacci(num);
            }
        }

        private static void GetTribonacci(BigInteger num)
        {
            var minus3 = 1;
            var minus2 = 1;
            var minus1 = 2;
            var max = num;

            for (var i = 0; i < max - 3; i++)
            {
                num = minus3 + minus2 + minus1;
                minus3 = minus2;
                minus2 = minus1;
                minus1 = num;
                Console.Write($"{num} ");
            }
        }
    }
}