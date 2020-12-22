using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var count = int.Parse(Console.ReadLine());

            PrintNewResult(input, count);
        }

        static string PrintNewResult(string input, int count)
        {
            var result = string.Empty;

            for (var i = 0; i < count; i++)
            {
                result += input;
            }
            Console.WriteLine(result);
            return result;
        }
    }
}