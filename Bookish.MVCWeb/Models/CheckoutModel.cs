using Bookish.DataAccess;
using Bookish.DataAccess.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bookish.MVCWeb.Models
{
    public class CheckoutModel
    {
        public List<Checkout> Checkouts { get; }
        public List<Book> Books { get; set; }

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
        public List<Book> FindBook(Enum.CHECKOUTMETHOD method, string searchString)
        {
            if(method == Enum.CHECKOUTMETHOD.BYNAME) return Books.Where(x => x.Title.Contains(searchString)).ToList();
            if (method == Enum.CHECKOUTMETHOD.BYAUTHOR) return Books.Where(x => x.Author.Contains(searchString)).ToList();
            else return Books;
        }
    }
}
