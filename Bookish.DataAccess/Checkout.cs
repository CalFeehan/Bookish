using System;

namespace Bookish.DataAccess
{
    public class Checkout
    {
        public string UserName { get; set; }
        public int BookId { get; }
        public DateTime DueDate { get; init; }

        public override string ToString() => $"Book {BookId} checkout out by user {UserName}, due back {DueDate.ToShortDateString()}";
        
    }

    
}
