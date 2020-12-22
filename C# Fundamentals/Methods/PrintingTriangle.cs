using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            PrintTriangle(count);
        }

        static void PrintTriangle(int n)
        {
            PrintUpperPart(n);
            PrintBottomPart(n);
        }

        static void PrintUpperPart(int num)
        {
            for (var counter = 1; counter <= num; counter++)
            {
                for (var j = 1; j <= counter; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
        static void PrintBottomPart(int num)
        {
            for (var counter = num - 1; counter >= 1; counter--)
            {
                for (var i = 1; i <= counter; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
    }
}