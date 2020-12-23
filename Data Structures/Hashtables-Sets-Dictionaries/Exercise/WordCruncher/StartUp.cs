using System;

namespace WordCruncher
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ");
            var target = Console.ReadLine();

            var wc = new WordCruncher(input, target);

            foreach (var path in wc.GetPaths())
            {
                Console.WriteLine(path);
            }
        }
    }
}
