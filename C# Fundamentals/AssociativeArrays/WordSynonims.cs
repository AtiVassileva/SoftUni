using System;
using System.Collections.Generic;

namespace WordSynonims
{
    class Program
    {
        private static readonly object dictionar;

        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var synonims = new Dictionary<string, List<string>>();

            for (var i = 0; i < count; i++)
            {
                var word = Console.ReadLine();
                var synonim = Console.ReadLine();

                if (!synonims.ContainsKey(word))
                {
                    synonims[word] = new List<string>();
                }

                synonims[word].Add(synonim);
            }
            foreach (var item in synonims)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}