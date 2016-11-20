using System;

namespace Task2.Logic
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book : IEquatable<Book>
    {
        private string _author;
        private string _title;
        private string _language;
        private int _pagesNumber;
        private int _edition;

        /// <summary>
        /// A property for the author.
        /// <exception cref="ArgumentNullException">
        /// Thrown if the string is null or empty.
        /// </exception>
        /// </summary>
        public string Author
        {
            get { return _author; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Null or empty string!");

                _author = value;
            }
        }

        /// <summary>
        /// A property for the title.
        /// <exception cref="ArgumentNullException">
        /// Thrown if the string is null or empty.
        /// </exception>
        /// </summary>
        public string Title
        {
            get { return _title; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Null or empty string!");

                _title = value;
            }
        }

        /// <summary>
        /// A property for the language.
        /// <exception cref="ArgumentNullException">
        /// Thrown if the string is null or empty.
        /// </exception>
        /// </summary>
        public string Language
        {
            get { return _language; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Null or empty string!");

                _language = value;
            }
        }

        /// <summary>
        /// A property for the pages number.
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the pages number is less
        /// or equal than 0.
        /// </exception>
        /// </summary>
        public int PagesNumber
        {
            get { return _pagesNumber; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong number of pages!");

                _pagesNumber = value;
            }
        }

        /// <summary>
        /// A property for the edition.
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the edition is less
        /// or equal than 0.
        /// </exception>
        /// </summary>
        public int Edition
        {
            get { return _edition; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong edition!");

                _edition = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Book class
        /// with a specified author, title, language,
        /// pages number and edition.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <param name="title">The title.</param>
        /// <param name="language">The language.</param>
        /// <param name="pagesNumber">The pages number.</param>
        /// <param name="edition">The edition.</param>
        public Book(string author = "Not specified", string title = "Not specified", 
            string language = "Not specified", int pagesNumber = 10, int edition = 10)
        {
            Author = author;
            Title = title;
            Language = language;
            PagesNumber = pagesNumber;
            Edition = edition;
        }

        /// <summary>
        /// Compares two books for equality.
        /// </summary>
        /// <param name="other">The book for a comparison.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Author.Equals(other.Author) &&
                   Title.Equals(other.Title) &&
                   Language.Equals(other.Language) &&
                   PagesNumber.Equals(other.PagesNumber) &&
                   Edition.Equals(other.Edition);
        }

        /// <summary>
        /// Compares two books for equality.
        /// </summary>
        /// <param name="obj">The book for a comparison.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Book)obj);
        }

        /// <summary>
        /// Gets the hash-code of the book.
        /// </summary>
        /// <returns>Returns the hash-code of the book.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _author?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (_title?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ _pagesNumber;

                return hashCode;
            }
        }

        public override string ToString()
        {
            return "    Author: " + Author +
                   "\n    Title: " + Title +
                   "\n    Language: " + Language +
                   "\n    Pages number: " + PagesNumber +
                   "\n    Edition: " + Edition;
        }

        /// <summary>
        /// Compares two books for equality.
        /// </summary>
        /// <param name="book1">The left-hand book.</param>
        /// <param name="book2">The right-hand book.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public static bool operator ==(Book book1, Book book2)
        {
            if (ReferenceEquals(book1, book2))
                return true;

            if (ReferenceEquals(book1, null))
                return false;

            return book1.Equals(book2);
        }

        /// <summary>
        /// Compares two books for inequality.
        /// </summary>
        /// <param name="book1">The left-hand book.</param>
        /// <param name="book2">The right-hand book.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public static bool operator !=(Book book1, Book book2) => 
            !(book1 == book2);

        /// <summary>
        /// Indicates whether the left-hand book
        /// is greater than the right-hand book.
        /// </summary>
        /// <param name="book1">The left-hand book.</param>
        /// <param name="book2">The right-hand book.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public static bool operator >(Book book1, Book book2)
        {
            if (book1.Author.Equals(book2.Author))
                if (book1.Title.Equals(book2.Title))
                    if (book1.Language.Equals(book2.Language))
                        if (book1.PagesNumber == book2.PagesNumber)
                            if (book1.Edition == book2.Edition)
                                return false;
                            else
                                return book1.Edition > book2.Edition;
                        else
                            return book1.PagesNumber > book2.PagesNumber;
                    else
                        return string.Compare(book1.Language, book2.Language,
                            StringComparison.Ordinal) == -1;
                else
                    return string.Compare(book1.Title, book2.Title,
                        StringComparison.Ordinal) == -1;

            return string.Compare(book1.Author, book2.Author,
                StringComparison.Ordinal) == -1;
        }

        /// <summary>
        /// Indicates whether the left-hand book
        /// is less than the right-hand book.
        /// </summary>
        /// <param name="book1">The left-hand book.</param>
        /// <param name="book2">The right-hand book.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public static bool operator <(Book book1, Book book2) => 
            !(book1 > book2) && book1 != book2;
    }
}
