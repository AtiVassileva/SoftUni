using System;
using System.Linq;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var continentCountryCities = new Dictionary<string, Dictionary<string, List<string>>>();

            for (var i = 0; i < count; i++)
            {
                var inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var continent = inputArgs[0];
                var country = inputArgs[1];
                var city = inputArgs[2];

                if (!continentCountryCities.ContainsKey(continent))
                {
                    continentCountryCities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continentCountryCities[continent].ContainsKey(country))
                {
                    continentCountryCities[continent].Add(country, new List<string>());
                }

                continentCountryCities[continent][country].Add(city);
            }

            foreach (var kvp in continentCountryCities)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}