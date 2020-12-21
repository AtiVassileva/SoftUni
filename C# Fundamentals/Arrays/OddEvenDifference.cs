using System;
using System.Linq;

namespace OddEvenDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var evenSum = 0;
            var oddSum = 0;

            for (var i = 0; i < array.Length; i++)
            {
                var current = array[i];
                if (current % 2 == 0)
                {
                    evenSum += current;
                }
                else
                {
                    oddSum += current;
                }
            }
            var result = evenSum - oddSum;
            Console.WriteLine(result);
        }
    }
}