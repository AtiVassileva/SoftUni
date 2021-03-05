using System;
using System.Linq;
using System.Text;
using BookShop.Models;
using System.Globalization;
using BookShop.Models.Enums;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = (AgeRestriction) Enum.Parse(typeof(AgeRestriction), command, true);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .ToList().OrderBy(b => b);

            var sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold
                            && b.Copies < 5000).Select(b => new {b.BookId, b.Title}).OrderBy(b => b.BookId).ToList();

            var sb = new StringBuilder();
            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var expensiveBooks = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new {b.Title, b.Price}).OrderByDescending(b => b.Price).ToList();

            var sb = new StringBuilder();
            foreach (var book in expensiveBooks)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year).Select(b => new {b.BookId, b.Title})
                .OrderBy(b => b.BookId).ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title).OrderBy(b => b).ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .Select(b => new {b.Title, b.EditionType, b.Price, b.ReleaseDate})
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsMatchingGivenCriteria = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new {FullName = a.FirstName + " " + a.LastName}).OrderBy(a => a.FullName).ToList();

            var sb = new StringBuilder();
            foreach (var author in authorsMatchingGivenCriteria)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var matchingBooksTitles = context.Books.Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title).OrderBy(b => b).ToList();

            var sb = new StringBuilder();
            foreach (var title in matchingBooksTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var matchingBooks = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower()
                    .StartsWith(input.ToLower()))
                .Select(b => new
                    {b.BookId, b.Title, AuthorFirstName = b.Author.FirstName, AuthorLastName = b.Author.LastName})
                .OrderBy(b => b.BookId).ToList();

            var sb = new StringBuilder();
            foreach (var book in matchingBooks)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books.Where(b => b.Title.Length > lengthCheck).ToList().Count;

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsCopies = context.Authors
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                }).OrderByDescending(a => a.BookCopies).ToList();

            var sb = new StringBuilder();
            foreach (var entry in authorsCopies)
            {
                sb.AppendLine($"{entry.AuthorFullName} - {entry.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies),
                }).OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name).ToList();

            var sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = 
                context.Categories.Select(c => new
            {
                c.Name,
                TopBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        cb.Book.ReleaseDate
                    }).Take(3).ToList()
            }).OrderBy(c => c.Name).ToList();

            var sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.TopBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();
            return books.Count;
        }
    }
}