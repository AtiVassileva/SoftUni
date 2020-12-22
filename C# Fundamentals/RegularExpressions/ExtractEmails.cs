using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";

            var validEmails = Regex.Matches(input, pattern);

            foreach (var email in validEmails)
            {
                Console.WriteLine(email);
            }
        }
    }
}