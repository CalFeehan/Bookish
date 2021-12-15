using Bookish.DataAccess;
using Bookish.DataAccess.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bookish.MVCWeb.Models
{
    public class BookModel
    {
        public List<Book> Books { get; set; }
        
        public BookModel(List<Book> books)
        {
            Books = books;
        }

        public void FilterBooks(string author, string title)
        {
            var list1 = Books.Where(x => x.Title.ToUpper().Contains(author.ToUpper())).ToList();
            var list2 = Books.Where(x => x.Author.ToUpper().Contains(title.ToUpper())).ToList();
            Books = list1.Intersect(list2).ToList();
        }

        public void FilterBooks(Enum.CHECKOUTMETHOD method, string searchString)
        {
            if (method == Enum.CHECKOUTMETHOD.BYNAME) Books = Books.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
            if (method == Enum.CHECKOUTMETHOD.BYAUTHOR) Books = Books.Where(x => x.Author.ToLower().Contains(searchString.ToLower())).ToList();
        }
    }
}
