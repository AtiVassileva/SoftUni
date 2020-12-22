using System;
using System.Numerics;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            for (var i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                var subsequenceLenght = 0;

                for (var j = i + 1; j < input.Length; j++)
                {
                    var nextChar = input[j];

                    if (currentChar == nextChar)
                    {
                        subsequenceLenght++;
                    }
                    else
                    {
                        break;
                    }
                }

                input = input.Remove(i + 1, subsequenceLenght);
            }

            Console.WriteLine(input);
        }
    }
}