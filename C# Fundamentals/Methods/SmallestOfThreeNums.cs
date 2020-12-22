using System;

namespace SmallestOfThreeNums
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var third = int.Parse(Console.ReadLine());

            PrintSmallest(first, second, third);
        }
        static void PrintSmallest(int first, int second, int third)
        {
            var result = 0;

            if (first < second && first < third)
            {
                result = first;
            }
            else if (second < first && second < third)
            {
                result = second;
            }
            else
            {
                result = third;
            }

            Console.WriteLine(result);
        }
    }
}