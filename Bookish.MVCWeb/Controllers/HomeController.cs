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
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) { return Redirect("/Home/Dashboard"); }

            return View();
        }

        public IActionResult Dashboard(string title, string author)
        {
            CheckoutModel checkoutModel = new CheckoutModel(CheckoutRepo.GetUserCheckouts(User.Identity.Name));

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
            {
                checkoutModel.FilterBooks(title.ToLower(), author.ToLower());
            }

            else if (!string.IsNullOrEmpty(title)) {
                checkoutModel.FilterBooks(Enum.CHECKOUTMETHOD.BYNAME, title.ToLower());
            } 

            else if (!string.IsNullOrEmpty(author))
            {
                checkoutModel.FilterBooks(Enum.CHECKOUTMETHOD.BYAUTHOR, author.ToLower());
            }

            return View(checkoutModel);
        }

        public IActionResult Catalogue(string title, string author)
        {
            BookModel model = new BookModel(BookRepo.GetAllBooks());

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
            {
                model.FilterBooks(title, author);
            }
            else if (!string.IsNullOrEmpty(title))
            {
                model.FilterBooks(Enum.CHECKOUTMETHOD.BYNAME, title.ToLower());
            }
            else if (!string.IsNullOrEmpty(author))
            {
                model.FilterBooks(Enum.CHECKOUTMETHOD.BYAUTHOR, author.ToLower());
            }

            return View(model);
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
