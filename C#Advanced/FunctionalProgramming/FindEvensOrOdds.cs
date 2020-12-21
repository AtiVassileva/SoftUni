using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main()
        {
            var bounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var query = Console.ReadLine();

            Predicate<int> predicate =
                query == "odd" ?
                    new Predicate<int>(n => n % 2 != 0) :
                    new Predicate<int>(n => n % 2 == 0);

            var result = new List<int>();
            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
}