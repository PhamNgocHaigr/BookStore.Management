using BookStore.Management.Application.Abstracts;
using BookStore.Management.Domain.Setting;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;

        public ShopController(IGenreService genreService, IBookService bookService)
        {
            _genreService = genreService;
            _bookService = bookService;
        }
        public async Task<IActionResult> Index(int g = 0, int idx = 1)
        {
            var genres = _genreService.GetGenresListForSite();

            ViewBag.Genres = genres;
            ViewBag.CurrentGenre = g;
            ViewBag.CurrentPageIndex = idx;

            var result = await _bookService.GetBooksForSiteAsync(g, idx, CommonConstant.BookPageSize);

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBooksByPagination(int genre, int pageIndex)
        {
            var result = await _bookService.GetBooksForSiteAsync(genre, pageIndex, CommonConstant.BookPageSize);

            return Json(result);
        }
    }
}
