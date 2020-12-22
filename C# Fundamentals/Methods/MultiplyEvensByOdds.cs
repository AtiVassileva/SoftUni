using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main()
        {
            var number = Math.Abs(int.Parse(Console.ReadLine()));
            var even = SumEven(number);
            var odd = SumOdd(number);

            Console.WriteLine(even * odd);
        }

        static int SumEven(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                var remainder = number % 10;
                number /= 10;
                if (remainder % 2 == 0)
                {
                    sum += remainder;
                }
            }
            return sum;
        }

        static int SumOdd(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                int remainder = number % 10;
                number /= 10;
                if (remainder % 2 == 1)
                {
                    sum += remainder;
                }
            }
            return sum;
        }
    }
}