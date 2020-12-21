using System;
using System.IO;
using System.Linq;
using System.Diagnostics.Tracing;

namespace LineNumberss
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("./text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];
                var letters = CountOfLetters(currentLine);
                var punctMarks = CountOfPunctuationalMarks(currentLine);

                lines[i] = $"Line {i + 1}: {currentLine} ({letters})({punctMarks})";
                Console.WriteLine(lines[i]);

            }
            File.WriteAllLines("../../../output.txt", lines);
        }

        static int CountOfLetters(string str)
        {
            var counter = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    counter++;
                }
            }

            return counter;
        }

        static int CountOfPunctuationalMarks(string line)
        {
            var marks = { '?', '-', '!', '.', ',', '\'' };
            var counter = 0;

            for (var i = 0; i < line.Length; i++)
            {
                var currentSymbol = line[i];
                if (marks.Contains(currentSymbol))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}