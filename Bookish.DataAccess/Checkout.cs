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

        public static List<Checkout> GetAllCheckouts() => DatabaseObject.ExecuteGetQuery<Checkout>("SELECT * FROM Checkouts");

        public override string ToString() => $"Book {BookId} checkout out by user {UserId}, due back {DueDate.ToShortDateString()}";
    }
}
