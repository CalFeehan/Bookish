using Bookish.DataAccess;
using System;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (User user in User.GetAllUsers())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine(user);
                Console.WriteLine(new string('*', 20));
            }

            foreach (Book book in Book.GetAllBooks())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine(book);
                Console.WriteLine(new string('*', 20));
            }

            foreach (Checkout checkout in Checkout.GetAllCheckouts())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine(checkout);
                Console.WriteLine(new string('*', 20));
            }
        }
    }
}
