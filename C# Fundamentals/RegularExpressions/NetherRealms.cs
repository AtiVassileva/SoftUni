using System;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            var patternHealth = @"[^0-9+\-*\/.]";
            var health = new Regex(patternHealth);

            var digitPattern = @"-?\d+\.?\d*";
            var digits = new Regex(digitPattern);

            var operatorPattern = @"[*\/]";
            var operatorP = new Regex(operatorPattern);

            var demonNames = Regex.Split(Console.ReadLine(), @"\s*, \s*").OrderBy(x => x).ToArray();

            for (var i = 0; i < demonNames.Length; i++)
            {
                var currentDemon = demonNames[i];
                var currHealth = 0;

                var healthSymbols = health.Matches(currentDemon);

                foreach (var symbol in healthSymbols)
                {
                    currHealth += char.Parse(symbol.Value);
                }

                var digitSymbols = digits.Matches(currentDemon);
                var baseDamage = 0;

                foreach (var num in digitSymbols)
                {
                    baseDamage += double.Parse(num.Value);
                }

                var operatorSymbols = operatorP.Matches(currentDemon);

                foreach (var operatorr in operatorSymbols)
                {
                    var @operator = operatorr.Value;

                    if (@operator == "*")
                    {
                        baseDamage *= 2;
                    }
                    else
                    {
                        baseDamage /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {currHealth} health, {baseDamage:f2} damage");
            }
        }
    }
}