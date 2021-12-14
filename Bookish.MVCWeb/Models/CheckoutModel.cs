using Bookish.DataAccess;
using Bookish.DataAccess.Enums;
using System.Collections.Generic;
using System.Linq;

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
        //Searches Books member variable for a given book. If method is not specified, return all checked out books
        public List<Book> FindBook(int method, string searchString)
        {
            if(method == (int) Enum.CHECKOUTMETHOD.BYNAME) return (List<Book>)Books.Where(x => x.Title == searchString);
            if (method == (int)Enum.CHECKOUTMETHOD.BYAUTHOR) return (List<Book>)Books.Where(x => x.Author == searchString);
            else return Books;
        }
    }
}
