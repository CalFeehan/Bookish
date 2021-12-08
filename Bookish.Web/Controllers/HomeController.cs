using Microsoft.AspNetCore.Mvc;
using Bookish.DataAccess;
using Bookish.Web.ViewModels;

namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BookModel bookModel = new BookModel(Book.GetAllBooks());
            return View(bookModel);
        }
    }
}
