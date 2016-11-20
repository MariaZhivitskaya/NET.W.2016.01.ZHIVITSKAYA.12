using System;
using System.Collections.Generic;
using System.IO;
using Task2.Logic;

namespace Task2.UI
{
    class Program
    {
        public static void ReadFromFile(string fileName, BookListService<Book> bls)
        {
            try
            {
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);

                while (br.BaseStream.Position != br.BaseStream.Length)
                    bls.Add(new Book(br.ReadString(), br.ReadString(), br.ReadString(), br.ReadInt32(), br.ReadInt32()));
            }
            catch
            {
                Console.WriteLine("An exception in file reading!");
            }
        }

        public static void Print(BookListService<Book> bls)
        {
            foreach (var book in bls)
            {
                Console.WriteLine();
                Console.WriteLine(book);
            }
            Console.WriteLine();
        }

        public class IncreasingSortByTitle : IComparer<Book>
        {
            public int Compare(Book x, Book y) => 
                string.Compare(x.Title, y.Title, StringComparison.Ordinal);
        }

        public class DecreasingSortByPagesNumber : IComparer<Book>
        {
            public int Compare(Book x, Book y) =>
                y.PagesNumber - x.PagesNumber;
        }

        public static int CompareByLanguage(Book book1, Book book2) => 
            string.Compare(book1.Language, book2.Language, StringComparison.Ordinal);

        static void Main(string[] args)
        {
            var bookList = new BookListService<Book>();

            ReadFromFile("BooksInput.txt", bookList);
            Console.WriteLine("\n********** Reading from the file **********");
            Print(bookList);

            bookList.SortBooksByTag(new IncreasingSortByTitle());
            Console.WriteLine("********** Increasing sort by the title **********");
            Print(bookList);

            bookList.SortBooksByTag(new DecreasingSortByPagesNumber());
            Console.WriteLine("********** Decreasing sort by the pages number **********");
            Print(bookList);

            bookList.Remove(bookList[2]);
            Console.WriteLine("********** Removing from BookList **********");
            Print(bookList);

            var criteria = new Book(language: "russian");
            Comparison<Book> comp = CompareByLanguage;
            Console.WriteLine("********** Finding books with the {0} language **********", 
                criteria.Language);
            var result = bookList.FindBookByTag(comp, criteria);
            foreach (var book in result)
            {
                Console.WriteLine();
                Console.WriteLine(book);
            }
            Console.WriteLine();
            

            BookListStorage.Save(new BinaryWriter(File.Open("BooksOutput.txt", 
                FileMode.OpenOrCreate, FileAccess.Write)), bookList);

            Console.ReadKey();
        }
    }
}
