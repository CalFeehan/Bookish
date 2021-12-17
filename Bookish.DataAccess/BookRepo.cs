using System;
using System.Collections.Generic;

namespace Bookish.DataAccess
{
    public static class BookRepo
    {
        // SELECT
        public static List<Book> GetAllBooks() => DatabaseObject.ExecuteGetQuery<Book>("SELECT * FROM Books");

        public static List<Book> GetBooksByAuthor(string author) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE Author LIKE @%author%", new { author });

        public static List<Book> GetBooksByTitle(string title) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE Title LIKE @%title%", new { title });

        public static Book GetBookByID(int bookId) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE BookId=@bookId", new { bookId })[0];

        public static List<Book> GetBooksByISBN(string ISBN) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE ISBN=@ISBN", new { ISBN });

        // INSERT
        private static void AddNewBook(string title, string author, string ISBN, string CoverPhotoUrl)
        {
            DatabaseObject.ExecuteGetQuery<Book>($"INSERT INTO Books VALUES (@title, @author, {1}, {1}, @ISBN, @CoverPhotoUrl)", new { title, author, ISBN, CoverPhotoUrl });
        }

        private static void AddCopyOfExistingBook(string ISBN)
        {
            DatabaseObject.ExecutePostQuery($"UPDATE Books SET NumberOfCopies = NumberOfCopies + 1, NumberOfCopiesAvailable = NumberOfCopiesAvailable + 1 FROM Books WHERE ISBN=@ISBN", new { ISBN });
        }

        // METHODS
        public static void AddBook(string title, string author, string ISBN, string CoverPhotoUrl)
        {
            if (GetBooksByISBN(ISBN).Count != 0)
            {
                AddCopyOfExistingBook(ISBN);
                return;
            }
            AddNewBook(title, author, ISBN, CoverPhotoUrl);
        }
    }
}
