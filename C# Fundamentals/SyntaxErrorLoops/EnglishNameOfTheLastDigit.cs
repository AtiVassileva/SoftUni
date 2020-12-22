using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace EnglishNameOfTheLastDigit
{
    public class EnglishNameOfLastDigit
    {
        public static void Main()
        {
            var num = long.Parse(Console.ReadLine());
            var lastDigit = FindLastDigits(num);

            if (num == 1)
            {
                Console.WriteLine("one");
            }
            else if (lastDigit == 2)
            {
                Console.WriteLine("two");
            }
            else if (lastDigit == 3)
            {
                Console.WriteLine("three");
            }
            else if (lastDigit == 4)
            {
                Console.WriteLine("four");
            }
            else if (lastDigit == 5)
            {
                Console.WriteLine("five");
            }
            else if (lastDigit == 6)
            {
                Console.WriteLine("six");
            }
            else if (lastDigit == 7)
            {
                Console.WriteLine("seven");
            }
            else if (lastDigit == 8)
            {
                Console.WriteLine("eight");
            }
            else if (lastDigit == 9)
            {
                Console.WriteLine("nine");
            }
            else if (lastDigit == 0)
            {
                Console.WriteLine("zero");
            }
        }

        private static long FindLastDigits(long num)
        {
            var lastDigs = Math.Abs(num % 10);
            return lastDigs;
        }
    }
}