using Bookish.DataAccess;
using Bookish.DataAccess.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bookish.MVCWeb.Models
{
    public class CheckoutModel
    {
        public List<Checkout> Checkouts { get; }
        public List<Book> Books { get; private set; }

        public CheckoutModel(List<Checkout> checkouts)
        {
            Checkouts = checkouts;
            Books = new List<Book>();
            foreach (Checkout checkout in Checkouts)
            {
                Books.Add(BookRepo.GetBookByID(checkout.BookId));
            }
        }
        //Searches Books member variable for a given book. If method is not specified, return all checked out books
        public void FindBook(Enum.CHECKOUTMETHOD method, string searchString)
        {
            if(method == Enum.CHECKOUTMETHOD.BYNAME) Books =  Books.Where(x => x.Title.Contains(searchString)).ToList();
            if (method == Enum.CHECKOUTMETHOD.BYAUTHOR) Books = Books.Where(x => x.Author.Contains(searchString)).ToList();
        }
    }
}
