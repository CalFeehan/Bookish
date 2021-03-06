using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Bookish.DataAccess
{
    public class CheckoutRepo
    {
        public static List<Checkout> GetAllCheckouts() => DatabaseObject.ExecuteGetQuery<Checkout>("SELECT * FROM Checkouts");

        public static List<Checkout> GetUserCheckouts(string UserName) => DatabaseObject.ExecuteGetQuery<Checkout>($"SELECT * FROM Checkouts WHERE UserName=@UserName", new { UserName });

        public static List<Checkout> GetBookCheckouts(int bookId) => DatabaseObject.ExecuteGetQuery<Checkout>($"SELECT * FROM Checkouts WHERE BookId=@bookId", new { bookId });

        public static bool AddCheckout(string username, int bookId)
        {
            SqlConnection db = DatabaseObject.GetDbConnection();
            int copiesAvailable = ((List<int>) db.Query<int>($"SELECT NumberOfCopiesAvailable FROM Books WHERE BookId=@bookId", new { bookId }))[0];
            bool notCheckedOut = ((List<Checkout>) db.Query<Checkout>($"SELECT * FROM Checkouts WHERE UserName=@username AND BookId=@bookId", new { username, bookId })).Count == 0;
            bool success = false;
            if (copiesAvailable > 0 & notCheckedOut)
            {
                DateTime dueDate = DateTime.Now.AddDays(10);
                //string dueDateStr = dueDate.Year.ToString() + dueDate.Month.ToString() + dueDate.Day.ToString();
                string dueDateStr = dueDate.ToString("yyyy, MM, dd");
                db.Query($"INSERT INTO Checkouts VALUES (@username, @bookId, @dueDate)", new { username, bookId, dueDate });
                db.Query($"UPDATE Books SET NumberOfCopiesAvailable = NumberOfCopiesAvailable - 1 FROM Books WHERE BookId=@bookId", new { bookId });
                success = true;
            }
            db.Close();
            return success;
        }

        public static List<DateTime> GetDueDates(int bookId)
        {
            List<Checkout> checkouts = DatabaseObject.ExecuteGetQuery<Checkout>($"SELECT * FROM Checkouts WHERE BookId=@bookId", new { bookId });
            return checkouts.Select(x => x.DueDate).ToList();
        }
  
        public static bool RemoveCheckout(string username, int bookId)
        {
            SqlConnection db = DatabaseObject.GetDbConnection();
            bool isCheckedOut = ((List<Checkout>)db.Query<Checkout>($"SELECT * FROM Checkouts WHERE UserName=@username AND BookId=@bookId", new { username, bookId })).Count >= 1;
            bool success = false;
            if(isCheckedOut)
            {
                db.Query($"DELETE FROM Checkouts WHERE UserName=@username AND BookId=@bookId", new { username, bookId });
                db.Query($"UPDATE Books SET NumberOfCopiesAvailable = NumberOfCopiesAvailable + 1 FROM Books WHERE BookId=@bookId", new { bookId });
                success = true;
            }
            db.Close();
            return success;
        }
    }
}
