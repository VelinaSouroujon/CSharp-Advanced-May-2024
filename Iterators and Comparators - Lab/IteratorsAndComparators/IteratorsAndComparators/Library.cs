using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int currentIndex;
            private readonly List<Book> books;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = books.ToList();
            }
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;

                return currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
            public void Dispose()
            {

            }
        }
    }
}
