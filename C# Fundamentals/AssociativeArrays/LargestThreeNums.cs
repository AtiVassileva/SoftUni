using System;
using System.Linq;

namespace LargestThreeNums
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sorted = numbers.OrderByDescending(n => n).ToArray();

            if (sorted.Length > 2)
            {
                for (var i = 0; i <= 2; i++)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
            else
            {
                Console.Write(string.Join(" ", sorted));
            }
        }
    }
}