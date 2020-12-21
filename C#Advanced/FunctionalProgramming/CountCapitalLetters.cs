using System;
using System.Linq;

namespace CountCapitalLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = words.Where(w => char.IsUpper(w[0])).ToList();
            if (result.Any())
            {
                Console.WriteLine(string.Join("\n", result));
            }
        }
    }
}