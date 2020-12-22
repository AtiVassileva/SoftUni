using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            PrintMiddleCharacters(input);
        }

        static void PrintMiddleCharacters(string input)
        {
            var length = input.Length;

            if (!(length % 2 == 0))
            {
                Console.WriteLine(input[length / 2]);
            }
            else
            {
                Console.WriteLine(input[length / 2 - 1] + "" + input[input.Length / 2]);
            }
        }
    }
}