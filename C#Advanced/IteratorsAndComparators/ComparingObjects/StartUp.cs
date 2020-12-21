using System;
using System.Linq;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var tokens = line.Split(" ").ToArray();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                var currPerson = new Person(name, age, town);
                people.Add(currPerson);
            }

            var n = int.Parse(Console.ReadLine());

            var personToCompare = people[n - 1];

            var matches = 0;

            for (var i = 0; i < people.Count; i++)
            {
                if (personToCompare.CompareTo(people[i]) == 0)
                {
                    matches++;
                }
            }

            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                var notMatched = people.Count - matches;
                Console.WriteLine($"{matches} {notMatched} {people.Count}");
            }
        }
    }
}