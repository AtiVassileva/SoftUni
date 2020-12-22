using System;
using System.Collections.Generic;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            var title = Console.ReadLine();
            var content = Console.ReadLine();
            var comments = new List<string>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end of comments")
                {
                    break;
                }

                comments.Add(line);
            }

            PrintTitle(title);
            PrintContent(content);
            PrintComments(comments);
        }

        private static void PrintComments(List<string> comments)
        {
            foreach (var comm in comments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"    {comm}");
                Console.WriteLine("</div>");
            }
        }

        private static void PrintContent(string content)
        {
            Console.WriteLine("<article>");
            Console.WriteLine($"    {content}");
            Console.WriteLine("</article>");
        }

        private static void PrintTitle(string title)
        {
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {title}");
            Console.WriteLine("</h1>");
        }
    }
}