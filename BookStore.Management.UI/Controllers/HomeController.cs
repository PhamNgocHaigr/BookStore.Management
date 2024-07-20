using BookStore.Management.Application.Abstracts;
using BookStore.Management.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Management.UI.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookService.GetBooksForSiteAsync(0, 1, 100);

            var books = result.Books.OrderBy(x => Guid.NewGuid())
                                    .Take(5);

            return View(books);
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
