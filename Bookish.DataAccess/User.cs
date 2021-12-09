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
        public string Id { get; }
        public string UserName { get; set; }
        
        public override string ToString() => $"Id: {Id}, UserName: {UserName}.";
    }
}