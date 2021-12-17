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
        public void FilterBooks(Enum.CHECKOUTMETHOD method, string searchString)
        {
            if(method == Enum.CHECKOUTMETHOD.BYNAME) Books =  Books.Where(x => x.Title.ToLower().Contains(searchString)).ToList();
            if (method == Enum.CHECKOUTMETHOD.BYAUTHOR) Books = Books.Where(x => x.Author.ToLower().Contains(searchString)).ToList();
        }
        public void FilterBooks(string title, string author)
        {
            var list1 = Books.Where(x => x.Title.ToUpper().Contains(title.ToUpper())).ToList();
            var list2 = Books.Where(x => x.Author.ToUpper().Contains(author.ToUpper())).ToList();
            Books = list1.Intersect(list2).ToList();
        }
    }
}
