using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2.Logic
{
    public class BookListService<T> : IEnumerable<Book> where T : Book
    {
        /// <summary>
        /// A property for the book list.
        /// </summary>
        public List<Book> BookList { get; } = new List<Book>();

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        /// <returns>Returns tne number of elements.</returns>
        public int Count => BookList.Count;

        /// <summary>
        /// Adds the book to the list.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the book is already in the list.
        /// </exception>
        /// <param name="book">The book.</param>
        public void Add(Book book)
        {
            if (IsInList(book))
                throw new ArgumentException("The book is already" +
                                            "in the list!");

            BookList.Add(book);
        }

        /// <summary>
        /// Removes the book from the list.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if there is no such book in the list.
        /// </exception>
        /// <param name="book">The book.</param>
        public void Remove(Book book)
        {
            if (!IsInList(book))
                throw new ArgumentException("No such book in the list!");

            BookList.Remove(book);
        }

        /// <summary>
        /// Sorts books by a specified tag.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the list is empty.
        /// </exception>
        /// <param name="iComparer">The tag.</param>
        public void SortBooksByTag(IComparer<Book> iComparer)
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("List is empty!");

            for (int i = 0; i < BookList.Count; i++)
                for (int j = 0; j < BookList.Count - i - 1; j++)
                    if (iComparer.Compare(BookList[j], BookList[j + 1]) > 0)
                        SwapElementsByIndexes(j, j + 1);
        }

        /// <summary>
        /// Finds books by a specified tag.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the list is empty.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if there is no such book in the list.
        /// </exception>
        /// <param name="comparison"></param>
        /// <param name="criteria">The criteria book.</param>
        /// <returns>Returns the list of books.</returns>
        public List<Book> FindBookByTag(Comparison<Book> comparison, Book criteria)
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("List is empty!");

            var resultList = BookList.Where(t => comparison(criteria, t) == 0).ToList();

            if (resultList.Count == 0)
                throw new ArgumentException("No such book in the list!");

            return resultList;
        }

        /// <summary>
        /// Gets the book with a specified index.
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>Returns the book.</returns>
        public Book this[int index]
        {
            get
            {
                if (index > Count - 1 || index < 0)
                    throw new ArgumentOutOfRangeException("Wrong index!");

                return BookList[index];
            }
        }

        /// <summary>
        /// Indicates whether the book
        /// is already in the list.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Returns true if the book is in the list.
        /// Returns false otherwise.
        /// </returns>
        private bool IsInList(Book book) => 
            BookList.Any(b => b == book);

        /// <summary>
        /// Indicates whether the list is empty.
        /// </summary>
        /// <returns>
        /// Returns true if the list is empty.
        /// Returns false otherwise.
        /// </returns>
        private bool IsEmpty() => BookList.Count == 0;

        /// <summary>
        /// Swaps two books in the list
        /// according to specified indexes.
        /// </summary>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        private void SwapElementsByIndexes(int index1, int index2)
        {
            var tmp = BookList[index1];
            BookList[index1] = BookList[index2];
            BookList[index2] = tmp;
        }

        /// <summary>
        /// Gets the enumerator for the list.
        /// </summary>
        /// <returns>Returns the next element.</returns>
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return BookList[i];
        }

        /// <summary>
        /// Gets the enumerator for the list.
        /// </summary>
        /// <returns>Returns the next element.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
