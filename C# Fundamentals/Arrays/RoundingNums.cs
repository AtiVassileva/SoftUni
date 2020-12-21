using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace RoundingNums
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (var number in array)
            {
                var rounded = (int)Math.Round(number, MidpointRounding.AwayFromZero);
                Console.WriteLine("{0} => {1}", number, rounded);
            }
        }
    }
}