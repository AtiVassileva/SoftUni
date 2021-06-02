using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = new HashSet<string>();
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var current = Console.ReadLine();
                usernames.Add(current);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}