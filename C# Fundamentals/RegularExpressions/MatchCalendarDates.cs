using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatchCalendarDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"\b(?<day>\d{2})([.\/-])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            var datesString = Console.ReadLine();

            var dates = Regex.Matches(datesString, pattern);

            foreach (var date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}