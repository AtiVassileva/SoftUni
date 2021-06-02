using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (var i = 0; i < peopleCount; i++)
            {
                var person = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                people.Add(person[0], int.Parse(person[1]));
            }

            var condition = Console.ReadLine();
            var compareAge = int.Parse(Console.ReadLine());
            var outputFormat = Console.ReadLine();

            var filter = CreateFilter(condition, compareAge);
            var write = CreateWriter(outputFormat);

            foreach (var kv in people)
            {
                if (filter(kv.Value))
                {
                    write(kv);
                }
            }
        }

        static Func<int, bool> CreateFilter(string condition, int compareAge)
        {
            if (condition == "older")
            {
                return x => x >= compareAge;
            }

            return x => x < compareAge;
        }

        static Action<KeyValuePair<string, int>> CreateWriter(string outputFormat)
        {
            switch (outputFormat)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                default:
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
        }
    }
}