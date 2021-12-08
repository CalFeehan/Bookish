using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bookish.DataAccess
{
    public class Checkout
    {
        public int UserId { get; }
        public int BookId { get; }
        public DateTime DueDate { get; init; }

        public static List<Checkout> GetAllCheckouts()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            string SqlString = "SELECT * FROM Checkouts";

            List<Checkout> checkoutList = (List<Checkout>)db.Query<Checkout>(SqlString);

            db.Close();

            return checkoutList;
        }

        public override string ToString() {
            return $"Book {BookId} checkout out by user {UserId}, due back {DueDate.ToShortDateString()}";
        }
    }
}
