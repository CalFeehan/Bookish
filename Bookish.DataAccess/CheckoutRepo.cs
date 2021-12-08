using System.Collections.Generic;

namespace Bookish.DataAccess
{
    public class CheckoutRepo
    {
        public static List<Checkout> GetAllCheckouts() => DatabaseObject.ExecuteGetQuery<Checkout>("SELECT * FROM Checkouts");

        public static List<Checkout> GetUserCheckouts(string UserName) => DatabaseObject.ExecuteGetQuery<Checkout>($"SELECT * FROM Checkouts WHERE UserName=\'{UserName}\'");
    }
}
