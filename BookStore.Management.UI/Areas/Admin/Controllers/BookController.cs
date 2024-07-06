using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.ViewModels;
using BookStore.Management.DataAccess.Repository;
using BookStore.Management.UI.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookController : Controller
    {
        IBookService _bookService;
        IGenreService _genreService;
        public BookController(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
        }

        [BreadScrum("Book List", "Application")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [BreadScrum("Book Form", "Application")]
        public async Task<IActionResult> SaveData(int id)
        {
            var bookVM = new BookViewModel();

            string code = await _bookService.GenerateCodeAsync();
            bookVM.Code = code;

            if (id != 0)
            {
                bookVM = await _bookService.GetBooksByIdAsync(id);
            }

            return View(bookVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveData(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookService.SaveAsync(bookViewModel);

                if (result.Status)
                {
                    return RedirectToAction("", "book");
                }

                ModelState.AddModelError("error", result.Message);
            }
            else
            {
                ModelState.AddModelError("error", "Invalid model");
            }

            return View(bookViewModel);
        }

        

        [HttpGet]
        public async Task<IActionResult> GenerateCodeBook()
        {
            var result = await _bookService.GenerateCodeAsync();

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetBooksPagination(RequestDatatable requestDatatable)
        {
            var result = await _bookService.GetBooksByPaginationAsyns(requestDatatable);
            return Json(result); 
        }


    }
}
