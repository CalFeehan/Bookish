using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bookish.DataAccess
{
    public class Book
    {
        public int BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int NumberOfCopies { get; set; }
        public int CopiesAvailable { get; set; }
        public string ISBN { get; private set; }

        public static List<Book> GetAllBooks() => DatabaseObject.ExecuteGetQuery<Book>("SELECT * FROM Books");

        public static List<Book> GetBooksByAuthor(string author) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE Author={author}");

        public static List<Book> GetBooksByTitle(string title) => DatabaseObject.ExecuteGetQuery<Book>($"SELECT * FROM Books WHERE Title={title}");

        public override string ToString() => $"BookId: {BookId}, Title: {Title}, Author: {Author}";

    }
}