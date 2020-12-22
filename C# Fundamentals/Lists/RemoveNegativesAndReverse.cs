using System;
using System.Linq;
using System.Collections.Generic;

namespace RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList().RemoveAll(n => n < 0);

            if (nums.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                nums.Reverse();
                Console.WriteLine(string.Join(' ', nums));
            }
        }
    }
}