using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            var res = firstBook.Title.CompareTo(secondBook.Title);

            if (res == 0)
            {
                res = secondBook.Year.CompareTo(firstBook.Year);
            }

            return res;
        }
    }
}