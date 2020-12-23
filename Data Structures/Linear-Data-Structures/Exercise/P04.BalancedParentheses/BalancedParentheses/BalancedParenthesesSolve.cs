using System.Linq;

namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 != 0 || string.IsNullOrWhiteSpace(parentheses))
            {
                return false;
            }

            var openingBrackets = new Stack<char>();
            var pairsBrackets = new Dictionary<char, char>
            {
                {'(', ')'}, {'{', '}'}, {'[', ']'}
            };

            foreach (var currentBracket in parentheses)
            {
                if (currentBracket == '(' || currentBracket == '[' || currentBracket == '{')
                {
                    openingBrackets.Push(currentBracket);
                }

                else if (!openingBrackets.Any())
                {
                    return false;
                }

                else
                {
                    var openingBracket = openingBrackets.Pop();
                    var expectedClosingBracket = pairsBrackets[openingBracket];

                    if (currentBracket != expectedClosingBracket)
                    {
                        return false;
                    }
                }
            }

            return openingBrackets.Count == 0;
        }
    }
}
