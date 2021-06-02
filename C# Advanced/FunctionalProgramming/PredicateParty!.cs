using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Party!")
                {
                    break;
                }

                var command = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var cmdType = command[0];
                var predicateArgs = command.Skip(1).ToArray();

                var predicate = GetPredicate(predicateArgs);

                if (cmdType == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (cmdType == "Double")
                {
                    DoubleGuests(guests, predicate);
                }

            }

            if (guests.Any())
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoubleGuests(List<string> guests, Predicate<string> predicate)
        {
            for (var i = 0; i < guests.Count; i++)
            {
                var currGuest = guests[i];
                if (predicate(currGuest))
                {
                    guests.Insert(i + 1, currGuest);
                    i++;
                }
            }
        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            var type = predicateArgs[0];
            var argument = predicateArgs[1];

            Predicate<string> predicate = null;

            if (type == "StartsWith")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.StartsWith(argument);
                });
            }
            else if (type == "EndsWith")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.EndsWith(argument);
                });
            }
            else if (type == "Length")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.Length == int.Parse(argument);
                });
            }

            return predicate;
        }
    }
}