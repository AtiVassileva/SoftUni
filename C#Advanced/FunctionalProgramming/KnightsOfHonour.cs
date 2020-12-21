using System;
using System.Linq;

namespace KnightsOfHonour
{
    class Program
    {
        static void Main(string[] args)
        {
            var honour = (name) =>
            {
                Console.WriteLine("Sir " + name);
            };

            Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(honour);
        }
    }
}