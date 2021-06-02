using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new StreamReader("./text.txt");
            var counter = 0;
            var symbolsToReplace = { '?', '!', '.', ',', '-' };

            while (!stream.EndOfStream)
            {
                var line = stream.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (counter % 2 == 0)
                {
                    line = ReplaceAll(symbolsToReplace, '@', line);

                    line = ReverseWordsInText(line);
                    Console.WriteLine(line);
                }
                counter++;
            }
        }

        static string ReplaceAll(char[] replace, char replecement, string str)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var current = str[i];
                if (replace.Contains(current))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(current);
                }
            }

            return sb.ToString().TrimEnd();

        }

        static string ReverseWordsInText(string str)
        {
            var sb = new StringBuilder();
            var words = str.Split(' ').ToArray();

            for (var i = 0; i < words.Length; i++)
            {
                sb.Append(words[words.Length - i - 1]);
                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
    }
}