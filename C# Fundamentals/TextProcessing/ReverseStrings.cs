using System;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                var result = "";
                for (var i = line.Length - 1; i >= 0; i--)
                {
                    result += line[i];
                }

                Console.WriteLine($"{line} = {result}");
            }
        }
    }
}