using Bookish.DataAccess;
using System.Collections.Generic;

namespace Bookish.MVCWeb.Models
{
    public class BookDetailsModel
    {
        public List<Checkout> Checkouts { get; }
        public Book Book { get; }

        public BookDetailsModel(Book book)
        {
            Checkouts = CheckoutRepo.GetBookCheckouts(book.BookId);
            Book = book;
        }
    }
}
