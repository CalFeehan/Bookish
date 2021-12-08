using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bookish.DataAccess
{
    public class User
    {
        public int UserId { get; }
        public string Username { get; set; }
        public int IsActive { get; set; }        

        public static List<User> GetAllUsers()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            string SqlString = "SELECT TOP 100 [UserId],[Username],[IsActive] FROM [Users]";

            List<User> userList = (List<User>)db.Query<User>(SqlString);

            db.Close();

            return userList;
        }

        public override string ToString()
        {
            return $"UserId: {UserId}, Username: {Username}, IsActive: {IsActive}";
        }
    }
}