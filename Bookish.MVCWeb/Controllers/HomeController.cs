using Bookish.DataAccess;
using Bookish.MVCWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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
            BookModel bookModel = new BookModel(BookRepo.GetAllBooks());
            return View(bookModel);
        }

        public IActionResult Dashboard()
        {
            CheckoutModel checkoutModel = new CheckoutModel(CheckoutRepo.GetUserCheckouts(User.Identity.Name));
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
