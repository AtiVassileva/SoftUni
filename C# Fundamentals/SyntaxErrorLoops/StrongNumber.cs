using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var tempNum = num;
            var totalFactorialSum = 0;

            while (tempNum > 0)
            {
                var digit = tempNum % 10;
                tempNum /= 10;
                var currentFactorial = 1;

                for (var i = 1; i <= digit; i++)
                {
                    currentFactorial *= i;
                }
                totalFactorialSum += currentFactorial;
            }

            if (totalFactorialSum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}