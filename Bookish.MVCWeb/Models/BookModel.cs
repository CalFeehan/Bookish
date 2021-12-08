using Bookish.DataAccess;
using System.Collections.Generic;

namespace Bookish.MVCWeb.Models
{
    public class BookModel
    {
        public List<Book> Books { get; set; }
        
        public BookModel(List<Book> books)
        {
            Books = books;
        }
    }
}
