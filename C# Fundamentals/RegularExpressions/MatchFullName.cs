using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b";
            var names = Console.ReadLine();

            var collection = Regex.Matches(names, regex);

            foreach (var name in collection)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}