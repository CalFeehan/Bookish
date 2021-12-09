using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bookish.DataAccess
{
    class DatabaseObject
    {
        public static List<T> ExecuteGetQuery<T>(string query)
        {
            IDbConnection db = new SqlConnection("Server=localhost;Database=bookish;Trusted_Connection=True;MultipleActiveResultSets=true");

            List<T> ret = db.Query<T>(query).ToList();
            
            db.Close();
            
            return ret;
        }

        public static void ExecutePostQuery(string query)
        {
            //Test before use

            IDbConnection db = new SqlConnection("Server=localhost;Database=bookish;Trusted_Connection=True;MultipleActiveResultSets=true");

            db.Query(query);

            db.Close();
        }
    }
}
