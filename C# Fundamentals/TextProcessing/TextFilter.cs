using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bannnedWords = Console.ReadLine().Split(", ");
            var text = Console.ReadLine();

            for (var i = 0; i < bannnedWords.Length; i++)
            {
                var wordToCensor = bannnedWords[i];

                while (text.Contains(wordToCensor))
                {
                    text = text.Replace(wordToCensor, new string('*', wordToCensor.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}