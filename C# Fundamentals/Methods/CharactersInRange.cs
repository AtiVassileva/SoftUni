using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = char.Parse(Console.ReadLine());
            var second = char.Parse(Console.ReadLine());
            var bigger = Math.Max(first, second);
            var smaller = Math.Min(first, second);

            PrintMissingChars(smaller, bigger);
        }

        static void PrintMissingChars(int first, int second)
        {
            for (var i = first + 1; i < second; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}