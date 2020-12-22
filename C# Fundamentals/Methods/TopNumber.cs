using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            CheckIfIsTopNumber(number);
        }

        private static void CheckIfIsTopNumber(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                var sum = 0;
                var oddDigit = false;
                var cpy = i;

                while (true)
                {
                    if (cpy == 0) break;
                    int right = cpy % 10;
                    sum += right;
                    if (!(right % 2 == 0)) oddDigit = true;
                    cpy /= 10;
                }

                if (sum % 8 == 0 && oddDigit == true)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}