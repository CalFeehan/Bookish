using Bookish.DataAccess;
using System;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (User user in UserRepo.GetAllUsers())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine(user);
                Console.WriteLine(new string('*', 20));
            }

             BookRepo.AddBook("The Elements of Style", " William Strunk Jr.,  E. B. White,  William Strunk", "020530902X", "http://covers.openlibrary.org/b/id/6716028-M.jpg");

            foreach (Book book in BookRepo.GetAllBooks())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine(book);
                Console.WriteLine(new string('*', 20));
            }

            foreach (Checkout checkout in CheckoutRepo.GetAllCheckouts())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine(checkout);
                Console.WriteLine(new string('*', 20));
            }

            foreach (Checkout checkout in CheckoutRepo.GetUserCheckouts("callum.feehan@iris.co.uk"))
            {
                Console.WriteLine(checkout);
            }

        }
    }
}
