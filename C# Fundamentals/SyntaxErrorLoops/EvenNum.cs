using System;

namespace EvenNum
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
        }
    }
}