using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bookish.DataAccess
{
    public class DatabaseObject
    {
        public static string connectionString;
        public static List<T> ExecuteGetQuery<T>(string query, object param = null)
        {
            IDbConnection db = GetDbConnection();

            List<T> ret = db.Query<T>(query, param).ToList();
            
            db.Close();
            
            return ret;
        }

        public static void ExecutePostQuery(string query, object param = null)
        {
            IDbConnection db = GetDbConnection();

            db.Query(query, param);

            db.Close();
        }

        public static SqlConnection GetDbConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
