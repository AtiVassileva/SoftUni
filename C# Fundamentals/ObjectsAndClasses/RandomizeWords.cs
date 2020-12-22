using System;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var input = Console.ReadLine().Split();

            for (var i = 0; i < input.Length - 1; i++)
            {
                var index = random.Next(0, input.Length);
                var tempVar = input[index];
                input[index] = input[i];
                input[i] = tempVar;
            }

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}