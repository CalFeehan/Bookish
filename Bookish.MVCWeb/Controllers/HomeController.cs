using Bookish.DataAccess;
using Bookish.MVCWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Bookish.DataAccess.Enums;
using System.Linq;
using System.Collections.Generic;

namespace Bookish.MVCWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(string Title, string Author)
        {
            if (User.Identity.IsAuthenticated) { return Redirect("/Home/Dashboard"); }

            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author))
            {
                var booksByTitle = BookRepo.GetBooksByTitle(Title);
                var booksByAuthor = BookRepo.GetBooksByAuthor(Author);
                var bookSelection = booksByAuthor.Intersect(booksByTitle).ToList();
                return View(new BookModel(bookSelection));
            }
            else if(!string.IsNullOrEmpty(Title))
            {
                var books = BookRepo.GetBooksByTitle(Title);
                return View(new BookModel(books));

            }
            else if (!string.IsNullOrEmpty(Author))
            {
                var books = BookRepo.GetBooksByAuthor(Author);
                return View(new BookModel(books));
            }

            return View(new BookModel(BookRepo.GetAllBooks()));
        }

        public IActionResult Dashboard(string title, string author)
        {
            CheckoutModel checkoutModel = new CheckoutModel(CheckoutRepo.GetUserCheckouts(User.Identity.Name));



            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
            {
                checkoutModel.FindBook(title, author);
            }

            else if (!string.IsNullOrEmpty(title)) {
                checkoutModel.FindBook(Enum.CHECKOUTMETHOD.BYNAME, title);
            } 


            else if (!string.IsNullOrEmpty(author))
            {
                checkoutModel.FindBook(Enum.CHECKOUTMETHOD.BYAUTHOR, author);
            }


            return View(checkoutModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult GetCheckoutInfo(int bookId)
        {
            return PartialView(new BookDetailsModel(BookRepo.GetBookByID(bookId)));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
           return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
