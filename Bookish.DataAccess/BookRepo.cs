using System.Collections.Generic;

namespace Bookish.DataAccess
{
    public class BookRepo
    {
        // SELECT
        public static List<Book> GetAllBooks() => DatabaseObject.ExecuteGetQuery<Book>("SELECT * FROM Books");

        public static List<Book> GetBooksByAuthor(string author) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE Author={author}");

        public static List<Book> GetBooksByTitle(string title) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE Title={title}");

        // INSERT
        public static void AddNewBook(string title, string author, int numberOfCopies, int numberOfCopiesAvailable, string ISBN, string CoverPhotoUrl)
        {
            DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE Title={title}");
        }
        
    }
}
