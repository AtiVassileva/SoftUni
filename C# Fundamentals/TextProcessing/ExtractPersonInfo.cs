using System;

namespace ExtractPersonInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine();
                var name = "";
                var age = "";

                var atIndex = input.IndexOf('@');
                var pipeIndex = input.IndexOf('|');
                var hastagIndex = input.IndexOf('#');
                var starIndex = input.IndexOf('*');

                for (var j = atIndex + 1; j < pipeIndex; j++)
                {
                    name += input[j];
                }

                for (var k = hastagIndex + 1; k < starIndex; k++)
                {
                    age += input[k];
                }

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}