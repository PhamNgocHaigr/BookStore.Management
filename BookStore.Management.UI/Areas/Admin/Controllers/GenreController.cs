using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.ViewModels;
using BookStore.Management.Application.Services;
using BookStore.Management.UI.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
            var genreMd = new GenreViewModel();
            return View(genreMd);
        }

        [HttpPost]
        public async Task<IActionResult> GetGenrePagination(RequestDatatable requestDatatable)
        {
            var result = await _genreService.GetGenreByPagination(requestDatatable);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _genreService.GetById(id));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveData(GenreViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _genreService.SaveAsync(genreViewModel); 
                if(result.Status)
                {
                    return RedirectToAction("", "genre"); 
                }    
                ModelState.AddModelError("errors", result.Message);
            }
            else
            {
                ModelState.AddModelError("errors", "Invalid model");
            }    
            return View(genreViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {            
            return Json(await _genreService.DeleteAsync(id));
        }
    }
}
