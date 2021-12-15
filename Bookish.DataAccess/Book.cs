

namespace Bookish.DataAccess
{
    public class Book
    {
        public int BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int NumberOfCopies { get; set; }
        public int NumberOfCopiesAvailable { get; set; }
        public string ISBN { get; private set; }
        public string CoverPhotoUrl { get; private set; }

        public override string ToString() => $"BookId: {BookId}, Title: {Title}, Author: {Author}, NumberOfCopies: {NumberOfCopies}, NumberOfCopiesAvailable: {NumberOfCopiesAvailable}.";

        public override bool Equals(object obj)
        {
            var other = obj as Book;
            return BookId.Equals(other.BookId);
        }
        public override int GetHashCode()
        {
            return this.BookId;      
        }

    }
}