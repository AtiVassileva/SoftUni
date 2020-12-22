using System;
using System.Linq;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            CountVowels(input);
        }

        static void CountVowels(string newInput)
        {
            var counter = 0;

            for (var i = 0; i < newInput.Length; i++)
            {
                if (newInput[i].ToLower() == 'a' || newInput[i].ToLower() == 'e' || newInput[i].ToLower() == 'i' || newInput[i].ToLower() == 'o' || newInput[i].ToLower() == 'u')
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}