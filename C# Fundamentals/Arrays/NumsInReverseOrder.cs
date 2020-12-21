using System;

namespace NumsInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var numbers = new int[count];

            for (var i = 0; i < count; i++)
            {
                var currentNum = int.Parse(Console.ReadLine());
                numbers[i] = currentNum;
            }
            for (var i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}