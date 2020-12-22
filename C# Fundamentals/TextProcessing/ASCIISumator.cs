using System;

namespace ASCIISumator
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = char.Parse(Console.ReadLine());
            var second = char.Parse(Console.ReadLine());
            var input = Console.ReadLine();

            var firstValue = (int)first;
            var secValue = (int)second;
            var sum = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var currentValue = (int)input[i];
                if (currentValue > firstValue && currentValue < secValue)
                {
                    sum += currentValue;
                }
            }

            Console.WriteLine(sum);
        }
    }
}