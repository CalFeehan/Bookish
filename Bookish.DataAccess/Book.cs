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
        public int BookId { get;  private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int NumberOfCopies { get;  set; }
        public int CopiesAvailable { get; set; }
        public string ISBN { get; private set; }


        public static List<Book> GetAllBooks()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string QUERY_STRING = "SELECT * FROM Books";
            List<Book> bookList = (List<Book>)db.Query<Book>(QUERY_STRING);
            db.Close();
            return bookList;
        }

        public override string ToString()
        {
            return $"BookId: {BookId}, Title: {Title}, Author: {Author}";
        }
    }
}
