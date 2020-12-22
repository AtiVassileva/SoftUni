using System;
using System.Linq;
using System.Collections.Generic;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var articles = new List<Article>();

            for (var i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split(", ");

                var currArticle = new Article(tokens[0], tokens[1], tokens[2]);
                articles.Add(currArticle);
            }

            var command = Console.ReadLine();
            var sortedArticles = new List<Article>();

            if (command == "author")
            {
                sortedArticles = articles.OrderBy(a => a.Author).ToList();
            }
            else if (command == "content")
            {
                sortedArticles = articles.OrderBy(a => a.Content).ToList();
            }
            else
            {
                sortedArticles = articles.OrderBy(a => a.Title).ToList();
            }
            sortedArticles.ForEach(x => Console.WriteLine(x));
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}