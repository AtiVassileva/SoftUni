using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                var arguments = input.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Contains("|"))
                {
                    var side = arguments[0];
                    var user = arguments[1];

                    AddUser(book, side, user);
                }
                else if (input.Contains("->"))
                {
                    var user = arguments[0];
                    var side = arguments[1];

                    MoveUserToSide(book, user, side);
                }
            }

            PrintOutput(book);
        }

        private static void PrintOutput(Dictionary<string, List<string>> book)
        {
            var orderedBook =
                book.Where(b => b.Value.Count > 0).OrderByDescending(a => a.Value.Count).ThenBy(kvp => kvp.Key)
                    .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in orderedBook)
            {
                var currSide = kvp.Key;
                var currSideUsers = kvp.Value.OrderBy(u => u).ToList();

                Console.WriteLine($"Side: {currSide}, Members: {currSideUsers.Count}");

                foreach (var user in currSideUsers)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static void MoveUserToSide(Dictionary<string, List<string>> book, string user, string side)
        {
            foreach (var kvp in book)
            {
                if (kvp.Value.Contains(user))
                {
                    kvp.Value.Remove(user);
                }
            }
            if (!book.ContainsKey(side))
            {
                book[side] = new List<string>();
            }

            book[side].Add(user);
            Console.WriteLine($"{user} joins the {side} side!");
        }

        private static void AddUser(Dictionary<string, List<string>> book, string side, string user)
        {
            if (!book.ContainsKey(side))
            {
                book[side] = new List<string>();
            }

            if (!book.Values.Any(l => l.Contains(user)))
            {
                book[side].Add(user);
            }
        }
    }
}