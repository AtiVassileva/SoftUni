using System;
using System.Linq;
using System.Collections.Generic;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            input = input.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "3:1")
                {
                    break;
                }
                var command = line.Split();

                if (command[0] == "merge")
                {
                    var startIndex = int.Parse(input[1]);
                    var endIndex = int.Parse(input[2]);
                    var concat = string.Empty;

                    if (startIndex > -1 && startIndex < input.Count && endIndex > -1 && endIndex < input.Count)
                    {
                        for (var i = startIndex; i <= endIndex; i++)
                        {
                            concat += input[i];
                        }

                        input.RemoveRange(startIndex, endIndex - startIndex + 1);
                        input.Insert(startIndex, concat);
                    }
                }
                else if (command[0] == "divide")
                {
                    var index = int.Parse(input[1]);
                    var parts = int.Parse(input[2]);

                    var word = input[index];
                    var needed = word.Length % parts;
                    var newWord = "";

                    for (var i = 0; i < needed; i++)
                    {
                        word += word[i];
                    }
                }
            }
        }
    }
}