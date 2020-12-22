using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b");
            var text = Console.ReadLine();

            var matchedNumbers = regex.Matches(text);
            var correct = new List<string>();

            foreach (var num in matchedNumbers)
            {
                correct.Add(num.ToString());
            }

            Console.WriteLine(string.Join(", ", correct));
        }
    }
}