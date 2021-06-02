using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BalancedParentheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            var openingBrackets = new Stack<char>();
            var pairsBrackets = new Dictionary<char, char>
            {
                {'(', ')'}, {'{', '}'}, {'[', ']'}
            };


            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];

                if (current == '(' || current == '[' || current == '{')
                {
                    openingBrackets.Push(current);
                }
                else if (openingBrackets.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    var lastOpeningBracket = openingBrackets.Pop();
                    var expectedClosingBracket = pairsBrackets[lastOpeningBracket];

                    if (current != expectedClosingBracket)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                }
            }

            if (openingBrackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}