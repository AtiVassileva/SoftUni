using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var correct = string.Empty;

            for (var i = word.Length - 1; i >= 0; i--)
            {
                correct += word[i];
            }
            Console.WriteLine(correct);
        }
    }
}