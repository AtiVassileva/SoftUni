using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordToRemove = Console.ReadLine().ToLower();
            var text = Console.ReadLine();

            while (text.Contains(wordToRemove))
            {
                var start = text.IndexOf(wordToRemove);

                text = text.Remove(start, wordToRemove.Length);
            }

            Console.WriteLine(text);
        }
    }
}