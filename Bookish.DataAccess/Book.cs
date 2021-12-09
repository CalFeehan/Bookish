﻿

namespace Bookish.DataAccess
{
    public class Book
    {
        public int BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int NumberOfCopies { get; set; }
        public int CopiesAvailable { get; set; }
        public string ISBN { get; private set; }
        public string CoverPhotoUrl { get; private set; }

        public override string ToString() => $"BookId: {BookId}, Title: {Title}, Author: {Author}";

        public static void AddBook(string title, string author, string ISBN, string CoverPhotoUrl)
        {
            if (BookRepo.GetBooksByISBN(ISBN) != null)
            {
                BookRepo.AddCopyOfExistingBook(ISBN);
                return;
            }
            BookRepo.AddNewBook(title, author, ISBN, CoverPhotoUrl);
        }
    }
}