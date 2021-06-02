using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var stack = new Stack<int>();

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    stack.Push(i);
                }

                else if (text[i] == ')')
                {
                    var indexOfOpeningBracket = stack.Pop();
                    var result = text.Substring(indexOfOpeningBracket, i - indexOfOpeningBracket + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}