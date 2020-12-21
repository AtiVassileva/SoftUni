using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("words.txt");
            var lines = File.ReadAllLines("text.txt");

            var wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCount.Add(word, 0);

                foreach (var line in lines)
                {
                    if (line.ToLower().Contains(word.ToLower()))
                    {
                        wordsCount[word]++;
                    }
                }
            }

            using StreamWriter writer = new StreamWriter("actualResult.txt");
            {
                foreach (var kvp in wordsCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }

            Console.WriteLine("All Done! Please check the file \"actualResult.txt\" to see the result.");
        }
    }
}