using Bookish.DataAccess;
using Bookish.MVCWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Bookish.DataAccess.Enums;

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


            if(!string.IsNullOrEmpty(Title))
            {
                var books = BookRepo.GetBooksByTitle(Title);
                BookModel bookModel = new BookModel(books);
                return View(bookModel);

            }
            else if (!string.IsNullOrEmpty(Author))
            {
                var books = BookRepo.GetBooksByAuthor(Author);
                BookModel bookModel = new BookModel(books);
                return View(bookModel);
            }

            return View(new BookModel(BookRepo.GetAllBooks()));
        }

        public IActionResult Dashboard(string title, string author)
        {
            CheckoutModel checkoutModel = new CheckoutModel(CheckoutRepo.GetUserCheckouts(User.Identity.Name));
            
            if (!string.IsNullOrEmpty(title)) {
                checkoutModel.Books = checkoutModel.FindBook(Enum.CHECKOUTMETHOD.BYNAME, title);
                return View(checkoutModel);
            } 


            else if (!string.IsNullOrEmpty(author))
            {
                checkoutModel.Books = checkoutModel.FindBook(Enum.CHECKOUTMETHOD.BYAUTHOR, author);
                return View(checkoutModel);
            }


            return View(checkoutModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
           return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
