using System;
using System.Collections.Generic;

namespace AdvertismentMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
            var events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            var authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            var cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            var random = new Random();
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var phrasesIndex = random.Next(0, phrases.Length);
                var eventsIndex = random.Next(0, events.Length);
                var authorsIndex = random.Next(0, authors.Length);
                var citiesIndex = random.Next(0, cities.Length);

                Console.WriteLine($"{phrases[phrasesIndex]} {events[eventsIndex]} {authors[authorsIndex]} – {cities[citiesIndex]}.");
            }
        }
    }
}