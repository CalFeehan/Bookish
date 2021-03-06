using Bookish.DataAccess;
using System;
using System.Configuration;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            DatabaseObject.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            foreach (User user in UserRepo.GetAllUsers())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine(user);
                Console.WriteLine(new string('*', 20));
            }

            // BookRepo.AddBook("The Elements of Style", " William Strunk Jr.,  E. B. White,  William Strunk", "020530902X", "http://covers.openlibrary.org/b/id/6716028-M.jpg");

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

            foreach (Checkout checkout in CheckoutRepo.GetUserCheckouts("ian.nkwocha@iris.co.uk"))
            {
                Console.WriteLine(checkout);
            }

            Console.WriteLine(BookRepo.GetBooksByAuthor("Will"));

            //Run CSV import
            //CSVReader.AddCSVLineToBookDatabase(CSVReader.ExtractFromCSV(@"C:\Users\Ian.Nkwocha\Downloads\amended_books.csv", true));
            //Checkout first 23 books
            //for (int i = 7; i < 30; i++)
            //{ CheckoutRepo.AddCheckout("callum.feehan@iris.co.uk", i); }

            //CheckoutRepo.AddCheckout("test@test.com", 1);
            //CheckoutRepo.AddCheckout("danny.flahive@iris.co.uk", 1);
            //CheckoutRepo.AddCheckout("danny.flahive@iris.co.uk", 8);
            //CheckoutRepo.AddCheckout("ian.nkwocha@iris.co.uk", 1);
            //CheckoutRepo.AddCheckout("ian.nkwocha@iris.co.uk", 89);
            //CheckoutRepo.AddCheckout("callum.feehan@iris.co.uk", 1);
            //
            //foreach (Checkout checkout in CheckoutRepo.GetUserCheckouts("callum.feehan@iris.co.uk"))
            //{
            //    Console.WriteLine(checkout);
            //}

        }
    }
}
