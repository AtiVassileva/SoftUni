using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            var counter = 0;

            while (true)
            {
                var line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }
                if (counter % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                counter++;
            }
        }
    }
}