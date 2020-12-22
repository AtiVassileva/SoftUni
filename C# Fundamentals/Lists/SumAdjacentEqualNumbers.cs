using System;
using System.Linq;
using System.Collections.Generic;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (var i = 0; i < numbers.Count / 2; i++)
            {
                Console.Write(numbers[i] + numbers[numbers.Count - i - 1] + " ");
            }
            if (numbers.Count % 2 == 1)
            {
                Console.WriteLine(numbers[numbers.Count / 2]);
            }
        }
    }
}