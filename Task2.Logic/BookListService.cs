using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    class BookListService<T> where T : Book
    {
        /// <summary>
        /// A property for the book list.
        /// </summary>
        public List<Book> BookList { get; } = new List<Book>();

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
    }
}
