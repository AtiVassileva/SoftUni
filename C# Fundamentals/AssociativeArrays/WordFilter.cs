using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();
            var needed = words.Where(x => x.Length % 2 == 0).ToArray();
            Console.WriteLine(string.Join("\n", needed));
        }
    }
}