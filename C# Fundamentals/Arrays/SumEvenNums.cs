using System;
using System.Linq;

namespace SumEvenNums
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var sum = input.Where(n => n % 2 == 0).Sum();
            Console.WriteLine($"Even numbers sum is: {sum}");
        }
    }
}