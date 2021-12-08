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

        public static List<User> GetAllUsers() => DatabaseObject.ExecuteGetQuery<User>("SELECT TOP 100 [UserId],[Username],[IsActive] FROM [Users]");

        public override string ToString() => $"UserId: {UserId}, Username: {Username}, IsActive: {IsActive}";
    }
}