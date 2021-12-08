using System.Collections.Generic;

namespace Bookish.DataAccess
{
    public class UserRepo
    {
        public static List<User> GetAllUsers() => DatabaseObject.ExecuteGetQuery<User>("SELECT TOP 100 [Id],[Username] FROM [Users]");
    }
}
