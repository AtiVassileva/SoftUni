using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var train = new int[count];

            for (var i = 0; i < count; i++)
            {
                var people = int.Parse(Console.ReadLine());
                train[i] = people;
            }

            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(train.Sum());
        }
    }
}