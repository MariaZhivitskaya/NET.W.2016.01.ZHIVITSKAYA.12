using System;
using System.IO;

namespace Task2.Logic
{
    public class BookListStorage
    {
        /// <summary>
        /// Writes the list of books in a specified file
        /// with a BinaryWriter.
        /// </summary>
        /// <param name="bw">The binaryWriter.</param>
        /// <param name="bls">The BookListService.</param>
        public static void Save(BinaryWriter bw, BookListService<Book> bls)
        {
            foreach (var book in bls)
            {
                bw.Write(book.Author);
                bw.Write(book.Title);
                bw.Write(book.Language);
                bw.Write(book.PagesNumber);
                bw.Write(book.Edition);
            }

            Console.WriteLine("\n********** Sucessfully saved in the file! **********\n");
        }
    }
}
