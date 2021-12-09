using Bookish.DataAccess;
using System.Collections.Generic;

namespace Bookish.MVCWeb.Models
{
    public class CheckoutModel
    {
        public List<Checkout> Checkouts { get; }
        public List<Book> Books { get; }

        public CheckoutModel(List<Checkout> checkouts)
        {
            Checkouts = checkouts;
            foreach (Checkout checkout in Checkouts)
            {
                Books.Add(BookRepo.GetBookByID(checkout.BookId));
            }
        }
    }
}
