using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.UI.Ultility;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }


        [BreadScrum("Genre List", "Application")] 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetGenrePagination(RequestDatatable requestDatatable)
        {
            var result = await _genreService.GetGenreByPagination(requestDatatable);
            return Json(result);
        }
    }
}
